using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BH.ServiceLayer.DTOs.ProjectSchema;
using BH.ServiceLayer.Services.Interfaces.User;
using BH.WebApi.Infrastructure.Rest.ActionResults;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BH.WebApi.Controllers
{
    [Route("api/users/{userId}/projects/{projectId}/schemas")]
    [ApiController]
    public class ProjectSchemaController : ControllerBase
    {
        private readonly IProjectSchemaService _projectSchemaService;

        public ProjectSchemaController(IProjectSchemaService projectSchemaService)
        {
            _projectSchemaService = projectSchemaService;
        }

        [HttpGet]
        public IActionResult GetProjectSchemas(Guid projectId)
        {
            var responseData = _projectSchemaService.GetProjectSchemas(projectId);

            return GetResults.Ok(this, responseData);
        }

        [HttpGet("{id}")]
        public IActionResult GetProjectSchemaById(Guid projectId, Guid id)
        {
            var responseData = _projectSchemaService.GetProjectSchemaById(projectId, id);

            return
                 GetResults.Ok(this, responseData);
        }

        [HttpPost]
        public IActionResult CreateProjectSchema(Guid projectId, [FromBody]CreateProjectSchemaDto requestData)
        {
            var responseData = _projectSchemaService.CreateProjectSchema(projectId, requestData);

            return PostResults.Created(this, responseData);
        }

        [HttpPut]
        public IActionResult UpdateProjectSchema(Guid projectId, [FromBody]UpdateProjectSchemaDto requestData)
        {
            var responseData = _projectSchemaService.UpdateProjectSchema(projectId, requestData);

            return PutResults.Accepted(this, responseData);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProjectSchema(Guid id)
        {
            _projectSchemaService.DeleteProjectSchema(id);

            return DeleteResults.Deleted(this);
        }

        [HttpGet("{schemaId}/walls")]
        public IActionResult GetSchemaWall(Guid schemaId)
        {
            var responseData = _projectSchemaService.GetSchemaWalls(schemaId);

            return GetResults.Ok(this, responseData);
        }

        [HttpPost("{schemaId}/walls")]
        public IActionResult CreateSchemaWall(Guid schemaId, [FromBody]CreateSchemaWallDto requestData)
        {
            var responseData = _projectSchemaService.CreateSchemaWall(schemaId, requestData);

            return PostResults.Created(this, responseData);
        }

        [HttpPut("{schemaId}/walls")]
        public IActionResult UpdateSchemaWall(Guid schemaId, [FromBody]UpdateSchemaWallDto requestData)
        {
            var responseData = _projectSchemaService.UpdateSchemaWall(schemaId, requestData);

            return PutResults.Accepted(this, responseData);
        }

        [HttpDelete("{schemaId}/walls/{id}")]
        public IActionResult DeleteSchemaWall(Guid id)
        {
            _projectSchemaService.DeleteSchemaWall(id);

            return DeleteResults.Deleted(this);
        }

        [HttpPost("{schemaId}/const-work/{workId}")]
        public IActionResult AddCompanyConstructionWorkToSchema(Guid schemaId, Guid workId)
        {
            _projectSchemaService.AddCompanyConstructionWorkToSchema(schemaId, workId);

            return PostResults.Created(this);
        }

        [HttpGet("{schemaId}/sum")]
        public IActionResult GetCompConstWorkSchemaSum(Guid schemaId)
        {
            var responseData = _projectSchemaService.GetCompConstWorkSchemaSum(schemaId);

            return GetResults.Ok(this, responseData);
        }
    }
}