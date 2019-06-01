using AutoMapper;
using BH.DTOL.Entities;
using BH.ServiceLayer.DTOs.Common.Models;
using BH.ServiceLayer.DTOs.Company;
using BH.ServiceLayer.DTOs.Company.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BH.ServiceLayer.Configurations.MapperProfiles.CompanyProfile
{
    public class CompanyProfile : Profile
    {
        public CompanyProfile()
        {
            CreateMap<Company, ListItemModel<Guid>>();
            CreateMap<Company, CompanyModel>();
            CreateMap<CreateCompanyDto, Company>();
            CreateMap<UpdateCompanyDto, Company>()
                .ForMember(comp => comp.ConstructionMaterials, opt => opt.Ignore())
                .ForMember(comp => comp.ConstructionWorks, opt => opt.Ignore())
                .ForMember(comp => comp.ContactPhones, opt => opt.Ignore())
                .ForMember(comp => comp.Feedbacks, opt => opt.Ignore());
        }
    }
}
