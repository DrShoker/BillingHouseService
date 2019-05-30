using BH.ServiceLayer.DTOs.ProjectSchema.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace BH.ServiceLayer.DTOs.ProjectSchema
{
    public class UpdateProjectSchemaDto : ProjectSchemaDto
    {
        public Guid Id { get; set; }
    }
}
