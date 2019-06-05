using AutoMapper;
using BH.DTOL.Entities;
using BH.DTOL.Interfaces;
using BH.ServiceLayer.DTOs.ConstructionMaterials;
using BH.ServiceLayer.DTOs.ConstructionMaterials.Models;
using BH.ServiceLayer.Services.Interfaces.ConstructionMaterial;
using System;
using System.Collections.Generic;
using System.Text;

namespace BH.ServiceLayer.Services.ConstructionMaterialServices
{
    public class CompanyConstructionMaterialService : ICompanyConstructionMaterialService
    {
        private readonly IUnitOfWork _contextEntities;
        private readonly IMapper _mapper;

        public CompanyConstructionMaterialService(IUnitOfWork contextEntities, IMapper mapper)
        {
            _mapper = mapper;
            _contextEntities = contextEntities;
        }

        public IEnumerable<CompanyConstructionMaterialModel> GetCompanyConstructionMaterials(Guid companyId, Guid materialId)
        {
            var compConstMaterialIncludeProps = new string[] { "ConstructionMaterial", "Company" };
            var dbCompConstMaterials = _contextEntities.Repository.GetAll<CompanyConstructionMaterial>(entity => 
                entity.CompanyId == companyId &&
                entity.ConstructionMaterialId == materialId, 
                includeProperties: compConstMaterialIncludeProps);
            var responseData = _mapper.Map<IEnumerable<CompanyConstructionMaterialModel>>(dbCompConstMaterials);

            return responseData;
        }

        public CompanyConstructionMaterialModel GetCompanyConstructionMaterialById(Guid id)
        {
            var compConstMaterialIncludeProps = new string[] { "ConstructionMaterial", "Company" };
            var dbCompConstMaterial = _contextEntities.Repository.GetById<CompanyConstructionMaterial>(id, compConstMaterialIncludeProps);

            var responseData = _mapper.Map<CompanyConstructionMaterialModel>(dbCompConstMaterial);

            return responseData;
        }

        public CompanyConstructionMaterialModel CreateCompanyConstructionWMaterial(CreateCompanyConstructionMaterialDto requestData)
        {
            var compConstMaterial = _mapper.Map<CompanyConstructionMaterial>(requestData);
            compConstMaterial.Id = Guid.NewGuid();

            _contextEntities.Create(compConstMaterial);
            _contextEntities.Save();

            return GetCompanyConstructionMaterialById(compConstMaterial.Id);
        }

        public CompanyConstructionMaterialModel UpdateCompanyConstructionMaterial(UpdateCompanyConstructionMaterialDto requestData)
        {
            var dbCompConstMaterial = _contextEntities.Repository.GetById<CompanyConstructionMaterial>(requestData.Id);

            _mapper.Map(requestData, dbCompConstMaterial);

            _contextEntities.Save();

            return GetCompanyConstructionMaterialById(dbCompConstMaterial.Id);
        }

        public void DeleteCompanyConstructionMaterial(Guid id)
        {
            _contextEntities.Delete<CompanyConstructionMaterial>(id);
            _contextEntities.Save();
        }
    }
}
