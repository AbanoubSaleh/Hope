using FluentValidation;
using Hope.Domain.Enums;
using Hope.Resources;
using Microsoft.AspNetCore.Http;
using System;

namespace Hope.Application.MissingPerson.Commands.CreateMissingPersonReport
{
    public class CreateMissingPersonReportCommandValidator : AbstractValidator<CreateMissingPersonReportCommand>
    {
        public CreateMissingPersonReportCommandValidator()
        {
            // Always validate report information
            RuleFor(x => x.PhoneNumber)
                .NotEmpty().WithMessage(Messages.PhoneNumberRequired)
                .Matches(@"^\+?[0-9]{10,15}$").WithMessage("Phone number must be between 10 and 15 digits");

            RuleFor(x => x.IncidentTime)
                .NotEmpty().WithMessage("Incident time is required")
                .LessThanOrEqualTo(DateTime.UtcNow).WithMessage("Incident time cannot be in the future");

            RuleFor(x => x.CenterId)
                .NotEmpty().WithMessage("Center is required");

            RuleFor(x => x.GovernmentId)
                .NotEmpty().WithMessage(Messages.GovernmentIdRequired);
                
            // Conditionally validate missing person information when report is about a person
            When(x => x.ReportSubjectType == ReportSubjectType.Person, () => {
                RuleFor(x => x.PersonName)
                    .NotEmpty().WithMessage("Missing person name is required")
                    .MaximumLength(100).WithMessage("Name cannot exceed 100 characters");
                    
                RuleFor(x => x.Gender)
                    .NotNull().WithMessage("Gender is required");
                    
                RuleFor(x => x.Age)
                    .NotNull().WithMessage("Age is required")
                    .GreaterThanOrEqualTo(0).WithMessage("Age must be a positive number")
                    .LessThanOrEqualTo(120).WithMessage("Age cannot exceed 120 years");
                    
                RuleFor(x => x.Description)
                    .NotEmpty().WithMessage("Description is required")
                    .MaximumLength(1000).WithMessage("Description cannot exceed 1000 characters");
                    
                RuleFor(x => x.State)
                    .NotNull().WithMessage("State is required");
            });
            
            // Conditionally validate missing thing information when report is about a thing
            When(x => x.ReportSubjectType == ReportSubjectType.Thing, () => {
                RuleFor(x => x.ThingType)
                    .NotEmpty().WithMessage("Missing thing type is required")
                    .MaximumLength(100).WithMessage("Type cannot exceed 100 characters");
                    
                RuleFor(x => x.ThingDescription)
                    .NotEmpty().WithMessage("Description is required")
                    .MaximumLength(1000).WithMessage("Description cannot exceed 1000 characters");
                    
                RuleFor(x => x.ThingState)
                    .NotNull().WithMessage("State is required");
            });
            
            // Validate images if provided
            RuleForEach(x => x.Images)
                .SetValidator(new FileValidator())
                .When(x => x.Images != null && x.Images.Count > 0);
        }
    }
    
    public class FileValidator : AbstractValidator<IFormFile>
    {
        public FileValidator()
        {
            RuleFor(x => x.Length)
                .NotNull()
                .LessThanOrEqualTo(10 * 1024 * 1024)
                .WithMessage("File size is larger than allowed (10MB)");
                
            RuleFor(x => x.ContentType)
                .Must(x => x.Equals("image/jpeg") || x.Equals("image/jpg") || x.Equals("image/png"))
                .WithMessage("File type not allowed. Only JPEG and PNG are supported.");
        }
    }
}