using Hope.Application.Common.Models;
using Hope.Application.Users.DTOs;
using MediatR;
using System.Collections.Generic;

namespace Hope.Application.Admin.Queries
{
    public class GetAllAdminsQuery : IRequest<Result<PaginatedList<UserDto>>>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}