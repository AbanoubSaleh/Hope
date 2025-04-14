using Hope.Application.Common.Models;
using Hope.Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;

namespace Hope.Application.MissingPerson.Commands.CreateMissingPersonReport
{
    public class CreateMissingPersonReportCommand : IRequest<Result<Guid>>
    {
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
        
        // Images (optional)
        public List<IFormFile>? Images { get; set; }
    }
}