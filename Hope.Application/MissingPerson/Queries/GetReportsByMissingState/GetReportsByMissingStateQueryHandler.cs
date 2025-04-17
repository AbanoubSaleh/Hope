using Hope.Application.Common.Interfaces;
using Hope.Application.Common.Models;
using Hope.Application.MissingPerson.DTOs;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Hope.Application.MissingPerson.Queries.GetReportsByMissingState
{
    public class GetReportsByMissingStateQueryHandler : IRequestHandler<GetReportsByMissingStateQuery, Result<PaginatedList<ReportDto>>>
    {
        private readonly IMissingPersonService _missingPersonService;

        public GetReportsByMissingStateQueryHandler(IMissingPersonService missingPersonService)
        {
            _missingPersonService = missingPersonService;
        }

        public async Task<Result<PaginatedList<ReportDto>>> Handle(GetReportsByMissingStateQuery request, CancellationToken cancellationToken)
        {
            return await _missingPersonService.GetReportsByMissingStateAsync(
                request.MissingState,
                request.PageNumber,
                request.PageSize,
                request.IncludeComments);
        }
    }
}