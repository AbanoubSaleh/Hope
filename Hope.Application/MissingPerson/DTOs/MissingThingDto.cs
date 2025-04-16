namespace Hope.Application.MissingPerson.DTOs;

public class MissingThingDto
{
    public Guid Id { get;  set; }
    public string Type { get;  set; } = null!;
    public string Description { get;  set; } = null!;
    public static MissingThingDto FromEntity(Hope.Domain.Entities.MissingThing thing)
    {
        return new MissingThingDto
        {
            Id = thing.Id,
            Type = thing.Type,
            Description = thing.Description
        };
    }
}
