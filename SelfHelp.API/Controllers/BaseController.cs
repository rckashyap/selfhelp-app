using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace SelfHelp.API.Controllers
{
    [ApiController]
    public abstract class BaseController
    {
        public IActionResult GetActionResult(HttpStatusCode statusCode, object? value)
        {
            return new JsonResult(value)
            {
                StatusCode = (int)statusCode 
            };
        }
    }
}