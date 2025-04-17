using Hope.Application.Common.Models;
using Hope.Application.Users.Commands.AddUserImage;
using Hope.Application.Users.Commands.UpdateUserData;
using Hope.Application.Users.DTOs;
using Hope.Application.Users.Queries.GetOtherUserProfile;
using Hope.Application.Users.Queries.GetUserProfile;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hope.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProfileController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProfileController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetProfile")]
        [ProducesResponseType(typeof(Result<UserProfileDto>), 200)]
        [ProducesResponseType(typeof(Result), 400)]
        public async Task<ActionResult<Result<UserProfileDto>>> GetProfile([FromQuery] string UserId)
        {
            var query = new GetUserProfileQuery() {UserId= UserId };
            var result = await _mediator.Send(query);

            if (!result.Succeeded)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpGet("GetProfileOfAnotherUser")]
        [ProducesResponseType(typeof(Result<UserProfileDto>), 200)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(Result), 404)]
        public async Task<ActionResult<Result<UserProfileDto>>> GetProfileOfAnotherUser([FromQuery] string userId)
        {
            var query = new GetOtherUserProfileQuery { UserId = userId };
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

        [HttpPut("UpdateUserData")]
        [ProducesResponseType(typeof(Result<bool>), 200)]
        [ProducesResponseType(typeof(Result), 400)]
        public async Task<ActionResult<Result<bool>>> UpdateUserData([FromBody] UpdateUserDataCommand command)
        {
            var result = await _mediator.Send(command);

            if (!result.Succeeded)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpPost("AddUserImage")]
        [ProducesResponseType(typeof(Result<string>), 200)]
        [ProducesResponseType(typeof(Result), 400)]
        public async Task<ActionResult<Result<string>>> AddUserImage([FromForm] AddUserImageCommand command)
        {
            var result = await _mediator.Send(command);

            if (!result.Succeeded)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }
    }
}