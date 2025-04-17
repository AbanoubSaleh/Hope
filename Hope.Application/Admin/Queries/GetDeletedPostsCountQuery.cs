using Hope.Application.Common.Models;
using MediatR;

namespace Hope.Application.Admin.Queries
{
    public class GetDeletedPostsCountQuery : IRequest<Result<int>>
    {
    }
}