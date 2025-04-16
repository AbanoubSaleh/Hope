using Hope.Application.Common.Models;
using Hope.Application.MissingPerson.DTOs;
using Hope.Domain.Entities;
using Hope.Domain.Enums;
using MediatR;
using System.Collections.Generic;

namespace Hope.Application.MissingPerson.Queries.GetReports
{
    public class GetReportsQuery : IRequest<Result<IEnumerable<ReportDto>>>
    {
        public ReportSubjectType? ReportSubjectType { get; set; }
    }
}