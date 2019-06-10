using AutoMapper;
using BH.DTOL.Entities;
using BH.ServiceLayer.DTOs.ConstructionWorks;
using BH.ServiceLayer.DTOs.ConstructionWorks.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BH.ServiceLayer.Configurations.MapperProfiles.ConstrictionWorksProfile
{
    public class CompanyConstaructionWorksProfile : Profile
    {
        public CompanyConstaructionWorksProfile()
        {
            CreateMap<CompanyConstructionWorks, CompanyConstructionWorksModel>()
                .ForMember(model => model.Company, opt => opt.MapFrom(prop => prop.Company != null ? new { Id = prop.Company.Id, Name = prop.Company.Name } : null))
                .ForMember(model => model.ConstructionWork, opt => opt.MapFrom(prop => prop.ConstructionWorks != null ? new { Id = prop.ConstructionWorks.Id, Name = prop.ConstructionWorks.Name } : null))
                .ForMember(model => model.Price, opt => opt.MapFrom(prop => prop.PricePerSquareMeter));
            CreateMap<CreateCompanyConstructionWorksDto, CompanyConstructionWorks>();
            CreateMap<UpdateCompanyConstructionWorksDto, CompanyConstructionWorks>()
                .ForMember(entity => entity.Company, opt => opt.Ignore())
                .ForMember(entity => entity.ConstructionWorks, opt => opt.Ignore());

        }
    }
}
