using Hope.Application.Common.Models;
using Hope.Application.MissingPerson.DTOs;
using MediatR;
using System.Collections.Generic;

namespace Hope.Application.Admin.Queries
{
    public class GetAllPostsQuery : IRequest<Result<PaginatedList<ReportDto>>>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public bool IncludeComments { get; set; } = false;
    }
}