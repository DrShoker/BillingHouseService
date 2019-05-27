using AutoMapper;
using BH.DTOL.Entities;
using BH.DTOL.Interfaces;
using BH.ServiceLayer.DTOs.Common.Models;
using BH.ServiceLayer.Services.Interfaces.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace BH.ServiceLayer.Services.UserServices
{
    public class UserProjectService : IUserProjectService
    {
        private readonly IUnitOfWork _contextEntities;
        private readonly IMapper _mapper;

        public UserProjectService(IUnitOfWork contextEntities, IMapper mapper)
        {
            _mapper = mapper;
            _contextEntities = contextEntities;
        }

        public IEnumerable<ListItemModel<Guid>> GetUserProjects(Guid userId)
        {
            var dbUserProjects = _contextEntities.Repository.GetAll<UserProject>(usrProj => usrProj.UserId == userId);
            var responseData = _mapper.Map<IEnumerable<UserProject>, IEnumerable<ListItemModel<Guid>>>(dbUserProjects);

            return responseData;
        }
    }
}
