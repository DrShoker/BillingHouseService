using AutoMapper;
using BH.DTOL.Entities;
using BH.ServiceLayer.DTOs.ConstructionMaterials;
using BH.ServiceLayer.DTOs.ConstructionMaterials.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BH.ServiceLayer.Configurations.MapperProfiles.ConstructionMaterialsProfile
{
    public class CompanyConstructionMaterialProfile : Profile
    {
        public CompanyConstructionMaterialProfile()
        {
            CreateMap<CompanyConstructionMaterial, CompanyConstructionMaterialModel>()
                .ForMember(model => model.ProductName, opt => opt.MapFrom(prop => prop.ConstructionMaterial != null ? prop.ConstructionMaterial.Name : null))
                .ForMember(model => model.Company, opt => opt.MapFrom(prop => new { Id = prop.CompanyId, Name = prop.Company.Name }));
            CreateMap<CreateCompanyConstructionMaterialDto, CompanyConstructionMaterial>();
            CreateMap<UpdateCompanyConstructionMaterialDto, CompanyConstructionMaterial>()
                .ForMember(entity => entity.Company, opt => opt.Ignore())
                .ForMember(entity => entity.ConstructionMaterial, opt => opt.Ignore());
        }
    }
}