using AutoMapper;
using BH.DTOL.Entities;
using BH.DTOL.Interfaces;
using BH.ServiceLayer.DTOs.ConstructionWorks;
using BH.ServiceLayer.DTOs.ConstructionWorks.Models;
using BH.ServiceLayer.Services.Interfaces.ConstructionWorks;
using System;
using System.Collections.Generic;
using System.Text;

namespace BH.ServiceLayer.Services.ConstructionWorksServices
{
    public class CompanyConstructionWorksService : ICompanyConstructionWorksService
    {
        private readonly IUnitOfWork _contextEntities;
        private readonly IMapper _mapper;

        public CompanyConstructionWorksService(IUnitOfWork contextEntities, IMapper mapper)
        {
            _mapper = mapper;
            _contextEntities = contextEntities;
        }

        public IEnumerable<CompanyConstructionWorksModel> GetCompanyConstructionWorksByWorksId(Guid worksId)
        {
            var companyConstWorksIncludeProps = new string[] { "Company" };
            var dbCompanyConstWorks = _contextEntities.Repository.GetAll<CompanyConstructionWorks>(constWork => 
                constWork.ConstructionWorksId == worksId, includeProperties: companyConstWorksIncludeProps);
            var responseData = _mapper.Map<IEnumerable<CompanyConstructionWorksModel>>(dbCompanyConstWorks);

            return responseData;
        }

        public CompanyConstructionWorksModel GetCompanyConstructionWorksById(Guid id)
        {
            var compConstWorksIncludeProps = new string[] { "ConstructionWorks", "Company" };
            var dbCompConstWorks = _contextEntities.Repository.GetById<CompanyConstructionWorks>(id, compConstWorksIncludeProps);

            var responseData = _mapper.Map<CompanyConstructionWorksModel>(dbCompConstWorks);

            return responseData;
        }

        public CompanyConstructionWorksModel CreateCompanyConstructionWorks(CreateCompanyConstructionWorksDto requestData)
        {
            var compConstWorks = _mapper.Map<CompanyConstructionWorks>(requestData);
            compConstWorks.Id = Guid.NewGuid();

            _contextEntities.Create(compConstWorks);
            _contextEntities.Save();

            return GetCompanyConstructionWorksById(compConstWorks.Id);
        }

        public CompanyConstructionWorksModel UpdateCompanyConstructionWorks(UpdateCompanyConstructionWorksDto requestData)
        {
            var dbCompConstWorks = _contextEntities.Repository.GetById<CompanyConstructionWorks>(requestData.Id);

            _mapper.Map(requestData, dbCompConstWorks);

            _contextEntities.Save();

            return GetCompanyConstructionWorksById(dbCompConstWorks.Id);
        }

        public void DeleteCompanyConstructionWorks(Guid id)
        {
            _contextEntities.Delete<CompanyConstructionWorks>(id);
            _contextEntities.Save();
        }           
    }
}
