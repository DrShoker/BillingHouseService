using BH.DTOL.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace BH.ServiceLayer.DTOs.ConstructionWorks.Abstract
{
    public abstract class ConstructionWorksDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public TypeOfConstructionWorksEnum TypeOfWorks { get; set; }
    }
}
