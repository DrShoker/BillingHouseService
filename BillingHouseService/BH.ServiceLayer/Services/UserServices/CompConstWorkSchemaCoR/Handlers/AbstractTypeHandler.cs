using BH.DTOL.Entities;
using BH.ServiceLayer.DTOs.ProjectSchema.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BH.ServiceLayer.Services.UserServices.CompConstWorkSchemaCoR.Handlers
{
    public abstract class AbstractTypeHandler
    {
        public AbstractTypeHandler Successor { get; set; }
        public abstract void CheckSum(ProjectScheme schema, CompanyConstructionWorks compConstWork, List<CompConstWorkSchemaModel> resultList);
    }
}
