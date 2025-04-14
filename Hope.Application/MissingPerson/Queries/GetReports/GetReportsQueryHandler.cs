using Hope.Application.Common.Interfaces;
using Hope.Application.Common.Models;
using Hope.Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Hope.Application.MissingPerson.Queries.GetReports
{
    public class GetReportsQueryHandler : IRequestHandler<GetReportsQuery, Result<IEnumerable<Report>>>
    {
        private readonly IMissingPersonService _missingPersonService;

        public GetReportsQueryHandler(IMissingPersonService missingPersonService)
        {
            _missingPersonService = missingPersonService;
        }

        public async Task<Result<IEnumerable<Report>>> Handle(GetReportsQuery request, CancellationToken cancellationToken)
        {
            return await _missingPersonService.GetReportsAsync(
                request.ReportType,
                request.ReportSubjectType);
        }
    }
}