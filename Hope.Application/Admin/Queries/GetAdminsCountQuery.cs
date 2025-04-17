using Hope.Application.Common.Models;
using MediatR;

namespace Hope.Application.Admin.Queries
{
    public class GetAdminsCountQuery : IRequest<Result<int>>
    {
    }
}