using System;
using System.Collections.Generic;
using System.Text;

namespace BH.ServiceLayer.DTOs.ConstructionWorks.Abstract
{
    public abstract class CompanyConstructionWorksDto
    {
        public decimal Price { get; set; }
        public Guid ConstructionMaterialId { get; set; }
        public Guid CompanyId { get; set; }
    }
}
