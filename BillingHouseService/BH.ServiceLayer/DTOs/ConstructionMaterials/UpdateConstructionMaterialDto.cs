using BH.ServiceLayer.DTOs.ConstructionMaterials.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace BH.ServiceLayer.DTOs.ConstructionMaterials
{
    public class UpdateConstructionMaterialDto : ConstructionMaterialDto
    {
        public Guid Id { get; set; }
    }
}
