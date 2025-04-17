using Hope.Application.Common.Models;
using Hope.Application.MissingPerson.Commands.CreateMissingPersonReport;
using Hope.Application.MissingPerson.Commands.DeleteReport;
using Hope.Application.MissingPerson.Commands.HideReport;
using Hope.Application.MissingPerson.Commands.UpdateMissingPersonReport;
using Hope.Application.MissingPerson.DTOs;
using Hope.Application.MissingPerson.Queries.GetArchivedReports;
using Hope.Application.MissingPerson.Queries.GetReportById;
using Hope.Application.MissingPerson.Queries.GetReports;
using Hope.Application.MissingPerson.Queries.GetReportsByMissingState;
using Hope.Domain.Entities;
using Hope.Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hope.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
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
        [ProducesResponseType(typeof(Result<PaginatedList<ReportDto>>), 200)]
        [ProducesResponseType(typeof(Result), 400)]
        public async Task<ActionResult<Result<PaginatedList<ReportDto>>>> GetReports(
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 10,
            [FromQuery] ReportSubjectType? reportSubjectType = null,
            [FromQuery] bool includeComments = true)
        {
            var query = new GetReportsQuery
            {
                PageNumber = pageNumber,
                PageSize = pageSize,
                ReportSubjectType = reportSubjectType,
                IncludeComments = includeComments
            };

            var result = await _mediator.Send(query);

            if (!result.Succeeded)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpGet("by-missing-state")]
        [ProducesResponseType(typeof(Result<PaginatedList<ReportDto>>), 200)]
        [ProducesResponseType(typeof(Result), 400)]
        public async Task<ActionResult<Result<PaginatedList<ReportDto>>>> GetReportsByMissingState(
            [FromQuery] MissingState? missingState = null,
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 10,
            [FromQuery] bool includeComments = true)
        {
            var query = new GetReportsByMissingStateQuery
            {
                MissingState = missingState,
                PageNumber = pageNumber,
                PageSize = pageSize,
                IncludeComments = includeComments
            };

            var result = await _mediator.Send(query);

            if (!result.Succeeded)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpGet("archived")]
        [ProducesResponseType(typeof(Result<PaginatedList<ReportDto>>), 200)]
        [ProducesResponseType(typeof(Result), 400)]
        public async Task<ActionResult<Result<PaginatedList<ReportDto>>>> GetArchivedReports(
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 10,
            [FromQuery] bool includeComments = true)
        {
            var query = new GetArchivedReportsQuery
            {
                PageNumber = pageNumber,
                PageSize = pageSize,
                IncludeComments = includeComments
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

        [HttpPut("{id}/hide")]
        [ProducesResponseType(typeof(Result<bool>), 200)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(Result), 404)]
        public async Task<ActionResult<Result<bool>>> HideReport(Guid id)
        {
            var command = new HideReportCommand { ReportId = id };
            var result = await _mediator.Send(command);

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

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(Result<bool>), 200)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(Result), 404)]
        public async Task<ActionResult<Result<bool>>> DeleteReport(Guid id)
        {
            var command = new DeleteReportCommand { ReportId = id };
            var result = await _mediator.Send(command);

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
        [HttpPut("reports/{id}/unhide")]
        [ProducesResponseType(typeof(Result<bool>), 200)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(Result), 404)]
        public async Task<ActionResult<Result<bool>>> UnHidePosts(Guid id)
        {
            var command = new UnHideReportCommand { ReportId = id };
            var result = await _mediator.Send(command);

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
        //[HttpGet("archived")]
        //[ProducesResponseType(typeof(Result<IEnumerable<ReportDto>>), 200)]
        //[ProducesResponseType(typeof(Result), 400)]
        //public async Task<ActionResult<Result<IEnumerable<ReportDto>>>> GetArchivedReports()
        //{
        //    var query = new GetArchivedReportsQuery();
        //    var result = await _mediator.Send(query);

        //    if (!result.Succeeded)
        //    {
        //        return BadRequest(result);
        //    }

        //    return Ok(result);
        //}
        [HttpPut]
        [ProducesResponseType(typeof(Result<bool>), 200)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(Result), 404)]
        public async Task<ActionResult<Result<bool>>> UpdateReport([FromForm] UpdateMissingPersonReportCommand command)
        {
            
            var result = await _mediator.Send(command);

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