using Hope.Application.Common.Models;
using Hope.Application.MissingPerson.Commands.CreateMissingPersonReport;
using Hope.Application.MissingPerson.DTOs;
using Hope.Application.MissingPerson.Queries.GetReportById;
using Hope.Application.MissingPerson.Queries.GetReports;
using Hope.Domain.Entities;
using Hope.Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hope.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class ReportsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ReportsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [ProducesResponseType(typeof(Result<Guid>), 200)]
        [ProducesResponseType(typeof(Result), 400)]
        public async Task<ActionResult<Result<Guid>>> CreateReport([FromForm] CreateMissingPersonReportCommand command)
        {
            var result = await _mediator.Send(command);

            if (!result.Succeeded)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpGet]
        [ProducesResponseType(typeof(Result<IEnumerable<ReportDto>>), 200)]
        [ProducesResponseType(typeof(Result), 400)]
        public async Task<ActionResult<Result<IEnumerable<Report>>>> GetReports(
            
            [FromQuery] ReportSubjectType? reportSubjectType = null)
        {
            var query = new GetReportsQuery
            {
                ReportSubjectType = reportSubjectType
            };

            var result = await _mediator.Send(query);

            if (!result.Succeeded)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Result<ReportDto>), 200)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(Result), 404)]
        public async Task<ActionResult<Result<ReportDto>>> GetReportById(Guid id)
        {
            var query = new GetReportByIdQuery { ReportId = id };
            var result = await _mediator.Send(query);

            if (!result.Succeeded)
            {
                if (result.Message!.Contains("not found"))
                {
                    return NotFound(result);
                }
                return BadRequest(result);
            }

            return Ok(result);
        }
    }
}