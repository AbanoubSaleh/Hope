using Hope.Domain.Enums;
using System;
using System.Collections.Generic;

namespace Hope.Domain.Entities
{
    public class MissingThing
    {
        // Private constructor to enforce creation through factory methods
        private MissingThing() { }
        
        public Guid Id { get; private set; }
        public string Type { get; private set; } = null!;
        public string Description { get; private set; } = null!;        
        // Foreign key
        public Guid ReportId { get; private set; }
        
        // Navigation properties
        public Report Report { get; set; } = null!;
        public ICollection<MissingThingImage> Images { get; private set; } = new List<MissingThingImage>();
        
        // Factory method to create a new missing thing
        public static MissingThing Create(
            string type,
            string description,
            MissingState state,
            Guid reportId)
        {
            if (string.IsNullOrWhiteSpace(type))
                throw new ArgumentException("Type cannot be empty", nameof(type));
                
            if (string.IsNullOrWhiteSpace(description))
                throw new ArgumentException("Description cannot be empty", nameof(description));
                
            if (reportId == Guid.Empty)
                throw new ArgumentException("Report ID cannot be empty", nameof(reportId));
                
            return new MissingThing
            {
                Id = Guid.NewGuid(),
                Type = type,
                Description = description,
                ReportId = reportId
            };
        }
        
        // Method to add an image to this missing thing
        public void AddImage(string imagePath)
        {
            if (string.IsNullOrWhiteSpace(imagePath))
                throw new ArgumentException("Image path cannot be empty", nameof(imagePath));
                
            var image = new MissingThingImage
            {
                Id = Guid.NewGuid(),
                ImagePath = imagePath,
                MissingThingId = Id
            };
            
            Images.Add(image);
        }
    }
}