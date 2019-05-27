using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BH.ServiceLayer.Services.Interfaces.User;
using BH.WebApi.Infrastructure.Rest.ActionResults;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BH.WebApi.Controllers
{
    [Route("api/{userId}/projects")]
    [ApiController]
    public class UserProjectController : ControllerBase
    {
        private readonly IUserProjectService _userProjectService;

        public UserProjectController(IUserProjectService userProjectService)
        {
            _userProjectService = userProjectService;
        }

        [HttpGet]
        public IActionResult GetUserProjects(Guid userId)
        {
            var responseData = _userProjectService.GetUserProjects(userId);

            return GetResults.Ok(this, responseData);
        }

        //[HttpPost]
        //public IActionResult CreateUserProject(Guid userId)
        //{

        //}

        //[HttpPut("{id}")]
        //public IActionResult UpdateUserProject(Guid userId, Guid id)
        //{

        //}

        //[HttpDelete("{id}")]
        //public IActionResult DeleteUserProject(Guid userId, Guid id)
        //{

        //}
    }
}