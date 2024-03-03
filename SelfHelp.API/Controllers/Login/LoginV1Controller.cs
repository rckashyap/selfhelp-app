using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using SelfHelp.API.Enums;
using SelfHelp.API.Models;
using SelfHelp.Business.Abstraction;
using SelfHelp.Business.Entities;
using System.Net;

namespace SelfHelp.API.Controllers.Login
{
    [ApiVersion("1.0")]
    [Produces("application/json")]
    [Consumes("application/json")]
    [Route("/app")]
    public class LoginV1Controller : BaseController
    {
        private readonly IUserLoginService loginService;

        public LoginV1Controller(IUserLoginService userLoginService)
        {
            this.loginService = userLoginService;
        }

        [HttpPost]
        [Route("login")]
        public IActionResult LoginUser()
        {
            return new OkResult();
        }

        [HttpPost]
        [Route("register")]
        public IActionResult RegisterUser(LoginUserV1Model registerUserV1Model)
        {
            if (this.loginService.IsEmailAlreadyRegistered(registerUserV1Model.Email))
            {
                return new JsonResult("User Already Registered.")
                {
                    StatusCode = (int)HttpStatusCode.BadRequest,
                };
            }

            var userEntity = new UserEntity
            {
                UserName = registerUserV1Model.UserName,
                Age = registerUserV1Model.Age,
                Email = registerUserV1Model.Email,
                FirstName = registerUserV1Model.FirstName,
                LastName = registerUserV1Model.LastName,
                Password = registerUserV1Model.Password,
                Gender = (Business.Entities.Enums.Gender)Enum.Parse(typeof(Gender), registerUserV1Model.Gender.ToString()),
            };

            var userId = this.loginService.AddUser(userEntity);

            if (userId > 0)
            {
                return new JsonResult("User registered successfully.")
                {
                    StatusCode = (int)HttpStatusCode.Created
                };
            }

            return new BadRequestResult();
        }
    }
}