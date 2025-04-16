using Hope.Application.Common.Interfaces;
using Hope.Application.Common.Models;
using Hope.Application.MissingPerson.DTOs;
using Hope.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Hope.Application.MissingPerson.Queries.GetReportById
{
    public class GetReportByIdQueryHandler : IRequestHandler<GetReportByIdQuery, Result<ReportDto>>
    {
        private readonly IMissingPersonService _missingPersonService;

        public GetReportByIdQueryHandler(IMissingPersonService missingPersonService)
        {
            _missingPersonService = missingPersonService;
        }

        public async Task<Result<ReportDto>> Handle(GetReportByIdQuery request, CancellationToken cancellationToken)
        {
            return await _missingPersonService.GetReportByIdAsync(request.ReportId);
        }
    }
}