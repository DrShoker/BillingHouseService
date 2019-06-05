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
    public class ConstructionMaterialService : IConstructionMaterialService
    {
        private readonly IUnitOfWork _contextEntities;
        private readonly IMapper _mapper;

        public ConstructionMaterialService(IUnitOfWork contextEntities, IMapper mapper)
        {
            _mapper = mapper;
            _contextEntities = contextEntities;
        }

        public IEnumerable<ConstructionMaterialModel> GetConstructionMaterials()
        {
            var dbConstructionMaterials = _contextEntities.Repository.GetAll<ConstructionMaterial>();
            var responseData = _mapper.Map<IEnumerable<ConstructionMaterialModel>>(dbConstructionMaterials);

            return responseData;
        }

        public ConstructionMaterialModel GetConstructionMaterialById(Guid id)
        {
            var dbConstructionMaterial = _contextEntities.Repository.GetById<ConstructionMaterial>(id);

            var responseData = _mapper.Map<ConstructionMaterialModel>(dbConstructionMaterial);

            return responseData;
        }

        public ConstructionMaterialModel CreateConstructionWMaterial(CreateConstructionMaterialDto requestData)
        {
            var constructionMaterial = _mapper.Map<ConstructionMaterial>(requestData);
            constructionMaterial.Id = Guid.NewGuid();

            _contextEntities.Create(constructionMaterial);
            _contextEntities.Save();

            return GetConstructionMaterialById(constructionMaterial.Id);
        }

        public ConstructionMaterialModel UpdateConstructionMaterial(UpdateConstructionMaterialDto requestData)
        {
            var dbConstructionMaterial = _contextEntities.Repository.GetById<ConstructionMaterial>(requestData.Id);

            _mapper.Map(requestData, dbConstructionMaterial);

            _contextEntities.Save();

            return GetConstructionMaterialById(dbConstructionMaterial.Id);
        }

        public void DeleteConstructionMaterial(Guid id)
        {
            _contextEntities.Delete<ConstructionMaterial>(id);
            _contextEntities.Save();
        }
    }
}
