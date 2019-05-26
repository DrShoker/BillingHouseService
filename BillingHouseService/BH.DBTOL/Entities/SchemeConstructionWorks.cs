using System;
using System.Collections.Generic;
using System.Text;
using BH.DTOL.Abstract;

namespace BH.DTOL.Entities
{
    public class SchemeConstructionWorks
    {
        public Guid SchemeId { get; set; }
        public Guid ConstructionWorksId { get; set; }
        public ProjectScheme ProjectScheme { get; set; }
        public ConstructionWorks ConstructionWorks { get; set; }
    }
}
