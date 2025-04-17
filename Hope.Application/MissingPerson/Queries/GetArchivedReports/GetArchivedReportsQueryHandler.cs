using Hope.Application.Common.Interfaces;
using Hope.Application.Common.Models;
using Hope.Application.MissingPerson.DTOs;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Hope.Application.MissingPerson.Queries.GetArchivedReports
{
    public class GetArchivedReportsQueryHandler : IRequestHandler<GetArchivedReportsQuery, Result<IEnumerable<ReportDto>>>
    {
        private readonly IMissingPersonService _missingPersonService;

        public GetArchivedReportsQueryHandler(IMissingPersonService missingPersonService)
        {
            _missingPersonService = missingPersonService;
        }

        public async Task<Result<IEnumerable<ReportDto>>> Handle(GetArchivedReportsQuery request, CancellationToken cancellationToken)
        {
            return await _missingPersonService.GetArchivedReportsAsync();
        }
    }
}