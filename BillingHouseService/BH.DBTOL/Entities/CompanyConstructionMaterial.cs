using System;
using System.Collections.Generic;
using System.Text;
using BH.DTOL.Abstract;

namespace BH.DTOL.Entities
{
    public class CompanyConstructionMaterial : Entity<Guid>
    {
        public decimal Price { get; set; }
        public Guid ConstructionMaterialId { get; set; }
        public Guid CompanyId { get; set; }
        public ConstructionMaterial ConstructionMaterial { get; set; }
        public Company Company { get; set; }
    }
}
