using BH.ServiceLayer.DTOs.Common.Models;
using BH.ServiceLayer.DTOs.UserProject;
using BH.ServiceLayer.DTOs.UserProject.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BH.ServiceLayer.Services.Interfaces.User
{
    public interface IUserProjectService
    {
        IEnumerable<ListItemModel<Guid>> GetUserProjects(Guid userId);
        UserProjectModel GetUserProjectById(Guid id);
        UserProjectModel CreateUserProject(Guid userId, CreateUserProjectDto requestData);
        UserProjectModel UpdateUserProject(Guid userId, UpdateUserProjectDto requestData);
        void DeleteUserProject(Guid id);
    }
}
