using Hope.Application.Common.Interfaces;
using Hope.Application.Common.Models;
using Hope.Application.MissingPerson.DTOs;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Hope.Application.MissingPerson.Queries.GetReports
{
    public class GetReportsQueryHandler : IRequestHandler<GetReportsQuery, Result<PaginatedList<ReportDto>>>
    {
        private readonly IMissingPersonService _missingPersonService;

        public GetReportsQueryHandler(IMissingPersonService missingPersonService)
        {
            _missingPersonService = missingPersonService;
        }

        public async Task<Result<PaginatedList<ReportDto>>> Handle(GetReportsQuery request, CancellationToken cancellationToken)
        {
            return await _missingPersonService.GetReportsAsync(
                request.PageNumber,
                request.PageSize,
                request.ReportSubjectType,
                request.IncludeComments);
        }
    }
}