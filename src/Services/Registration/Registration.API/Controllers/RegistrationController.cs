using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Registration.API.Controllers;

[Authorize]
[Route("registrations")]
[ApiController]
public class RegistrationController
	: ControllerBase
{

}
