using Hope.Application.Common.Interfaces;
using Hope.Application.Common.Models;
using Hope.Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Hope.Application.LookUps.Queries.GetCentersByGovernmentId
{
    public class GetCentersByGovernmentIdQueryHandler : IRequestHandler<GetCentersByGovernmentIdQuery, Result<IEnumerable<Center>>>
    {
        private readonly IMissingPersonService _missingPersonService;

        public GetCentersByGovernmentIdQueryHandler(IMissingPersonService missingPersonService)
        {
            _missingPersonService = missingPersonService;
        }

        public async Task<Result<IEnumerable<Center>>> Handle(GetCentersByGovernmentIdQuery request, CancellationToken cancellationToken)
        {
            return await _missingPersonService.GetCentersByGovernmentIdAsync(request.GovernmentId);
        }
    }
}