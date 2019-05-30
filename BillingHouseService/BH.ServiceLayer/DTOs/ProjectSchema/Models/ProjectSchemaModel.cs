using System;
using System.Collections.Generic;
using System.Text;

namespace BH.ServiceLayer.DTOs.ProjectSchema.Models
{
    public class ProjectSchemaModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ProjectName { get; set; }
        public decimal? WallsArea { get; set; }
        public decimal? FloorArea { get; set; }
        public decimal? CeilingArea { get; set; }
        public decimal? CeilingPerimeter { get; set; }
        public decimal? FloorPerimeter { get; set; }
    }
}
