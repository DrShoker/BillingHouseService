using System;
using System.Collections.Generic;
using System.Text;

namespace BH.DTOL.Entities
{
    public class CompanyConstructionWorksConstructionMaterial
    {
        public Guid CompanyConstructionWorksId { get; set; }
        public Guid ConstructionMaterialId { get; set; }
        public CompanyConstructionWorks CompanyConstructionWorks { get; set; }
        public ConstructionMaterial ConstructionMaterial { get; set; }
    }
}
