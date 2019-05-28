using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BH.ServiceLayer.DTOs.UserProject;
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

        [HttpPost]
        public IActionResult CreateUserProject(Guid userId, CreateUserProjectDto requestData)
        {
            var responseData = _userProjectService.CreateUserProject(userId, requestData);

            return PostResults.Created(this, responseData);
        }

        [HttpPut]
        public IActionResult UpdateUserProject(Guid userId, UpdateUserProjectDto requestData)
        {
            var responseData = _userProjectService.UpdateUserProject(userId, requestData);

            return PutResults.Accepted(this, responseData);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUserProject(Guid userId, Guid id)
        {
            _userProjectService.DeleteUserProject(userId, id);

            return DeleteResults.Deleted(this);
        }
    }
}