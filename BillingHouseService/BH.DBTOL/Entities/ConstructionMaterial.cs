using System;
using System.Collections.Generic;
using System.Text;
using BH.DTOL.Abstract;
using BH.DTOL.Enums;

namespace BH.DTOL.Entities
{
    public class ConstructionMaterial : Entity<Guid>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public TypeOfConstructionMaterialEnum TypeOfMaterial { get; set; }
        public IEnumerable<CompanyConstructionWorksConstructionMaterial> CompanyConstructionWorksConstructionMaterials { get; set; }
    }
}
