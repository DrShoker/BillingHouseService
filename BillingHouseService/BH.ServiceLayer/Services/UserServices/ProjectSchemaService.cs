using AutoMapper;
using BH.DTOL.Entities;
using BH.DTOL.Interfaces;
using BH.ServiceLayer.DTOs.Common.Models;
using BH.ServiceLayer.DTOs.ProjectSchema;
using BH.ServiceLayer.DTOs.ProjectSchema.Abstract;
using BH.ServiceLayer.DTOs.ProjectSchema.Models;
using BH.ServiceLayer.Services.Interfaces.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BH.ServiceLayer.Services.UserServices
{
    public class ProjectSchemaService : IProjectSchemaService
    {
        private readonly IUnitOfWork _contextEntities;
        private readonly IMapper _mapper;

        public ProjectSchemaService(IUnitOfWork contextEntities, IMapper mapper)
        {
            _mapper = mapper;
            _contextEntities = contextEntities;
        }

        public IEnumerable<ListItemModel<Guid>> GetProjectSchemas(Guid projectId)
        {
            var dbProjectSchemas = _contextEntities.Repository.GetAll<ProjectScheme>(projSch => projSch.UserProjectId == projectId);
            var responseData = _mapper.Map<IEnumerable<ListItemModel<Guid>>>(dbProjectSchemas);

            return responseData;
        }

        public ProjectSchemaModel GetProjectSchemaById(Guid projectId, Guid id)
        {
            var dbProject = _contextEntities.Repository.GetById<UserProject>(projectId);
            var dbSchema = _contextEntities.Repository.GetById<ProjectScheme>(id);
            var responseData = _mapper.Map<ProjectSchemaModel>(dbSchema);
            responseData.ProjectName = dbProject.Name;

            return responseData;
        }

        private void ValidateProjectSchema(Guid projectId, ProjectSchemaDto requestData)
        {
            var projectIncludeProps = new string[] { "ProjectShemes" };
            var dbProject = _contextEntities.Repository.GetById<UserProject>(projectId, projectIncludeProps);

            if (dbProject.ProjectShemes.Where(schema => schema.Name.Equals(requestData.Name)).Count() > 0)
                throw new Exception("Schema with this name is already exist");
        }

        public ProjectSchemaModel CreateProjectSchema(Guid projectId, CreateProjectSchemaDto requestData)
        {
            ValidateProjectSchema(projectId, requestData);

            var projectSchema = _mapper.Map<ProjectScheme>(requestData);
            projectSchema.Id = Guid.NewGuid();
            projectSchema.UserProjectId = projectId;

            _contextEntities.Create(projectSchema);
            _contextEntities.Save();

            return GetProjectSchemaById(projectId, projectSchema.Id);
        }

        public ProjectSchemaModel UpdateProjectSchema(Guid projectId, UpdateProjectSchemaDto requestData)
        {
            ValidateProjectSchema(projectId, requestData);

            var dbProjSchema = _contextEntities.Repository.GetById<ProjectScheme>(requestData.Id);

            _mapper.Map(requestData, dbProjSchema);

            _contextEntities.Save();

            return GetProjectSchemaById(projectId, dbProjSchema.Id);
        }

        public void DeleteProjectSchema(Guid id)
        {
            _contextEntities.Delete<ProjectScheme>(id);
            _contextEntities.Save();
        }

        public IEnumerable<SchemaWallModel> GetSchemaWalls(Guid schemaId)
        {
            var dbSchemaWalls = _contextEntities.Repository.GetAll<SchemeWall>(schWall => schWall.ProjectSchemeId == schemaId);
            var responseData = _mapper.Map<IEnumerable<SchemaWallModel>>(dbSchemaWalls);

            return responseData;
        }

        public SchemaWallModel GetSchemaWallById(Guid id)
        {
            var dbSchemaWall = _contextEntities.Repository.GetById<SchemeWall>(id);
            var responseData = _mapper.Map<SchemaWallModel>(dbSchemaWall);

            return responseData;
        }

        public SchemaWallModel CreateSchemaWall(Guid schemaId, CreateSchemaWallDto requestData)
        {
            _contextEntities.Repository.GetById<ProjectScheme>(schemaId);

            var schemaWall = _mapper.Map<SchemeWall>(requestData);
            schemaWall.Id = Guid.NewGuid();
            schemaWall.ProjectSchemeId = schemaId;

            _contextEntities.Create(schemaWall);
            _contextEntities.Save();

            return GetSchemaWallById(schemaWall.Id);
        }

        public SchemaWallModel UpdateSchemaWall(Guid schemaId, UpdateSchemaWallDto requestData)
        {
            _contextEntities.Repository.GetById<ProjectScheme>(schemaId);
            var dbSchemaWall = _contextEntities.Repository.GetById<SchemeWall>(requestData.Id);

            _mapper.Map(requestData, dbSchemaWall);

            _contextEntities.Save();

            return GetSchemaWallById(requestData.Id);
        }

        public void DeleteSchemaWall(Guid id)
        {
            _contextEntities.Delete<SchemeWall>(id);
            _contextEntities.Save();
        }

        public void AddCompanyConstructionWorkToSchema(Guid schemaId, Guid workId)
        {
            var schemeConstructionWork = new SchemeConstructionWorks()
            {
                CompanyConstructionWorksId = workId,
                SchemeId = schemaId,
                Id = Guid.NewGuid()
            };
            _contextEntities.Create(schemeConstructionWork);
            _contextEntities.Save();
        }
    }
}
