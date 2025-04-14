using System;

namespace Hope.Domain.Entities
{
    public class MissingThingImage
    {
        public Guid Id { get; set; }
        public string ImagePath { get; set; } = null!;
        
        // Foreign key
        public Guid MissingThingId { get; set; }
        
        // Navigation property
        public MissingThing MissingThing { get; set; } = null!;
    }
}