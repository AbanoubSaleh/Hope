using Hope.Application.Common.Models;
using MediatR;
using System;

namespace Hope.Application.MissingPerson.Commands.HideReport
{
    public class HideReportCommand : IRequest<Result<bool>>
    {
        public Guid ReportId { get; set; }
    }
}