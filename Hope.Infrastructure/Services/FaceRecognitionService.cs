using Hope.Application.Common.Interfaces;
using Hope.Application.Common.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using OpenCvSharp;
using OpenCvSharp.Face;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Hope.Infrastructure.Services
{
    public class FaceRecognitionService : IFaceRecognitionService
    {
        private readonly IWebHostEnvironment _environment;
        private readonly ILogger<FaceRecognitionService> _logger;
        private readonly CascadeClassifier _faceDetector;
        private readonly LBPHFaceRecognizer _recognizer;
        private readonly string _imagesFolder;
        private readonly double _similarityThreshold = 80.0; // Adjust based on testing

        public FaceRecognitionService(
            IWebHostEnvironment environment,
            ILogger<FaceRecognitionService> logger)
        {
            _environment = environment;
            _logger = logger;
            _imagesFolder = Path.Combine(_environment.WebRootPath, "uploads", "report-images");
            
            // Initialize face detector
            var faceXmlPath = Path.Combine(_environment.ContentRootPath, "FaceRecognition", "haarcascade_frontalface_default.xml");
            _faceDetector = new CascadeClassifier(faceXmlPath);
            
            // Initialize face recognizer
            _recognizer = LBPHFaceRecognizer.Create(1, 8, 8, 8, _similarityThreshold);
        }

        public async Task<Result<Guid?>> FindMatchingFaceAsync(IFormFile imageFile)
        {
            try
            {
                if (imageFile == null || imageFile.Length == 0)
                {
                    return Result<Guid?>.Failure("No image provided");
                }

                // Ensure the images directory exists
                if (!Directory.Exists(_imagesFolder))
                {
                    _logger.LogWarning("Images folder does not exist: {Folder}", _imagesFolder);
                    return Result<Guid?>.Success(null); // No matches possible
                }

                // Get all image files in the directory
                var imageFiles = Directory.GetFiles(_imagesFolder)
                    .Where(f => f.EndsWith(".jpg") || f.EndsWith(".jpeg") || f.EndsWith(".png"))
                    .ToList();

                if (!imageFiles.Any())
                {
                    _logger.LogInformation("No images found in the directory for comparison");
                    return Result<Guid?>.Success(null); // No matches possible
                }

                // Convert uploaded image to format needed for face recognition
                Mat uploadedImage;
                using (var ms = new MemoryStream())
                {
                    await imageFile.CopyToAsync(ms);
                    ms.Position = 0;
                    
                    // Create a temporary file to avoid memory issues
                    string tempDir = Path.Combine(_environment.ContentRootPath, "TempImages");
                    Directory.CreateDirectory(tempDir);
                    string tempFile = Path.Combine(tempDir, $"upload_{Guid.NewGuid()}.jpg");
                    
                    try
                    {
                        using (var fileStream = new FileStream(tempFile, FileMode.Create))
                        {
                            ms.Position = 0;
                            await ms.CopyToAsync(fileStream);
                        }
                        
                        // Load image using OpenCvSharp
                        uploadedImage = Cv2.ImRead(tempFile, ImreadModes.Color);
                    }
                    finally
                    {
                        // Clean up temp file
                        try { if (File.Exists(tempFile)) File.Delete(tempFile); } catch { }
                    }
                }

                // Detect face in uploaded image
                var uploadedFace = DetectFace(uploadedImage);
                if (uploadedFace == null)
                {
                    uploadedImage?.Dispose();
                    return Result<Guid?>.Failure("No face detected in the uploaded image");
                }

                // Train recognizer with existing images
                var trainingImages = new List<Mat>();
                var trainingLabels = new List<int>();
                var fileToLabelMap = new Dictionary<string, int>();
                
                int label = 0;
                foreach (var file in imageFiles)
                {
                    try
                    {
                        using (var img = Cv2.ImRead(file, ImreadModes.Color))
                        {
                            var face = DetectFace(img);
                            
                            if (face != null)
                            {
                                trainingImages.Add(face);
                                trainingLabels.Add(label);
                                fileToLabelMap[file] = label;
                                label++;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        _logger.LogWarning(ex, "Error processing image file: {File}", file);
                    }
                }

                if (trainingImages.Count == 0)
                {
                    uploadedImage?.Dispose();
                    uploadedFace?.Dispose();
                    return Result<Guid?>.Success(null); // No faces found in training images
                }

                try
                {
                    // Train the recognizer
                    _recognizer.Train(trainingImages, trainingLabels.ToArray());
                    
                    // Predict
                    _recognizer.Predict(uploadedFace, out int predictedLabel, out double distance);
                    
                    // Lower distance means better match (in LBPH)
                    if (distance <= _similarityThreshold)
                    {
                        // Find the file that matches the predicted label
                        var matchedFile = fileToLabelMap.FirstOrDefault(x => x.Value == predictedLabel).Key;
                        
                        if (matchedFile != null)
                        {
                            // Extract report ID from filename (assuming format: reportId.extension)
                            var fileName = Path.GetFileNameWithoutExtension(matchedFile);
                            if (Guid.TryParse(fileName, out Guid reportId))
                            {
                                _logger.LogInformation("Face match found. Report ID: {ReportId}, Confidence: {Distance}", reportId, distance);
                                return Result<Guid?>.Success(reportId);
                            }
                        }
                    }
                    
                    // No match found
                    return Result<Guid?>.Success(null);
                }
                finally
                {
                    // Clean up resources
                    uploadedImage?.Dispose();
                    uploadedFace?.Dispose();
                    
                    foreach (var img in trainingImages)
                    {
                        img?.Dispose();
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error during face recognition");
                return Result<Guid?>.Failure($"Face recognition error: {ex.Message}");
            }
        }

        private Mat DetectFace(Mat image)
        {
            if (image == null || image.Empty())
            {
                _logger.LogWarning("Received null or empty image for face detection");
                return null;
            }
            
            try
            {
                // Convert to grayscale
                using (var grayImage = new Mat())
                {
                    Cv2.CvtColor(image, grayImage, ColorConversionCodes.BGR2GRAY);
                    
                    // Apply histogram equalization to improve contrast
                    Cv2.EqualizeHist(grayImage, grayImage);
                    
                    // Detect faces
                    var faces = _faceDetector.DetectMultiScale(
                        grayImage,
                        1.1,  // Scale factor
                        5,    // Min neighbors
                        HaarDetectionTypes.DoCannyPruning,
                        new Size(30, 30)  // Min face size
                    );
                    
                    if (faces != null && faces.Length > 0)
                    {
                        // Get the largest face
                        var largestFace = faces[0];
                        var largestArea = largestFace.Width * largestFace.Height;
                        
                        foreach (var face in faces)
                        {
                            var area = face.Width * face.Height;
                            if (area > largestArea)
                            {
                                largestFace = face;
                                largestArea = area;
                            }
                        }
                        
                        // Validate face rectangle
                        if (largestFace.X >= 0 && largestFace.Y >= 0 && 
                            largestFace.Width > 20 && largestFace.Height > 20 && 
                            largestFace.X + largestFace.Width <= grayImage.Width && 
                            largestFace.Y + largestFace.Height <= grayImage.Height)
                        {
                            // Extract face region
                            using (var faceRegion = new Mat(grayImage, largestFace))
                            {
                                // Create a new Mat for the resized face
                                var resizedFace = new Mat();
                                Cv2.Resize(faceRegion, resizedFace, new Size(100, 100));
                                
                                return resizedFace;
                            }
                        }
                    }
                }
                
                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in face detection: {Message}", ex.Message);
                return null;
            }
        }
    }
}