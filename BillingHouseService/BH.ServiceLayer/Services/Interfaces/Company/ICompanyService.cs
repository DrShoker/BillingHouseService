using BH.ServiceLayer.DTOs.Common.Models;
using BH.ServiceLayer.DTOs.Company;
using BH.ServiceLayer.DTOs.Company.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BH.ServiceLayer.Services.Interfaces.Company
{
    public interface ICompanyService
    {
        IEnumerable<ListItemModel<Guid>> GetCompanies();
        CompanyModel GetCompanyById(Guid id);
        CompanyModel CreateCompany(CreateCompanyDto requestData);
        CompanyModel UpdateCompany(UpdateCompanyDto requestData);
        void DeleteCompany(Guid id);
        IEnumerable<ListItemModel<Guid>> GetCompanyContactPhones(Guid companyId);
        void CreateCompanyContactPhone(Guid companyId, string number);
        void UpdateCompanyContactPhone(Guid id, string number);
        void DeleteCompanyContactPhone(Guid id);
    }
}
