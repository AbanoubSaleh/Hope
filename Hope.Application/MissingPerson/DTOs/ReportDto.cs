using Hope.Application.Comments.DTOs;
using Hope.Application.LookUps.Dtos;
using Hope.Domain.Entities;
using Hope.Domain.Enums;

namespace Hope.Application.MissingPerson.DTOs;

public class ReportDto
{
    public Guid Id { get;  set; }
    public string PhoneNumber { get;  set; } = null!;
    public DateTime IncidentTime { get;  set; }
    public DateTime ReportTime { get;  set; }
    public ReportType ReportType { get;  set; }
    public ReportSubjectType ReportSubjectType { get;  set; }

    // Navigation properties
    public CenterDto Center { get; set; } = null!;
    public GovernmentDto Government { get; set; } = null!;
    public MissingPersonDto? MissingPerson { get;  set; }
    public MissingThingDto? MissingThing { get;  set; }
    public string ? CreatedBy { get; set; }
    public bool IsHidden { get; set; } = false;

    // Add this property to the existing ReportDto class
    public List<CommentDto> Comments { get; set; } = new List<CommentDto>();

    public static ReportDto FromEntity(Report report)
    {
        return new ReportDto
        {
            Id = report.Id,
            PhoneNumber = report.PhoneNumber,
            IncidentTime = report.IncidentTime,
            ReportTime = report.ReportTime,
            ReportType = report.ReportType,
            ReportSubjectType = report.ReportSubjectType,
            Center = CenterDto.FromEntity(report.Center),
            Government = GovernmentDto.FromEntity(report.Government),
            MissingPerson = report.MissingPerson != null ? MissingPersonDto.FromEntity(report.MissingPerson) : null,
            MissingThing = report.MissingThing != null ? MissingThingDto.FromEntity(report.MissingThing) : null,
            CreatedBy = report.User != null ? report.User.UserName : null,
            IsHidden=report.IsHidden

        };
    }
}
