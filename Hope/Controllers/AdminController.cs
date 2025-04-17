using Hope.Application.Admin.Commands;
using Hope.Application.Admin.DTOs;
using Hope.Application.Admin.Queries;
using Hope.Application.Common.Models;
using Hope.Application.MissingPerson.Commands.DeleteReport;
using Hope.Application.MissingPerson.Commands.HideReport;
using Hope.Application.MissingPerson.DTOs;
using Hope.Application.MissingPerson.Queries.GetArchivedReports;
using Hope.Application.Users.Commands.AssignRole;
using Hope.Application.Users.Commands.DeleteUser;
using Hope.Application.Users.DTOs;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hope.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin,SuperAdmin")]
    public class AdminController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AdminController(IMediator mediator)
        {
            _mediator = mediator;
        }

        #region User Management

        [HttpGet("users/count")]
        [ProducesResponseType(typeof(Result<int>), 200)]
        public async Task<ActionResult<Result<int>>> GetUserCount()
        {
            var result = await _mediator.Send(new GetUserCountQuery());
            return Ok(result);
        }

        [HttpGet("users/new-per-week")]
        [ProducesResponseType(typeof(Result<List<WeeklyCountDto>>), 200)]
        public async Task<ActionResult<Result<List<WeeklyCountDto>>>> GetNumberOfNewUserPerWeek()
        {
            var result = await _mediator.Send(new GetNumberOfNewUserPerWeekQuery());
            return Ok(result);
        }

        [HttpGet("users")]
        [ProducesResponseType(typeof(Result<List<UserDto>>), 200)]
        public async Task<ActionResult<Result<List<UserDto>>>> GetAllUsers()
        {
            var result = await _mediator.Send(new GetAllUsersQuery());
            return Ok(result);
        }

        [HttpDelete("users/{userId}")]
        [ProducesResponseType(typeof(Result<bool>), 200)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(Result), 404)]
        public async Task<ActionResult<Result<bool>>> DeleteUser(string userId)
        {
            var command = new DeleteUserCommand { UserId = userId };
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

        [HttpPost("users/{userId}/add-admin-role")]
        [Authorize(Roles = "SuperAdmin")]
        [ProducesResponseType(typeof(Result<bool>), 200)]
        [ProducesResponseType(typeof(Result), 400)]
        public async Task<ActionResult<Result<bool>>> AddAdminRole(string userId)
        {
            var command = new AssignRoleCommand { UserId = userId, RoleName = "Admin" };
            var result = await _mediator.Send(command);

            if (!result.Succeeded)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpPost("users/{userId}/add-user-role")]
        [ProducesResponseType(typeof(Result<bool>), 200)]
        [ProducesResponseType(typeof(Result), 400)]
        public async Task<ActionResult<Result<bool>>> AddUserRole(string userId)
        {
            var command = new AssignRoleCommand { UserId = userId, RoleName = "User" };
            var result = await _mediator.Send(command);

            if (!result.Succeeded)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpPost("register")]
        [Authorize(Roles = "SuperAdmin")]
        [ProducesResponseType(typeof(Result<string>), 200)]
        [ProducesResponseType(typeof(Result), 400)]
        public async Task<ActionResult<Result<string>>> AdminRegister([FromBody] AdminRegisterCommand command)
        {
            var result = await _mediator.Send(command);

            if (!result.Succeeded)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpGet("admins")]
        [ProducesResponseType(typeof(Result<List<UserDto>>), 200)]
        public async Task<ActionResult<Result<List<UserDto>>>> GetAllAdmins()
        {
            var result = await _mediator.Send(new GetAllAdminsQuery());
            return Ok(result);
        }

        [HttpGet("admins/count")]
        [ProducesResponseType(typeof(Result<int>), 200)]
        public async Task<ActionResult<Result<int>>> GetAdminsCount()
        {
            var result = await _mediator.Send(new GetAdminsCountQuery());
            return Ok(result);
        }

        #endregion

        #region Report Management

        [HttpGet("reports/count")]
        [ProducesResponseType(typeof(Result<int>), 200)]
        public async Task<ActionResult<Result<int>>> GetPostsCount()
        {
            var result = await _mediator.Send(new GetPostsCountQuery());
            return Ok(result);
        }

        [HttpGet("reports/deleted/count")]
        [ProducesResponseType(typeof(Result<int>), 200)]
        public async Task<ActionResult<Result<int>>> GetDeletedPostsCount()
        {
            var result = await _mediator.Send(new GetDeletedPostsCountQuery());
            return Ok(result);
        }

        [HttpGet("reports/new-per-week")]
        [ProducesResponseType(typeof(Result<List<WeeklyCountDto>>), 200)]
        public async Task<ActionResult<Result<List<WeeklyCountDto>>>> GetNumberOfNewPostsPerWeek()
        {
            var result = await _mediator.Send(new GetNumberOfNewPostsPerWeekQuery());
            return Ok(result);
        }

        [HttpGet("reports/{id}")]
        [ProducesResponseType(typeof(Result<ReportDto>), 200)]
        [ProducesResponseType(typeof(Result), 404)]
        public async Task<ActionResult<Result<ReportDto>>> GetPostByPostId(Guid id)
        {
            var result = await _mediator.Send(new GetPostByIdQuery { ReportId = id });

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

        [HttpGet("reports/archived")]
        [ProducesResponseType(typeof(Result<IEnumerable<ReportDto>>), 200)]
        public async Task<ActionResult<Result<IEnumerable<ReportDto>>>> GetArchivedPosts()
        {
            var result = await _mediator.Send(new GetArchivedReportsQuery());
            return Ok(result);
        }

        [HttpGet("reports")]
        [ProducesResponseType(typeof(Result<IEnumerable<ReportDto>>), 200)]
        public async Task<ActionResult<Result<IEnumerable<ReportDto>>>> GetAllPosts()
        {
            var result = await _mediator.Send(new GetAllPostsQuery());
            return Ok(result);
        }

        [HttpGet("reports/things")]
        [ProducesResponseType(typeof(Result<IEnumerable<ReportDto>>), 200)]
        public async Task<ActionResult<Result<IEnumerable<ReportDto>>>> GetPostThings()
        {
            var result = await _mediator.Send(new GetPostThingsQuery());
            return Ok(result);
        }

        [HttpPut("reports/{id}/hide")]
        [ProducesResponseType(typeof(Result<bool>), 200)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(Result), 404)]
        public async Task<ActionResult<Result<bool>>> HideReport(Guid id)
        {
            var command = new HideReportCommand 
            { 
                ReportId = id
            };
            
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

        [HttpDelete("reports/{id}")]
        [ProducesResponseType(typeof(Result<bool>), 200)]
        [ProducesResponseType(typeof(Result), 400)]
        [ProducesResponseType(typeof(Result), 404)]
        public async Task<ActionResult<Result<bool>>> DeleteReport(Guid id)
        {
            var command = new DeleteReportCommand 
            { 
                ReportId = id
            };
            
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

        #endregion
    }
}