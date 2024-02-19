using Microsoft.AspNetCore.Mvc;

namespace SelfHelp.API.Controllers.Login
{
    [ApiVersion("1.0")]
    [Produces("application/json")]
    [Consumes("application/json")]
    [Route("/app")]
    public class LoginV1Controller : BaseController
    {
        [HttpPost]
        [Route("login")]
        public IActionResult LoginUser()
        {
            return new OkResult();
        }
    }
}