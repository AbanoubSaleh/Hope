using Hope.Application.Common.Models;
using Hope.Application.MissingPerson.DTOs;
using Hope.Domain.Entities;
using MediatR;
using System;

namespace Hope.Application.MissingPerson.Queries.GetReportById
{
    public class GetReportByIdQuery : IRequest<Result<ReportDto>>
    {
        public Guid ReportId { get; set; }
    }
}