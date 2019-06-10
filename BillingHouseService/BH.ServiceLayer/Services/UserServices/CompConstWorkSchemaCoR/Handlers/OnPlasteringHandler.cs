using System;
using System.Collections.Generic;
using System.Text;
using BH.DTOL.Entities;
using BH.DTOL.Enums;
using BH.ServiceLayer.DTOs.ProjectSchema.Models;
using BH.ServiceLayer.Services.UserServices.CompConstWorkSchemaCoR.Handlers;

namespace BH.ServiceLayer.Services.UserServices.CompConstWorkSchemaCoR.Handlers
{
    public class OnPlasteringHandler : AbstractTypeHandler
    {
        public override void CheckSum(ProjectScheme schema, CompanyConstructionWorks compConstWork, List<CompConstWorkSchemaModel> resultList)
        {
            if (compConstWork.ConstructionWorks.TypeOfWorks == TypeOfConstructionWorksEnum.Plastering)
            {
                var paramVal = schema.WallsArea.HasValue ? schema.WallsArea.Value : 0;
                var result = new CompConstWorkSchemaModel
                {
                    WorkName = compConstWork.ConstructionWorks.Name,
                    ParameterValue = paramVal,
                    WorkSum = paramVal * compConstWork.PricePerSquareMeter
                };
                resultList.Add(result);
            }
            else if (Successor != null)
            {
                Successor.CheckSum(schema, compConstWork, resultList);
            }
        }
    }
}
