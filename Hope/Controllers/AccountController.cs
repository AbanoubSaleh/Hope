using Hope.Application.Authentication.Commands.ConfirmEmail;
using Hope.Application.Authentication.Commands.ExternalLogin;
using Hope.Application.Authentication.Commands.ForgotPassword;
using Hope.Application.Authentication.Commands.Login;
using Hope.Application.Authentication.Commands.RefreshToken;
using Hope.Application.Authentication.Commands.Register;
using Hope.Application.Authentication.Commands.ResetPassword;
using Hope.Application.Authentication.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Hope.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AccountController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterCommand command, CancellationToken cancellationToken)
        {

            var result = await _mediator.Send(command, cancellationToken);

            if (result.Succeeded)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto model, CancellationToken cancellationToken)
        {
            var command = new LoginCommand
            {
                Email = model.Email,
                Password = model.Password,
                RememberMe = model.RememberMe
            };

            var result = await _mediator.Send(command, cancellationToken);

            if (result.Succeeded)
            {
                return Ok(result);
            }

            return Unauthorized(result);
        }

        [HttpGet("confirm-email")]
        public async Task<IActionResult> ConfirmEmail([FromQuery] string userId, [FromQuery] string token, CancellationToken cancellationToken)
        {
            var command = new ConfirmEmailCommand
            {
                UserId = userId,
                ConfirmationCode = token
            };

            var result = await _mediator.Send(command, cancellationToken);

            if (result.Succeeded)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("forgot-password")]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordDto model, CancellationToken cancellationToken)
        {
            var command = new ForgotPasswordCommand
            {
                Email = model.Email
            };

            var result = await _mediator.Send(command, cancellationToken);

            // Always return OK to prevent email enumeration attacks
            return Ok(result);
        }

        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordDto model, CancellationToken cancellationToken)
        {
            var command = new ResetPasswordCommand
            {
                Email = model.Email,
                Token = model.Token,
                Password = model.Password,
                ConfirmPassword = model.ConfirmPassword
            };

            var result = await _mediator.Send(command, cancellationToken);

            if (result.Succeeded)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("external-login")]
        public async Task<IActionResult> ExternalLogin([FromBody] ExternalLoginDto model, CancellationToken cancellationToken)
        {
            var command = new ExternalLoginCommand
            {
                Provider = model.Provider,
                IdToken = model.IdToken
            };

            var result = await _mediator.Send(command, cancellationToken);

            if (result.Succeeded)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("refresh-token")]
        public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenDto model, CancellationToken cancellationToken)
        {
            var command = new RefreshTokenCommand
            {
                Token = model.Token,
                RefreshToken = model.RefreshToken
            };

            var result = await _mediator.Send(command, cancellationToken);

            if (result.Succeeded)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}