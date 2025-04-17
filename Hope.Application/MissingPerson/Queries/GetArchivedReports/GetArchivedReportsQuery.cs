using Hope.Application.Common.Models;
using Hope.Application.MissingPerson.DTOs;
using MediatR;
using System.Collections.Generic;

namespace Hope.Application.MissingPerson.Queries.GetArchivedReports
{
    public class GetArchivedReportsQuery : IRequest<Result<IEnumerable<ReportDto>>>
    {
    }
}