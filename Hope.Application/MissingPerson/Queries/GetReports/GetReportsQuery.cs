using Hope.Application.Common.Models;
using Hope.Domain.Entities;
using Hope.Domain.Enums;
using MediatR;
using System.Collections.Generic;

namespace Hope.Application.MissingPerson.Queries.GetReports
{
    public class GetReportsQuery : IRequest<Result<IEnumerable<Report>>>
    {
        public ReportType? ReportType { get; set; }
        public ReportSubjectType? ReportSubjectType { get; set; }
    }
}