using Hope.Domain.Enums;
using System;
using System.Collections.Generic;

namespace Hope.Application.MissingPerson.DTOs
{
    public class CreateReportDto
    {
        // Report information
        public string PhoneNumber { get; set; } = null!;
        public DateTime IncidentTime { get; set; }
        public ReportType ReportType { get; set; }
        public ReportSubjectType ReportSubjectType { get; set; }
        public Guid CenterId { get; set; }
        public int GovernmentId { get; set; }
        
        // Missing person information (optional)
        public string? PersonName { get; set; }
        public Gender? Gender { get; set; }
        public int? Age { get; set; }
        public string? PersonDescription { get; set; }
        public MissingState? PersonState { get; set; }
        
        // Missing thing information (optional)
        public string? ThingType { get; set; }
        public string? ThingDescription { get; set; }
        public MissingState? ThingState { get; set; }
        
        // Images
        public List<ImageDto>? Images { get; set; }
    }

    public class ImageDto
    {
        public string Path { get; set; } = null!;
        public bool IsForPerson { get; set; }
    }
}