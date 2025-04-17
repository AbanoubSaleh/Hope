using Hope.Application.Common.Models;
using Hope.Application.MissingPerson.DTOs;
using Hope.Domain.Enums;
using MediatR;

namespace Hope.Application.MissingPerson.Queries.GetReports
{
    public class GetReportsQuery : IRequest<Result<PaginatedList<ReportDto>>>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public ReportSubjectType? ReportSubjectType { get; set; }
        public bool IncludeComments { get; set; } = false;
    }
}