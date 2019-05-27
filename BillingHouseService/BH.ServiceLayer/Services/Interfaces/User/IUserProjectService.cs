using BH.ServiceLayer.DTOs.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BH.ServiceLayer.Services.Interfaces.User
{
    public interface IUserProjectService
    {
        IEnumerable<ListItemModel<Guid>> GetUserProjects(Guid userId);
    }
}
