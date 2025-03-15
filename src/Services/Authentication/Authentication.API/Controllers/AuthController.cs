using Microsoft.AspNetCore.Mvc;

namespace Authentication.API.Controllers
{
    [Route("auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok("auth");
        }
    }
}
