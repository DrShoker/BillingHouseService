using AutoMapper;
using BH.DTOL.Entities;
using BH.ServiceLayer.DTOs.Common.Models;
using BH.ServiceLayer.DTOs.UserProject;
using BH.ServiceLayer.DTOs.UserProject.Models;
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
            CreateMap<UserProject, UserProjectModel>();
            CreateMap<CreateUserProjectDto, UserProject>();
            CreateMap<UpdateUserProjectDto, UserProject>()
                .ForMember(usrProj => usrProj.ProjectShemes, opt => opt.Ignore())
                .ForMember(usrProj => usrProj.UserId, opt => opt.Ignore());
        }
    }
}
