using System;
using System.Collections.Generic;
using System.Text;
using BH.DTOL.Abstract;

namespace BH.DTOL.Entities
{
    public class CompanyConstructionWorks : Entity<Guid>
    {
        public decimal PricePerSquareMeter { get; set; }
        public Guid ConstructionWorksId { get; set; }
        public Guid CompanyId { get; set; }
        public ConstructionWorks ConstructionWorks { get; set; }
        public Company Company { get; set; }
        public IEnumerable<CompanyConstructionWorksConstructionMaterial> CompanyConstructionWorksConstructionMaterials { get; set; }
        public IEnumerable<SchemeConstructionWorks> SchemeConstructionWorks { get; set; }
    }
}
