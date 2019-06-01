using AutoMapper;
using BH.DTOL.Entities;
using BH.ServiceLayer.DTOs.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BH.ServiceLayer.Configurations.MapperProfiles.CompanyProfile
{
    class CompanyContactPhonesProfile : Profile
    {
        public CompanyContactPhonesProfile()
        {
            CreateMap<CompanyContactPhones, ListItemModel<Guid>>()
                .ForMember(model => model.Name, opt => opt.MapFrom(prop => prop.PhoneNumber));
        }
    }
}
