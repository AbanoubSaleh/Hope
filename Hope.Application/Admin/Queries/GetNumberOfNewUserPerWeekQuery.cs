using Hope.Application.Admin.DTOs;
using Hope.Application.Common.Models;
using MediatR;
using System.Collections.Generic;

namespace Hope.Application.Admin.Queries
{
    public class GetNumberOfNewUserPerWeekQuery : IRequest<Result<List<WeeklyCountDto>>>
    {
    }
}