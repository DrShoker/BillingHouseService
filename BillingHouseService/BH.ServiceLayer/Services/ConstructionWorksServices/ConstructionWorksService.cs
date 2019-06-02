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
    public class ConstructionWorksService : IConstructionWorksService
    {
        private readonly IUnitOfWork _contextEntities;
        private readonly IMapper _mapper;

        public ConstructionWorksService(IUnitOfWork contextEntities, IMapper mapper)
        {
            _mapper = mapper;
            _contextEntities = contextEntities;
        }

        public IEnumerable<ConstructionWorksModel> GetConstructionWorks()
        {
            var dbConstructionWorks = _contextEntities.Repository.GetAll<ConstructionWorks>();
            var responseData = _mapper.Map<IEnumerable<ConstructionWorksModel>>(dbConstructionWorks);

            return responseData;
        }

        public ConstructionWorksModel GetConstructionWorksById(Guid id)
        {
            var dbConstructionWorks = _contextEntities.Repository.GetById<ConstructionWorks>(id);

            var responseData = _mapper.Map<ConstructionWorksModel>(dbConstructionWorks);

            return responseData;
        }

        public ConstructionWorksModel CreateConstructionWorks(CreateConstructionWorksDto requestData)
        {
            var constructionWorks = _mapper.Map<ConstructionWorks>(requestData);
            constructionWorks.Id = Guid.NewGuid();

            _contextEntities.Create(constructionWorks);
            _contextEntities.Save();

            return GetConstructionWorksById(constructionWorks.Id);
        }

        public ConstructionWorksModel UpdateConstructionWorks(UpdateConstructionWorksDto requestData)
        {
            var dbConstructionWorks = _contextEntities.Repository.GetById<ConstructionWorks>(requestData.Id);

            _mapper.Map(requestData, dbConstructionWorks);

            _contextEntities.Save();

            return GetConstructionWorksById(dbConstructionWorks.Id);
        }

        public void DeleteConstructionWorks(Guid id)
        {
            _contextEntities.Delete<ConstructionWorks>(id);
            _contextEntities.Save();
        }
    }
}
