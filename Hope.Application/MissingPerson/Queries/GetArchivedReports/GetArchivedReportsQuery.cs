using Hope.Application.Common.Models;
using Hope.Application.MissingPerson.DTOs;
using MediatR;

namespace Hope.Application.MissingPerson.Queries.GetArchivedReports
{
    public class GetArchivedReportsQuery : IRequest<Result<PaginatedList<ReportDto>>>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public bool IncludeComments { get; set; } = false;
    }
}