using Hope.Application.Common.Interfaces;
using Hope.Application.Common.Models;
using Hope.Application.MissingPerson.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
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
                // Save images first if provided
                var savedImages = new List<ImageDto>();
                
                if (request.Images != null && request.Images.Count > 0)
                {
                    string folderName = request.ReportSubjectType == Hope.Domain.Enums.ReportSubjectType.Person 
                        ? "missing-persons" 
                        : "missing-things";
                    
                    foreach (var image in request.Images)
                    {
                        var fileResult = await _fileStorageService.SaveFileAsync(image, folderName);
                        if (fileResult.Succeeded)
                        {
                            savedImages.Add(new ImageDto 
                            { 
                                Path = fileResult.Data, 
                                IsForPerson = request.ReportSubjectType == Hope.Domain.Enums.ReportSubjectType.Person 
                            });
                        }
                    }
                }
                
                // Create the DTO
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
                    
                    // Images
                    Images = savedImages.Count > 0 ? savedImages : null
                };
                
                // Create the complete report using the DTO
                var result = await _missingPersonService.CreateCompleteReportAsync(reportDto);
                
                if (!result.Succeeded)
                {
                    // Clean up saved images if report creation failed
                    foreach (var image in savedImages)
                    {
                        await _fileStorageService.DeleteFileAsync(image.Path);
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