using Authentication.API.Authentication.Login;
using Authentication.API.Authentication.Register;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Authentication.API.Controllers
{
    [Route("auth")]
    [ApiController]
    public class AuthController(IMediator mediator)
        : ControllerBase
    {

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok("auth");
        }

        [HttpPost("register")]
        public async Task<ActionResult> Register([FromBody] RegisterDto dto)
        {
            var command = new RegisterCommand(dto.Email, dto.Password);

            await mediator.Send(command);

            return Ok();
        }

		[HttpPost("login")]
		public async Task<ActionResult<LoginResponse>> Login([FromBody] LoginDto dto)
		{
			var command = new LoginCommand(dto.Email, dto.Password);

			var response = await mediator.Send(command);

			return Ok(response);
		}
	}
}
