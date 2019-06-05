using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BH.ServiceLayer.DTOs.ConstructionMaterials;
using BH.ServiceLayer.Services.Interfaces;
using BH.ServiceLayer.Services.Interfaces.ConstructionMaterial;
using BH.WebApi.Infrastructure.Rest.ActionResults;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BH.WebApi.Controllers
{
    [Route("api/construction_materials")]
    [ApiController]
    public class ConstructionMaterialController : ControllerBase
    {
        private readonly IConstructionMaterialService _constructionMaterialService;
        private readonly ICompanyConstructionMaterialService _companyConstructionMaterialService;

        public ConstructionMaterialController(IConstructionMaterialService constructionMaterialService, ICompanyConstructionMaterialService companyConstructionMaterialService)
        {
            _constructionMaterialService = constructionMaterialService;
            _companyConstructionMaterialService = companyConstructionMaterialService;
        }

        [HttpGet]
        public IActionResult GetConstructionMaterials()
        {
            var responseData = _constructionMaterialService.GetConstructionMaterials();

            return GetResults.Ok(this, responseData);
        }

        [HttpGet("{id}")]
        public IActionResult GetConstructionMaterialById(Guid id)
        {
            var responseData = _constructionMaterialService.GetConstructionMaterialById(id);

            return GetResults.Ok(this, responseData);
        }

        [HttpPost]
        public IActionResult CreateConstructionMaterial(CreateConstructionMaterialDto requestData)
        {
            var responseData = _constructionMaterialService.CreateConstructionWMaterial(requestData);

            return PostResults.Created(this, responseData);
        }

        [HttpPut]
        public IActionResult UpdateConstructionMaterial(UpdateConstructionMaterialDto requestData)
        {
            var responseData = _constructionMaterialService.UpdateConstructionMaterial(requestData);

            return PutResults.Accepted(this, responseData);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteConstructionMaterial(Guid id)
        {
            _constructionMaterialService.DeleteConstructionMaterial(id);

            return DeleteResults.Deleted(this);
        }

        [HttpGet("{materialId}/company/{companyId}")]
        public IActionResult GetCompanyConstructionMaterials(Guid companyId, Guid materialId)
        {
            var responseData = _companyConstructionMaterialService.GetCompanyConstructionMaterials(companyId, materialId);

            return GetResults.Ok(this, responseData);
        }

        [HttpGet("company/{companyId}/materials/{id}")]
        public IActionResult GetCompanyConstructionMaterialById(Guid id)
        {
            var responseData = _companyConstructionMaterialService.GetCompanyConstructionMaterialById(id);

            return GetResults.Ok(this, responseData);
        }

        [HttpPost("company/{companyId}")]
        public IActionResult CreateCompanyConstructionMaterial(CreateCompanyConstructionMaterialDto requestData)
        {
            var responseData = _companyConstructionMaterialService.CreateCompanyConstructionWMaterial(requestData);

            return PostResults.Created(this, responseData);
        }

        [HttpPut("company/{companyId}")]
        public IActionResult UpdateCompanyConstructionMaterial(UpdateCompanyConstructionMaterialDto requestData)
        {
            var responseData = _companyConstructionMaterialService.UpdateCompanyConstructionMaterial(requestData);

            return PutResults.Accepted(this, responseData);
        }

        [HttpDelete("company/{companyId}/materials/{id}")]
        public IActionResult DeleteCompanyConstructionMaterial(Guid id)
        {
            _companyConstructionMaterialService.DeleteCompanyConstructionMaterial(id);

            return DeleteResults.Deleted(this);
        }
    }
}