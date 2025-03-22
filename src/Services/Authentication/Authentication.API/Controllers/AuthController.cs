using Authentication.API.Authentication.Create;
using Authentication.API.Authentication.Login;
using Authentication.API.Authentication.Register;
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
            var command = new RegisterCommand(dto.FirstName, dto.LastName, dto.Email, dto.Password);

            await mediator.Send(command);

            return Ok();
        }

		[HttpPost("login")]
		public async Task<ActionResult<LoginResponse>> Login([FromBody] LoginDto dto)
		{
			var query = new LoginQuery(dto.Email, dto.Password);

			var response = await mediator.Send(query);

			return Ok(response);
		}

        [HttpPost("create")]
        public async Task<ActionResult<Guid>> CreateUser([FromBody]CreateUserDto dto)
        {
            var command = new CreateUserCommand(dto.FirstName, dto.LastName, dto.Bio, dto.Email, dto.Password, dto.UserRole);

            await mediator.Send(command);

            return Created();
        }
	}
}
