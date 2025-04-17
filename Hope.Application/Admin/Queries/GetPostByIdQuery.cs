using Hope.Application.Common.Models;
using Hope.Application.MissingPerson.DTOs;
using MediatR;
using System;

namespace Hope.Application.Admin.Queries
{
    public class GetPostByIdQuery : IRequest<Result<ReportDto>>
    {
        public Guid ReportId { get; set; }
    }
}