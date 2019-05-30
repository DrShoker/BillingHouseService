using AutoMapper;
using BH.DTOL.Entities;
using BH.ServiceLayer.DTOs.Common.Models;
using BH.ServiceLayer.DTOs.ProjectSchema;
using BH.ServiceLayer.DTOs.ProjectSchema.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BH.ServiceLayer.Configurations.MapperProfiles.UserProfile
{
    public class ProjectSchemasProfile : Profile
    {
        public ProjectSchemasProfile()
        {
            CreateMap<ProjectScheme, ListItemModel<Guid>>();
            CreateMap<ProjectScheme, ProjectSchemaModel>()
                .ForMember(model => model.ProjectName, opt => opt.Ignore());
            CreateMap<CreateProjectSchemaDto, ProjectScheme>();
            CreateMap<UpdateProjectSchemaDto, ProjectScheme>()
                .ForMember(projSch => projSch.UserProjectId, opt => opt.Ignore())
                .ForMember(projSch => projSch.Walls, opt => opt.Ignore());
            CreateMap<SchemeWall, SchemaWallModel>();
        }
    }
}
