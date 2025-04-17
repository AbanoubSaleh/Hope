using Hope.Application.Common.Interfaces;
using Hope.Application.Common.Models;
using Hope.Application.MissingPerson.DTOs;
using MediatR;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Hope.Application.MissingPerson.Commands.UpdateMissingPersonReport
{
    public class UpdateMissingPersonReportCommandHandler : IRequestHandler<UpdateMissingPersonReportCommand, Result<bool>>
    {
        private readonly IMissingPersonService _missingPersonService;
        private readonly IFileStorageService _fileStorageService;

        public UpdateMissingPersonReportCommandHandler(
            IMissingPersonService missingPersonService,
            IFileStorageService fileStorageService)
        {
            _missingPersonService = missingPersonService;
            _fileStorageService = fileStorageService;
        }

        public async Task<Result<bool>> Handle(UpdateMissingPersonReportCommand request, CancellationToken cancellationToken)
        {
            try
            {
                // Create the DTO without image first
                var updateDto = new UpdateReportDto
                {
                    ReportId = request.ReportId,
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
                    
                    // No image yet
                    Image = null
                };
                
                // Update the report first
                var result = await _missingPersonService.UpdateReportAsync(updateDto);
                
                if (!result.Succeeded)
                {
                    return result;
                }
                
                // Now save the new image if provided
                if (request.Image != null)
                {
                    string folderName = request.ReportSubjectType == Hope.Domain.Enums.ReportSubjectType.Person 
                        ? "missing-persons" 
                        : "missing-things";
                    
                    // Set custom filename with just the report ID and extension
                    string customFilename = $"{request.ReportId}{Path.GetExtension(request.Image.FileName)}";
                    
                    var fileResult = await _fileStorageService.SaveFileAsync(
                        request.Image, 
                        folderName,
                        customFilename);
                        
                    if (fileResult.Succeeded)
                    {
                        var imageDto = new ImageDto 
                        { 
                            Path = fileResult.Data, 
                            IsForPerson = request.ReportSubjectType == Hope.Domain.Enums.ReportSubjectType.Person 
                        };
                        
                        // Update the report with the image
                        await _missingPersonService.UpdateReportImageAsync(request.ReportId, imageDto);
                    }
                }
                
                return Result<bool>.Success(true);
            }
            catch (Exception ex)
            {
                return Result<bool>.Failure($"Error updating report: {ex.Message}");
            }
        }
    }
}