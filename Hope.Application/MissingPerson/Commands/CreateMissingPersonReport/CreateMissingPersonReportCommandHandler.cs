using Hope.Application.Common.Interfaces;
using Hope.Application.Common.Models;
using Hope.Application.MissingPerson.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Hope.Application.MissingPerson.Commands.CreateMissingPersonReport
{
    public class CreateMissingPersonReportCommandHandler : IRequestHandler<CreateMissingPersonReportCommand, Result<Guid>>
    {
        private readonly IMissingPersonService _missingPersonService;
        private readonly IFileStorageService _fileStorageService;

        public CreateMissingPersonReportCommandHandler(
            IMissingPersonService missingPersonService,
            IFileStorageService fileStorageService)
        {
            _missingPersonService = missingPersonService;
            _fileStorageService = fileStorageService;
        }

        public async Task<Result<Guid>> Handle(CreateMissingPersonReportCommand request, CancellationToken cancellationToken)
        {
            try
            {
                // Create the DTO without images first
                var reportDto = new CreateReportDto
                {
                    PhoneNumber = request.PhoneNumber,
                    IncidentTime = request.IncidentTime,
                    ReportType = request.ReportType,
                    ReportSubjectType = request.ReportSubjectType,
                    CenterId = request.CenterId,
                    GovernmentId = request.GovernmentId,
                    
                    // Person details
                    PersonName = request.PersonName,
                    Gender = request.Gender,
                    Age = request.Age,
                    PersonDescription = request.Description,
                    PersonState = request.State,
                    
                    // Thing details
                    ThingType = request.ThingType,
                    ThingDescription = request.ThingDescription,
                    ThingState = request.ThingState,
                    
                    // No images yet
                    Images = null
                };
                
                // Create the report first to get the ID
                var result = await _missingPersonService.CreateCompleteReportAsync(reportDto);
                
                if (!result.Succeeded)
                {
                    return result;
                }
                
                var reportId = result.Data;
                var savedImages = new List<ImageDto>();
                
                // Now save the single image with report ID in the filename
                if (request.Images != null && request.Images.Count > 0)
                {
                    string folderName = request.ReportSubjectType == Hope.Domain.Enums.ReportSubjectType.Person 
                        ? "missing-persons" 
                        : "missing-things";
                    
                    // Get the first image only
                    var image = request.Images[0];
                    
                    // Set custom filename with just the report ID and extension
                    string customFilename = $"{reportId}{Path.GetExtension(image.FileName)}";
                    
                    var fileResult = await _fileStorageService.SaveFileAsync(
                        image, 
                        folderName,
                        customFilename);
                        
                    if (fileResult.Succeeded)
                    {
                        savedImages.Add(new ImageDto 
                        { 
                            Path = fileResult.Data, 
                            IsForPerson = request.ReportSubjectType == Hope.Domain.Enums.ReportSubjectType.Person 
                        });
                        
                        // Update the report with the image
                        await _missingPersonService.UpdateReportImagesAsync(reportId, savedImages);
                    }
                }
                
                return result;
            }
            catch (Exception ex)
            {
                return Result<Guid>.Failure($"Error creating report: {ex.Message}");
            }
        }
    }
}