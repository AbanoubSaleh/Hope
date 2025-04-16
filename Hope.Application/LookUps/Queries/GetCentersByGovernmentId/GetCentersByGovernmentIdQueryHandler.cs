using Hope.Application.Common.Interfaces;
using Hope.Application.Common.Models;
using Hope.Application.LookUps.Dtos;
using MediatR;

namespace Hope.Application.LookUps.Queries.GetCentersByGovernmentId;

public class GetCentersByGovernmentIdQueryHandler : IRequestHandler<GetCentersByGovernmentIdQuery, Result<IEnumerable<CenterDto>>>
{
    private readonly IMissingPersonService _missingPersonService;

    public GetCentersByGovernmentIdQueryHandler(IMissingPersonService missingPersonService)
    {
        _missingPersonService = missingPersonService;
    }

    public async Task<Result<IEnumerable<CenterDto>>> Handle(GetCentersByGovernmentIdQuery request, CancellationToken cancellationToken)
    {
        return await _missingPersonService.GetCentersByGovernmentIdAsync(request.GovernmentId);
    }
}