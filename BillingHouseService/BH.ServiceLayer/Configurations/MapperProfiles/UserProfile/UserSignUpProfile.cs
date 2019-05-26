using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using BH.DTOL.Entities;
using BH.ServiceLayer.DTOs.User;

namespace BH.ServiceLayer.Configurations.MapperProfiles.UserProfile
{
    public class UserSignUpProfile : Profile
    {
        public UserSignUpProfile()
        {
            CreateMap<UserSignUpDto, User>();
        }
    }
}
