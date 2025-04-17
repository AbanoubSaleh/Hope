namespace Hope.Application.MissingPerson.DTOs;

public class MissingThingDto
{
    public Guid Id { get;  set; }
    public string Type { get;  set; } = null!;
    public string Description { get;  set; } = null!;
    public string ImagePath { get; set; } = null!;

    public static MissingThingDto FromEntity(Hope.Domain.Entities.MissingThing thing)
    {
        return new MissingThingDto
        {
            Id = thing.Id,
            Type = thing.Type,
            Description = thing.Description,
            ImagePath = thing.Images.Count > 0 ? thing.Images.First().ImagePath : string.Empty
        };
    }
}
