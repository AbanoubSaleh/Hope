using Hope.Application.Common.Interfaces;
using Hope.Application.Common.Models;
using Hope.Application.LookUps.Dtos;
using Hope.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hope.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LookupController : ControllerBase
    {
        private readonly ILookupService _lookupService;

        public LookupController(ILookupService lookupService)
        {
            _lookupService = lookupService;
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
    }
}