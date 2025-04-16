using Hope.Application.Common.Interfaces;
using Hope.Application.Common.Models;
using Hope.Application.LookUps.Dtos;
using Hope.Application.LookUps.Queries.GetCentersByGovernmentId;
using Hope.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hope.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize] 
    public class LookupController : ControllerBase
    {
        private readonly ILookupService _lookupService;
        private readonly IMediator _mediator;

        public LookupController(ILookupService lookupService, IMediator mediator)
        {
            _lookupService = lookupService;
            _mediator = mediator;
        }

        [HttpGet("governments")]
        public async Task<ActionResult<IEnumerable<GovernmentDto>>> GetGovernments()
        {
            var result = await _lookupService.GetAllAsync<Government>();
            var governments = result is null ? null : result.Select(g => new GovernmentDto
            {
                Id = g.Id,
                NameEn = g.NameEn,
                NameAr = g.NameAr,
                PhoneCode = g.PhoneCode
            }).ToList();
            return Ok(governments);
        }

        [HttpGet("governments/{governmentId}/centers")]
        [ProducesResponseType(typeof(Result<IEnumerable<CenterDto>>), 200)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(Result), 404)]
        public async Task<ActionResult<Result<IEnumerable<CenterDto>>>> GetCentersByGovernmentId(int governmentId)
        {
            var result = await _mediator.Send(new GetCentersByGovernmentIdQuery { GovernmentId = governmentId });
            
            if (!result.Succeeded)
            {
                if (result.Message.Contains("not found"))
                {
                    return NotFound(result);
                }
                return BadRequest(result);
            }
            
            return Ok(result);
        }
    }
}