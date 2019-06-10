using BH.DTOL.Entities;
using BH.ServiceLayer.DTOs.ProjectSchema.Models;
using BH.ServiceLayer.Services.UserServices.CompConstWorkSchemaCoR.Handlers;
using System;
using System.Collections.Generic;
using System.Text;

namespace BH.ServiceLayer.Services.UserServices.CompConstWorkSchemaCoR
{
    public class CompConstWorkSchemaCoRDirector
    {
        public List<CompConstWorkSchemaModel> CompConstWorkSchemaModelList { get; set; }
        public CompConstWorkSchemaCoRDirector()
        {
            CompConstWorkSchemaModelList = new List<CompConstWorkSchemaModel>();
        }

        public IEnumerable<CompConstWorkSchemaModel> GetSchemaWorksSummary(ProjectScheme schema, IEnumerable<CompanyConstructionWorks> compConstWorks)
        {
            AbstractTypeHandler plasteringHandler = new OnPlasteringHandler();
            AbstractTypeHandler dismantlingHandler = new OnDismantlingHandler();
            AbstractTypeHandler installationHandler = new OnInstallationHandler();
            AbstractTypeHandler paintHandler = new OnPaintHandler();
            AbstractTypeHandler primingHandler = new OnPrimingHandler();
            AbstractTypeHandler spacklingHandler = new OnSpacklingHandler();

            plasteringHandler.Successor = dismantlingHandler;
            dismantlingHandler.Successor = installationHandler;
            installationHandler.Successor = paintHandler;
            paintHandler.Successor = primingHandler;
            primingHandler.Successor = spacklingHandler;

            foreach (var compConstWork in compConstWorks)
            {
                plasteringHandler.CheckSum(schema, compConstWork, CompConstWorkSchemaModelList);
            }

            return CompConstWorkSchemaModelList;
        }
    }
}
