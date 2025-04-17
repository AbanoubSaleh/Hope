using FluentValidation;
using Hope.Domain.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;

namespace Hope.Application.MissingPerson.Commands.UpdateMissingPersonReport
{
    public class UpdateMissingPersonReportCommandValidator : AbstractValidator<UpdateMissingPersonReportCommand>
    {
        public UpdateMissingPersonReportCommandValidator()
        {
            RuleFor(x => x.ReportId)
                .NotEmpty().WithMessage("Report ID is required");
                
            RuleFor(x => x.PhoneNumber)
                .NotEmpty().WithMessage("Phone number is required")
                .Matches(@"^01[0125][0-9]{8}$").WithMessage("Phone number must be a valid Egyptian mobile number");

            RuleFor(x => x.IncidentTime)
                .NotEmpty().WithMessage("Incident time is required")
                .LessThanOrEqualTo(DateTime.UtcNow).WithMessage("Incident time cannot be in the future");

            RuleFor(x => x.ReportType)
                .IsInEnum().WithMessage("Invalid report type");

            RuleFor(x => x.ReportSubjectType)
                .IsInEnum().WithMessage("Invalid report subject type");

            RuleFor(x => x.CenterId)
                .NotEmpty().WithMessage("Center ID is required");

            RuleFor(x => x.GovernmentId)
                .GreaterThan(0).WithMessage("Government ID must be greater than 0");

            // Conditional validation for person reports
            When(x => x.ReportSubjectType == ReportSubjectType.Person, () =>
            {
                RuleFor(x => x.PersonName)
                    .NotEmpty().WithMessage("Person name is required for person reports");

                RuleFor(x => x.Gender)
                    .NotNull().WithMessage("Gender is required for person reports")
                    .IsInEnum().WithMessage("Invalid gender");

                RuleFor(x => x.Age)
                    .NotNull().WithMessage("Age is required for person reports")
                    .GreaterThan(0).WithMessage("Age must be greater than 0");

                RuleFor(x => x.Description)
                    .NotEmpty().WithMessage("Description is required for person reports");

                RuleFor(x => x.State)
                    .NotNull().WithMessage("State is required for person reports")
                    .IsInEnum().WithMessage("Invalid state");
            });

            // Conditional validation for thing reports
            When(x => x.ReportSubjectType == ReportSubjectType.Thing, () =>
            {
                RuleFor(x => x.ThingType)
                    .NotEmpty().WithMessage("Thing type is required for thing reports");

                RuleFor(x => x.ThingDescription)
                    .NotEmpty().WithMessage("Thing description is required for thing reports");

                RuleFor(x => x.ThingState)
                    .NotNull().WithMessage("Thing state is required for thing reports")
                    .IsInEnum().WithMessage("Invalid thing state");
            });

            // Image validation
            RuleFor(x => x.Image)
                .Must(BeValidImage).When(x => x.Image != null)
                .WithMessage("Invalid image format. Only JPG, JPEG, PNG, and GIF are allowed with max size of 5MB");
        }

        private bool BeValidImage(IFormFile? image)
        {
            if (image == null)
                return true;

            // Check file size (5MB max)
            if (image.Length > 5 * 1024 * 1024)
                return false;

            // Check file extension
            var extension = Path.GetExtension(image.FileName).ToLowerInvariant();
            return extension == ".jpg" || extension == ".jpeg" || extension == ".png" || extension == ".gif";
        }
    }
}