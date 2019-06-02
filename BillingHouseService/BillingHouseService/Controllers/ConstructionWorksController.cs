using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BH.ServiceLayer.DTOs.ConstructionWorks;
using BH.ServiceLayer.Services.Interfaces.ConstructionWorks;
using BH.WebApi.Infrastructure.Rest.ActionResults;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BH.WebApi.Controllers
{
    [Route("api/construction_works")]
    [ApiController]
    public class ConstructionWorksController : ControllerBase
    {
        private readonly IConstructionWorksService _constructionWorksService;

        public ConstructionWorksController(IConstructionWorksService constructionWorksService)
        {
            _constructionWorksService = constructionWorksService;
        }

        [HttpGet]
        public IActionResult GetConstructionWorks()
        {
            var responseData = _constructionWorksService.GetConstructionWorks();

            return GetResults.Ok(this, responseData);
        }

        [HttpGet("{id}")]
        public IActionResult GetConstructionWorksById(Guid id)
        {
            var responseData = _constructionWorksService.GetConstructionWorksById(id);

            return GetResults.Ok(this, responseData);
        }

        [HttpPost]
        public IActionResult CreateConstructionWorks(CreateConstructionWorksDto requestData)
        {
            var responseData = _constructionWorksService.CreateConstructionWorks(requestData);

            return PostResults.Created(this, responseData);
        }

        [HttpPut]
        public IActionResult UpdateConstructionWorks(UpdateConstructionWorksDto requestData)
        {
            var responseData = _constructionWorksService.UpdateConstructionWorks(requestData);

            return PutResults.Accepted(this, responseData);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteConstructionWorks(Guid id)
        {
            _constructionWorksService.DeleteConstructionWorks(id);

            return DeleteResults.Deleted(this);
        }
    }
}