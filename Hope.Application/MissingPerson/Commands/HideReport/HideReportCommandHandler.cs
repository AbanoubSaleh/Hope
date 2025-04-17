using Hope.Application.Common.Interfaces;
using Hope.Application.Common.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Hope.Application.MissingPerson.Commands.HideReport
{
    public class HideReportCommandHandler : IRequestHandler<HideReportCommand, Result<bool>>
    {
        private readonly IMissingPersonService _missingPersonService;

        public HideReportCommandHandler(IMissingPersonService missingPersonService)
        {
            _missingPersonService = missingPersonService;
        }

        public async Task<Result<bool>> Handle(HideReportCommand request, CancellationToken cancellationToken)
        {
            return await _missingPersonService.HideReportAsync(request.ReportId);
        }
    }
}