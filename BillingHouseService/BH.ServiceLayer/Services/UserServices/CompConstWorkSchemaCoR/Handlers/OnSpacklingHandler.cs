using BH.DTOL.Entities;
using BH.DTOL.Enums;
using BH.ServiceLayer.DTOs.ProjectSchema.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BH.ServiceLayer.Services.UserServices.CompConstWorkSchemaCoR.Handlers
{
    public class OnSpacklingHandler : AbstractTypeHandler
    {
        public override void CheckSum(ProjectScheme schema, CompanyConstructionWorks compConstWork, List<CompConstWorkSchemaModel> resultList)
        {
            if (compConstWork.ConstructionWorks.TypeOfWorks == TypeOfConstructionWorksEnum.Walls_Spackling_work)
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
            else if (compConstWork.ConstructionWorks.TypeOfWorks == TypeOfConstructionWorksEnum.Floor_Spackling_work)
            {
                var paramVal = schema.WallsArea.HasValue ? schema.FloorArea.Value : 0;
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
