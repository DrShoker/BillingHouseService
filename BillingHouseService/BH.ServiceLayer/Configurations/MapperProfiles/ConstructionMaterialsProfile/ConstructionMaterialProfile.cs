using AutoMapper;
using BH.DTOL.Entities;
using BH.ServiceLayer.Common.Extensions;
using BH.ServiceLayer.DTOs.ConstructionMaterials;
using BH.ServiceLayer.DTOs.ConstructionMaterials.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BH.ServiceLayer.Configurations.MapperProfiles.ConstructionMaterialsProfile
{
    class ConstructionMaterialProfile : Profile
    {
        public ConstructionMaterialProfile()
        {
            CreateMap<ConstructionMaterial, ConstructionMaterialModel>()
                .ForMember(model => model.TypeOfMaterial, opt => opt.MapFrom(prop => new { Id = (int)prop.TypeOfMaterial, Name = EnumExtensions.GetDescription(prop.TypeOfMaterial) }));
            CreateMap<CreateConstructionMaterialDto, ConstructionMaterial>();
            CreateMap<UpdateConstructionMaterialDto, ConstructionMaterial>()
                .ForMember(cnstMat => cnstMat.CompanyConstructionWorksConstructionMaterials, opt => opt.Ignore());
        }
    }
}
