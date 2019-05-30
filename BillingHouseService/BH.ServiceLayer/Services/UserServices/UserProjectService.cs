using AutoMapper;
using BH.DTOL.Entities;
using BH.DTOL.Interfaces;
using BH.ServiceLayer.DTOs.Common.Models;
using BH.ServiceLayer.DTOs.UserProject;
using BH.ServiceLayer.DTOs.UserProject.Models;
using BH.ServiceLayer.Services.Interfaces.User;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using BH.ServiceLayer.DTOs.UserProject.Abstract;

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
            var responseData = _mapper.Map<IEnumerable<ListItemModel<Guid>>>(dbUserProjects);

            return responseData;
        }

        public UserProjectModel GetUserProjectById(Guid id)
        {
            var dbUserProject = _contextEntities.Repository.GetById<UserProject>(id);
            var usrProjModel = _mapper.Map<UserProjectModel>(dbUserProject);

            return usrProjModel;
        }

        private void ValidateUserProject(Guid userId, UserProjectDto requestData)
        {
            var userIncludeProps = new string[] { "UserProjects" };
            var dbUser = _contextEntities.Repository.GetById<User>(userId, userIncludeProps);

            if (dbUser.UserProjects.Where(usrProj => usrProj.Name.Equals(requestData.Name)).Count() > 0)
                throw new Exception("Project with this name is already exist");
        }

        public UserProjectModel CreateUserProject(Guid userId, CreateUserProjectDto requestData)
        {
            ValidateUserProject(userId, requestData);

            var userProject = _mapper.Map<UserProject>(requestData);
            userProject.Id = Guid.NewGuid();
            userProject.UserId = userId;

            _contextEntities.Create(userProject);
            _contextEntities.Save();

            return GetUserProjectById(userProject.Id);
        }

        public UserProjectModel UpdateUserProject(Guid userId, UpdateUserProjectDto requestData)
        {
            ValidateUserProject(userId, requestData);

            var dbUserProj = _contextEntities.Repository.GetById<UserProject>(requestData.Id);

            _mapper.Map(requestData, dbUserProj);

            _contextEntities.Save();

            return GetUserProjectById(dbUserProj.Id);
        }

        public void DeleteUserProject(Guid id)
        {
            _contextEntities.Delete<UserProject>(id);
            _contextEntities.Save();
        }
    }
}
