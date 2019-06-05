using BH.DTOL.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace BH.ServiceLayer.DTOs.ConstructionMaterials.Abstract
{
    public abstract class ConstructionMaterialDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public TypeOfConstructionMaterialEnum TypeOfMaterial { get; set; }
    }
}
