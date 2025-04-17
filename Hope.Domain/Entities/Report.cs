using Hope.Domain.Enums;
using System;

namespace Hope.Domain.Entities
{
    public class Report
    {
        // Private constructor to enforce creation through factory methods
        private Report() { }
        
        public Guid Id { get; private set; }
        public string PhoneNumber { get; private set; } = null!;
        public DateTime IncidentTime { get; private set; }
        public DateTime ReportTime { get; private set; }
        public ReportType ReportType { get; private set; }
        public ReportSubjectType ReportSubjectType { get; private set; }
        // Add these properties to your Report entity
        public bool IsHidden { get; set; } = false;
        public bool IsDeleted { get; set; } = false;
        public DateTime? DeletedAt { get; set; }

        // Foreign keys
        public Guid CenterId { get; private set; }
        public int GovernmentId { get; private set; }
        public string? UserId { get; private set; } // Added UserId property
        
        // Navigation properties
        public Center Center { get; set; } = null!;
        public Government Government { get; set; } = null!;
        public MissingPerson? MissingPerson { get; private set; }
        public MissingThing? MissingThing { get; private set; }
        public ApplicationUser? User { get; set; } // Added User navigation property
        
        // Factory method to create a new report
        public static Report Create(
            string phoneNumber,
            DateTime incidentTime,
            ReportType reportType,
            ReportSubjectType subjectType,
            Guid centerId,
            int governmentId,
            string? userId = null) // Added optional userId parameter
        {
            if (string.IsNullOrWhiteSpace(phoneNumber))
                throw new ArgumentException("Phone number cannot be empty", nameof(phoneNumber));
                
            if (incidentTime > DateTime.UtcNow)
                throw new ArgumentException("Incident time cannot be in the future", nameof(incidentTime));
                
            if (centerId == Guid.Empty)
                throw new ArgumentException("Center ID cannot be empty", nameof(centerId));
                
            if (governmentId <= 0)
                throw new ArgumentException("Government ID must be a positive number", nameof(governmentId));
                
            return new Report
            {
                Id = Guid.NewGuid(),
                PhoneNumber = phoneNumber,
                IncidentTime = incidentTime,
                ReportTime = DateTime.UtcNow,
                ReportType = reportType,
                ReportSubjectType = subjectType,
                CenterId = centerId,
                GovernmentId = governmentId,
                UserId = userId // Set the UserId
            };
        }
        
        // Method to add a missing person to this report
        public void AddMissingPerson(MissingPerson missingPerson)
        {
            if (ReportSubjectType != ReportSubjectType.Person)
                throw new InvalidOperationException("Cannot add a missing person to a non-person report");
                
            if (MissingPerson != null)
                throw new InvalidOperationException("This report already has a missing person");
                
            MissingPerson = missingPerson ?? throw new ArgumentNullException(nameof(missingPerson));
        }
        
        // Method to add a missing thing to this report
        public void AddMissingThing(MissingThing missingThing)
        {
            if (ReportSubjectType != ReportSubjectType.Thing)
                throw new InvalidOperationException("Cannot add a missing thing to a non-thing report");
                
            if (MissingThing != null)
                throw new InvalidOperationException("This report already has a missing thing");
                
            MissingThing = missingThing ?? throw new ArgumentNullException(nameof(missingThing));
        }

        public void UpdateReportDetails(
            string phoneNumber,
            DateTime incidentTime,
            ReportType reportType,
            Guid centerId,
            int governmentId)
        {
            if (string.IsNullOrWhiteSpace(phoneNumber))
                throw new ArgumentException("Phone number cannot be empty", nameof(phoneNumber));
                
            if (incidentTime > DateTime.UtcNow)
                throw new ArgumentException("Incident time cannot be in the future", nameof(incidentTime));
                
            if (centerId == Guid.Empty)
                throw new ArgumentException("Center ID cannot be empty", nameof(centerId));
                
            if (governmentId <= 0)
                throw new ArgumentException("Government ID must be a positive number", nameof(governmentId));
            
            PhoneNumber = phoneNumber;
            IncidentTime = incidentTime;
            ReportType = reportType;
            CenterId = centerId;
            GovernmentId = governmentId;
            UpdatedAt = DateTime.UtcNow;
        }

        // Add UpdatedAt property
        public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
    }
}