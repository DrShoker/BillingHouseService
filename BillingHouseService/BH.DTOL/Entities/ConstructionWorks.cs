using System;
using System.Collections.Generic;
using System.Text;
using BH.DTOL.Abstract;
using BH.DTOL.Enums;

namespace BH.DTOL.Entities
{
    public class ConstructionWorks : Entity<Guid>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public TypeOfConstructionWorksEnum TypeOfWorks { get; set; }
        public IEnumerable<SchemeConstructionWorks> SchemeConstructionWorks { get; set; }
    }
}
