using Hope.Application.Common.Models;
using Hope.Domain.Entities;
using MediatR;
using System;

namespace Hope.Application.MissingPerson.Queries.GetReportById
{
    public class GetReportByIdQuery : IRequest<Result<Report>>
    {
        public Guid ReportId { get; set; }
    }
}