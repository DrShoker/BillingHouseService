using AutoMapper;
using BH.DTOL.Entities;
using BH.ServiceLayer.DTOs.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BH.ServiceLayer.Configurations.MapperProfiles.UserProfile
{
    class UserProjectsProfile : Profile
    {
        public UserProjectsProfile()
        {
            CreateMap<UserProject, ListItemModel<Guid>>();
        }
    }
}
