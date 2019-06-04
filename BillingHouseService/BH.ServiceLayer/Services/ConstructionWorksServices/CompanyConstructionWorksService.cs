using AutoMapper;
using BH.DTOL.Interfaces;
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
    }
}
