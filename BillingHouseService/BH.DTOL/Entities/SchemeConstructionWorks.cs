using System;
using System.Collections.Generic;
using System.Text;
using BH.DTOL.Abstract;

namespace BH.DTOL.Entities
{
    public class SchemeConstructionWorks : Entity<Guid>
    {
        public Guid SchemeId { get; set; }
        public Guid CompanyConstructionWorksId { get; set; }
        public ProjectScheme ProjectScheme { get; set; }
        public CompanyConstructionWorks ConstructionWorks { get; set; }
    }
}
