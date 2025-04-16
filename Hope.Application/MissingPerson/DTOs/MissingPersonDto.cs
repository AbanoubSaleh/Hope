using Hope.Domain.Enums;

namespace Hope.Application.MissingPerson.DTOs;

public class MissingPersonDto
{
    public Guid Id { get;  set; }
    public string Name { get;  set; } = null!;
    public Gender Gender { get;  set; }
    public int Age { get;  set; }
    public string Description { get;  set; } = null!;
    public MissingState State { get;  set; }
    public static MissingPersonDto FromEntity(Hope.Domain.Entities.MissingPerson person)
    {
        return new MissingPersonDto
        {
            Id = person.Id,
            Name = person.Name,
            Gender = person.Gender,
            Age = person.Age,
            Description = person.Description,
            State = person.State
        };
    }
}
