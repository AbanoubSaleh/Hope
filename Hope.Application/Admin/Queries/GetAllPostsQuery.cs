using Hope.Application.Common.Models;
using Hope.Application.MissingPerson.DTOs;
using MediatR;
using System.Collections.Generic;

namespace Hope.Application.Admin.Queries
{
    public class GetAllPostsQuery : IRequest<Result<IEnumerable<ReportDto>>>
    {
    }
}