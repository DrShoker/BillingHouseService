using AutoMapper;
using BH.DTOL.Entities;
using BH.ServiceLayer.DTOs.User;
using BH.ServiceLayer.DTOs.User.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BH.ServiceLayer.Configurations.MapperProfiles.UserProfile
{
    public class UserSingInProfile : Profile
    {
        public UserSingInProfile()
        {
            CreateMap<User, UserSignInModel>();
            CreateMap<UserSingInDto, User>();
        }
    }
}
