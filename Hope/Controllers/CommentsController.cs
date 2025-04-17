using Hope.Application.Comments.Commands.CreateComment;
using Hope.Application.Comments.Commands.CreateReply;
using Hope.Application.Comments.Commands.DeleteComment;
using Hope.Application.Comments.Commands.DeleteReply;
using Hope.Application.Comments.Commands.UpdateComment;
using Hope.Application.Comments.Commands.UpdateReply;
using Hope.Application.Comments.DTOs;
using Hope.Application.Comments.Queries.GetCommentsByReportId;
using Hope.Application.Common.Models;
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
    [Authorize]
    public class CommentsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CommentsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("report/{reportId}")]
        [ProducesResponseType(typeof(Result<IEnumerable<CommentDto>>), 200)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(Result), 404)]
        public async Task<ActionResult<Result<IEnumerable<CommentDto>>>> GetCommentsByReportId(Guid reportId)
        {
            var query = new GetCommentsByReportIdQuery { ReportId = reportId };
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

        [HttpPost]
        [ProducesResponseType(typeof(Result<Guid>), 200)]
        [ProducesResponseType(typeof(Result), 400)]
        public async Task<ActionResult<Result<Guid>>> CreateComment(CreateCommentCommand command)
        {
            var result = await _mediator.Send(command);

            if (!result.Succeeded)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpPost("reply")]
        [ProducesResponseType(typeof(Result<Guid>), 200)]
        [ProducesResponseType(typeof(Result), 400)]
        public async Task<ActionResult<Result<Guid>>> CreateReply(CreateReplyCommand command)
        {
            var result = await _mediator.Send(command);

            if (!result.Succeeded)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpPut("comment/{id}")]
        [ProducesResponseType(typeof(Result<bool>), 200)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(Result), 404)]
        public async Task<ActionResult<Result<bool>>> UpdateComment(Guid id, [FromBody] string content)
        {
            var command = new UpdateCommentCommand { CommentId = id, Content = content };
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

        [HttpPut("reply/{id}")]
        [ProducesResponseType(typeof(Result<bool>), 200)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(Result), 404)]
        public async Task<ActionResult<Result<bool>>> UpdateReply(Guid id, [FromBody] string content)
        {
            var command = new UpdateReplyCommand { ReplyId = id, Content = content };
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

        [HttpDelete("comment/{id}")]
        [ProducesResponseType(typeof(Result<bool>), 200)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(Result), 404)]
        public async Task<ActionResult<Result<bool>>> DeleteComment(Guid id)
        {
            var command = new DeleteCommentCommand { CommentId = id };
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

        [HttpDelete("reply/{id}")]
        [ProducesResponseType(typeof(Result<bool>), 200)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(Result), 404)]
        public async Task<ActionResult<Result<bool>>> DeleteReply(Guid id)
        {
            var command = new DeleteReplyCommand { ReplyId = id };
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