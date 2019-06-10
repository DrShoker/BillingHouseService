using BH.ServiceLayer.DTOs.Common.Models;
using BH.ServiceLayer.DTOs.ProjectSchema;
using BH.ServiceLayer.DTOs.ProjectSchema.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BH.ServiceLayer.Services.Interfaces.User
{
    public interface IProjectSchemaService
    {
        IEnumerable<ListItemModel<Guid>> GetProjectSchemas(Guid projectId);
        ProjectSchemaModel GetProjectSchemaById(Guid projectId, Guid id);
        ProjectSchemaModel CreateProjectSchema(Guid projectId, CreateProjectSchemaDto requestData);
        ProjectSchemaModel UpdateProjectSchema(Guid projectId, UpdateProjectSchemaDto requestData);
        void DeleteProjectSchema(Guid id);
        IEnumerable<SchemaWallModel> GetSchemaWalls(Guid schemaId);
        SchemaWallModel GetSchemaWallById(Guid id);
        SchemaWallModel CreateSchemaWall(Guid schemaId, CreateSchemaWallDto requestData);
        SchemaWallModel UpdateSchemaWall(Guid schemaId, UpdateSchemaWallDto requestData);
        void DeleteSchemaWall(Guid id);
        void AddCompanyConstructionWorkToSchema(Guid schemaId, Guid workId);
        IEnumerable<CompConstWorkSchemaModel> GetCompConstWorkSchemaSum(Guid schemaId);
    }
}
