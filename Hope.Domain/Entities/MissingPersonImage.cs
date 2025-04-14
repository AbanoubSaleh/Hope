using System;

namespace Hope.Domain.Entities
{
    public class MissingPersonImage
    {
        public Guid Id { get; set; }
        public string ImagePath { get; set; } = null!;
        
        // Foreign key
        public Guid MissingPersonId { get; set; }
        
        // Navigation property
        public MissingPerson MissingPerson { get; set; } = null!;
    }
}