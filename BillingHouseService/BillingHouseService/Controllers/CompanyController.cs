using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BH.ServiceLayer.DTOs.Company;
using BH.ServiceLayer.Services.Interfaces.Company;
using BH.WebApi.Infrastructure.Rest.ActionResults;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BH.WebApi.Controllers
{
    [Route("api/companies")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;

        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpGet]
        public IActionResult GetCompanies()
        {
            var responseData = _companyService.GetCompanies();

            return GetResults.Ok(this, responseData);
        }

        [HttpGet("{id}")]
        public IActionResult GetCompanyById(Guid id)
        {
            var responseData = _companyService.GetCompanyById(id);

            return GetResults.Ok(this, responseData);
        }

        [HttpPost]
        public IActionResult CreateCompany(CreateCompanyDto requestData)
        {
            var responseData = _companyService.CreateCompany(requestData);

            return PostResults.Created(this, responseData);
        }

        [HttpPut]
        public IActionResult UpdateCompany(UpdateCompanyDto requestData)
        {
            var responseData = _companyService.UpdateCompany(requestData);

            return PutResults.Accepted(this, responseData);
        }

        [HttpDelete]
        public IActionResult DeleteCompany(Guid id)
        {
            _companyService.DeleteCompany(id);

            return DeleteResults.Deleted(this);
        }

        [HttpGet("{companyId}/phones")]
        public IActionResult GetCompanyContactPhones(Guid companyId)
        {
            var responseData = _companyService.GetCompanyContactPhones(companyId);

            return GetResults.Ok(this, responseData);
        }

        [HttpPost("{companyId}/phones")]
        public IActionResult CreateCompanyContactPhones(Guid companyId, string number)
        {
            _companyService.CreateCompanyContactPhone(companyId, number);

            return PostResults.Created(this);
        }

        [HttpPut("{companyId}/phones")]
        public IActionResult updateCompanyContactPhones(Guid id, string number)
        {
            _companyService.UpdateCompanyContactPhone(id, number);

            return PutResults.Accepted(this);
        }

        [HttpDelete("{companyId}/phones/{id}")]
        public IActionResult DeleteCompanyContactPhones(Guid id)
        {
            _companyService.DeleteCompanyContactPhone(id);

            return DeleteResults.Deleted(this);
        }

    }
}