using BH.ServiceLayer.DTOs.ConstructionMaterials.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace BH.ServiceLayer.DTOs.ConstructionMaterials
{
    public class UpdateCompanyConstructionMaterialDto : CompanyConstructionMaterialDto
    {
        public Guid Id { get; set; }
    }
}
