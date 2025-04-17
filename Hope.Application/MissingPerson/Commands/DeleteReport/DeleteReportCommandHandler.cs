using Hope.Application.Common.Interfaces;
using Hope.Application.Common.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Hope.Application.MissingPerson.Commands.DeleteReport
{
    public class DeleteReportCommandHandler : IRequestHandler<DeleteReportCommand, Result<bool>>
    {
        private readonly IMissingPersonService _missingPersonService;

        public DeleteReportCommandHandler(IMissingPersonService missingPersonService)
        {
            _missingPersonService = missingPersonService;
        }

        public async Task<Result<bool>> Handle(DeleteReportCommand request, CancellationToken cancellationToken)
        {
            return await _missingPersonService.DeleteReportAsync(request.ReportId);
        }
    }
}