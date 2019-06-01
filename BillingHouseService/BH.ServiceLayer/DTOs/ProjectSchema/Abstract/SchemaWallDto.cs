using BH.DTOL.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace BH.ServiceLayer.DTOs.ProjectSchema.Abstract
{
    public abstract class SchemaWallDto
    {
        public decimal Area { get; set; }
        public TypeOfWallEnum Type { get; set; }
    }
}
