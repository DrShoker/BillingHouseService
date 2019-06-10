using System;
using System.Collections.Generic;
using System.Text;

namespace BH.ServiceLayer.DTOs.ConstructionMaterials.Abstract
{
    public abstract class CompanyConstructionMaterialDto
    {
        public decimal Price { get; set; }
        public Guid CompanyId { get; set; }
        public Guid Materiald { get; set; }
    }
}
