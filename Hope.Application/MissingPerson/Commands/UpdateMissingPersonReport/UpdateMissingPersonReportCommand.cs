using Hope.Application.Common.Models;
using Hope.Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;

namespace Hope.Application.MissingPerson.Commands.UpdateMissingPersonReport
{
    public class UpdateMissingPersonReportCommand : IRequest<Result<bool>>
    {
        // Report ID to update
        public Guid ReportId { get; set; }
        
        // Report information
        public string PhoneNumber { get; set; } = null!;
        public DateTime IncidentTime { get; set; }
        public ReportType ReportType { get; set; }
        public ReportSubjectType ReportSubjectType { get; set; }
        public Guid CenterId { get; set; }
        public int GovernmentId { get; set; }
        
        // Missing person information (optional based on report type)
        public string? PersonName { get; set; }
        public Gender? Gender { get; set; }
        public int? Age { get; set; }
        public string? Description { get; set; }
        public MissingState? State { get; set; }
        
        // Missing thing information (optional based on report type)
        public string? ThingType { get; set; }
        public string? ThingDescription { get; set; }
        public MissingState? ThingState { get; set; }
        
        // New image (optional)
        public IFormFile? Image { get; set; }
    }
}