using Hope.Domain.Enums;
using System;
using System.Collections.Generic;

namespace Hope.Domain.Entities
{
    public class MissingPerson
    {
        // Private constructor to enforce creation through factory methods
        private MissingPerson() { }
        
        public Guid Id { get; private set; }
        public string Name { get; private set; } = null!;
        public Gender Gender { get; private set; }
        public int Age { get; private set; }
        public string Description { get; private set; } = null!;
        public MissingState State { get; private set; }
        public DateTime? UpdatedAt { get; private set; }

        // Foreign key
        public Guid ReportId { get; private set; }
        
        // Navigation properties
        public Report Report { get; set; } = null!;
        public ICollection<MissingPersonImage> Images { get; private set; } = new List<MissingPersonImage>();
        
        // Factory method to create a new missing person
        public static MissingPerson Create(
            string name,
            Gender gender,
            int age,
            string description,
            MissingState state,
            Guid reportId)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name cannot be empty", nameof(name));
                
            if (age < 0 || age > 120)
                throw new ArgumentException("Age must be between 0 and 120", nameof(age));
                
            if (string.IsNullOrWhiteSpace(description))
                throw new ArgumentException("Description cannot be empty", nameof(description));
                
            if (reportId == Guid.Empty)
                throw new ArgumentException("Report ID cannot be empty", nameof(reportId));
                
            return new MissingPerson
            {
                Id = Guid.NewGuid(),
                Name = name,
                Gender = gender,
                Age = age,
                Description = description,
                State = state,
                ReportId = reportId
            };
        }
        
        // Method to add an image to this missing person
        public void AddImage(string imagePath)
        {
            if (string.IsNullOrWhiteSpace(imagePath))
                throw new ArgumentException("Image path cannot be empty", nameof(imagePath));
                
            var image = new MissingPersonImage
            {
                Id = Guid.NewGuid(),
                ImagePath = imagePath,
                MissingPersonId = Id
            };
            
            Images.Add(image);
        }
        
        // Add this method to the MissingPerson class
        public void UpdateDetails(
            string name,
            Gender gender,
            int age,
            string description,
            MissingState state)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name cannot be empty", nameof(name));
                
            if (age <= 0)
                throw new ArgumentException("Age must be a positive number", nameof(age));
                
            if (string.IsNullOrWhiteSpace(description))
                throw new ArgumentException("Description cannot be empty", nameof(description));
            
            Name = name;
            Gender = gender;
            Age = age;
            Description = description;
            State = state;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}