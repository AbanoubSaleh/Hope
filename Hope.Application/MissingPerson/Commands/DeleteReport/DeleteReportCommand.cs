using Hope.Application.Common.Models;
using MediatR;
using System;

namespace Hope.Application.MissingPerson.Commands.DeleteReport
{
    public class DeleteReportCommand : IRequest<Result<bool>>
    {
        public Guid ReportId { get; set; }
    }
}