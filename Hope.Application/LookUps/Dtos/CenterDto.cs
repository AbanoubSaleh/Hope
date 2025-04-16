using Hope.Domain.Entities;

namespace Hope.Application.LookUps.Dtos;

public class CenterDto
{
    public Guid Id { get; set; }
    public string NameEn { get; set; } = null!;
    public string NameAr { get; set; } = null!;
    public static CenterDto FromEntity(Center center)
    {
        return new CenterDto
        {
            Id = center.Id,
            NameEn = center.NameEn,
            NameAr = center.NameAr
        };
    }
}
