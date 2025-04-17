using Hope.Application.Common.Models;
using Hope.Application.MissingPerson.DTOs;
using Hope.Domain.Enums;
using MediatR;

namespace Hope.Application.MissingPerson.Queries.GetReportsByMissingState
{
    public class GetReportsByMissingStateQuery : IRequest<Result<PaginatedList<ReportDto>>>
    {
        public MissingState? MissingState { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public bool IncludeComments { get; set; } = false;
    }
}