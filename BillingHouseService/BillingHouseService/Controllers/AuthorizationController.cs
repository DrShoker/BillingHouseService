using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BH.ServiceLayer.DTOs.User;
using BH.ServiceLayer.Services.Interfaces.User;
using BH.WebApi.Infrastructure.Rest.ActionResults;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BH.WebApi.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthorizationController : ControllerBase
    {
        private readonly IUserService _userService;

        public AuthorizationController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("signUp")]
        public IActionResult SignUpUser(UserSignUpDto requestData)
        {
            _userService.SignUpUser(requestData);

            return PostResults.Created(this);
        }

        [HttpPost("singIn")]
        public IActionResult SingInUser(UserSingInDto requestData)
        {
            var responseData = _userService.SingInUser(requestData);

            return PostResults.Created(this, responseData);
        }
    }
}