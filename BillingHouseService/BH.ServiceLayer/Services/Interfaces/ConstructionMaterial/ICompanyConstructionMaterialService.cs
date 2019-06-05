using BH.ServiceLayer.DTOs.ConstructionMaterials;
using BH.ServiceLayer.DTOs.ConstructionMaterials.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BH.ServiceLayer.Services.Interfaces.ConstructionMaterial
{
    public interface ICompanyConstructionMaterialService
    {
        IEnumerable<CompanyConstructionMaterialModel> GetCompanyConstructionMaterials(Guid companyId, Guid materialId);
        CompanyConstructionMaterialModel GetCompanyConstructionMaterialById(Guid id);
        CompanyConstructionMaterialModel CreateCompanyConstructionWMaterial(CreateCompanyConstructionMaterialDto requestData);
        CompanyConstructionMaterialModel UpdateCompanyConstructionMaterial(UpdateCompanyConstructionMaterialDto requestData);
        void DeleteCompanyConstructionMaterial(Guid id);
    }
}
