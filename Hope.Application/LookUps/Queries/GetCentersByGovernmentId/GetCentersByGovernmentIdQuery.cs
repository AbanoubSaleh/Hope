using Hope.Application.Common.Models;
using Hope.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;

namespace Hope.Application.LookUps.Queries.GetCentersByGovernmentId
{
    public class GetCentersByGovernmentIdQuery : IRequest<Result<IEnumerable<Center>>>
    {
        public int GovernmentId { get; set; }
    }
}