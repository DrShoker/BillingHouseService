using BH.ServiceLayer.DTOs.ConstructionMaterials;
using BH.ServiceLayer.DTOs.ConstructionMaterials.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BH.ServiceLayer.Services.Interfaces.ConstructionMaterial
{
    public interface IConstructionMaterialService
    {
        IEnumerable<ConstructionMaterialModel> GetConstructionMaterials();
        ConstructionMaterialModel GetConstructionMaterialById(Guid id);
        ConstructionMaterialModel CreateConstructionWMaterial(CreateConstructionMaterialDto requestData);
        ConstructionMaterialModel UpdateConstructionMaterial(UpdateConstructionMaterialDto requestData);
        void DeleteConstructionMaterial(Guid id);
    }
}
