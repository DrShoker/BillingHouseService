using System;
using System.Collections.Generic;
using System.Text;
using BH.DTOL.Abstract;

namespace BH.DTOL.Entities
{
    public class ProjectScheme : Entity<Guid>
    {
        public string Name { get; set; }
        public decimal? WallsArea { get; set; }
        public decimal? FloorArea { get; set; }
        public decimal? CeilingArea { get; set; }
        public decimal? CeilingPerimeter { get; set; }
        public decimal? FloorPerimeter { get; set; }
        public Guid UserProjectId { get; set; }
        public UserProject UserProject { get; set; }
        public IEnumerable<SchemeWall> Walls { get; set; }
        public IEnumerable<SchemeConstructionWorks> SchemeConstructionWorks { get; set; }
    }
}
