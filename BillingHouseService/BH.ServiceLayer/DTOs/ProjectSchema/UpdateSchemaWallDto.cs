using BH.ServiceLayer.DTOs.ProjectSchema.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace BH.ServiceLayer.DTOs.ProjectSchema
{
    public class UpdateSchemaWallDto : SchemaWallDto
    {
        public Guid Id { get; set; }
    }
}
