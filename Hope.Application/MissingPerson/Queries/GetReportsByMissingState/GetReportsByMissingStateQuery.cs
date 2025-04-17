using Hope.Application.Common.Models;
using Hope.Application.MissingPerson.DTOs;
using Hope.Domain.Enums;
using MediatR;
using System.Collections.Generic;

namespace Hope.Application.MissingPerson.Queries.GetReportsByMissingState
{
    public class GetReportsByMissingStateQuery : IRequest<Result<IEnumerable<ReportDto>>>
    {
        public MissingState? MissingState { get; set; }
    }
}