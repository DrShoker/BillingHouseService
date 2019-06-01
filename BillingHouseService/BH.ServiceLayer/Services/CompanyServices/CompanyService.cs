using AutoMapper;
using BH.DTOL.Entities;
using BH.DTOL.Interfaces;
using BH.ServiceLayer.DTOs.Common.Models;
using BH.ServiceLayer.DTOs.Company;
using BH.ServiceLayer.DTOs.Company.Models;
using BH.ServiceLayer.Services.Interfaces.Company;
using System;
using System.Collections.Generic;
using System.Text;

namespace BH.ServiceLayer.Services.CompanyServices
{
    public class CompanyService : ICompanyService 
    {
        private readonly IUnitOfWork _contextEntities;
        private readonly IMapper _mapper;

        public CompanyService(IUnitOfWork contextEntities, IMapper mapper)
        {
            _mapper = mapper;
            _contextEntities = contextEntities;
        }

        public IEnumerable<ListItemModel<Guid>> GetCompanies()
        {
            var dbCompanies = _contextEntities.Repository.GetAll<Company>();

            var responseData = _mapper.Map<IEnumerable<ListItemModel<Guid>>>(dbCompanies);

            return responseData;
        }

        public CompanyModel GetCompanyById(Guid id)
        {
            var dbCompany = _contextEntities.Repository.GetById<Company>(id);
            var responseData = _mapper.Map<CompanyModel>(dbCompany);

            return responseData;
        }

        public CompanyModel CreateCompany(CreateCompanyDto requestData)
        {
            var company = _mapper.Map<Company>(requestData);
            company.Id = Guid.NewGuid();

            _contextEntities.Create(company);
            _contextEntities.Save();

            return GetCompanyById(company.Id);
        }

        public CompanyModel UpdateCompany(UpdateCompanyDto requestData)
        {
            var dbCompany = _contextEntities.Repository.GetById<Company>(requestData.Id);

            _mapper.Map(requestData, dbCompany);

            _contextEntities.Save();

            return GetCompanyById(requestData.Id);
        }

        public void DeleteCompany(Guid id)
        {
            _contextEntities.Delete<Company>(id);
            _contextEntities.Save();
        }

        public IEnumerable<ListItemModel<Guid>> GetCompanyContactPhones(Guid companyId)
        {
            var companyIncludeProps = new string[] { "ContactPhones" };
            var dbCompany = _contextEntities.Repository.GetById<Company>(companyId, companyIncludeProps);
            var responseData = _mapper.Map<IEnumerable<ListItemModel<Guid>>>(dbCompany.ContactPhones);

            return responseData;
        }

        public void CreateCompanyContactPhone(Guid companyId, string number)
        {
            _contextEntities.Repository.GetById<Company>(companyId);
            var contactPhone = new CompanyContactPhones();
            contactPhone.Id = Guid.NewGuid();
            contactPhone.PhoneNumber = number;
            contactPhone.CompanyId = companyId;

            _contextEntities.Create(contactPhone);
            _contextEntities.Save();
        }

        public void UpdateCompanyContactPhone(Guid id, string number)
        {
            var dbContactPhone = _contextEntities.Repository.GetById<CompanyContactPhones>(id);
            dbContactPhone.PhoneNumber = number;

            _contextEntities.Save();
        }

        public void DeleteCompanyContactPhone(Guid id)
        {
            _contextEntities.Delete<CompanyContactPhones>(id);
            _contextEntities.Save();
        }
    }
}
