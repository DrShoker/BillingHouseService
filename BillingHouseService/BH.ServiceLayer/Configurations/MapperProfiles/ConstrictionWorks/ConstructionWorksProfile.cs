using AutoMapper;
using BH.DTOL.Entities;
using BH.ServiceLayer.Common.Extensions;
using BH.ServiceLayer.DTOs.ConstructionWorks;
using BH.ServiceLayer.DTOs.ConstructionWorks.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BH.ServiceLayer.Configurations.MapperProfiles.ConstrictionWorks
{
    class ConstructionWorksProfile : Profile
    {
        public ConstructionWorksProfile()
        {
            CreateMap<ConstructionWorks, ConstructionWorksModel>()
                .ForMember(model => model.TypeOfWorks, opt => opt.MapFrom(prop => new { Id = (int)prop.TypeOfWorks, Name = EnumExtensions.GetDescription(prop.TypeOfWorks) }));
            CreateMap<CreateConstructionWorksDto, ConstructionWorks>();
            CreateMap<UpdateConstructionWorksDto, ConstructionWorks>()
                .ForMember(cnstWrk => cnstWrk.SchemeConstructionWorks, opt => opt.Ignore());
        }
    }
}
