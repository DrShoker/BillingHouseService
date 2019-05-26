using System;
using System.Collections.Generic;
using System.Text;
using BH.DTOL.Abstract;
using BH.DTOL.Enums;

namespace BH.DTOL.Entities
{
    public class SchemeWall : Entity<Guid>
    {
        public decimal Area { get; set; }
        public Guid ProjectSchemeId { get; set; }
        public TypeOfWallEnum Type { get; set; }
        public ProjectScheme ProjectScheme { get; set; }
    }
}
