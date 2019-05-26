using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using BH.DTOL.Entities;

namespace BH.ServiceLayer.Configurations.MapperProfiles.UserProfile
{
    public class PutUserRequestProfile : Profile
    {
        public PutUserRequestProfile()
        {
            CreateMap<PutUserRequestProfile, User>();
        }
    }
}
