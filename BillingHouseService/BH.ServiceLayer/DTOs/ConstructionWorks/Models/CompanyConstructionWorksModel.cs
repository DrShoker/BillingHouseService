using System;
using System.Collections.Generic;
using System.Text;

namespace BH.ServiceLayer.DTOs.ConstructionWorks.Models
{
    public class CompanyConstructionWorksModel
    {
        public Guid Id { get; set; }
        public decimal Price { get; set; }
        public object ConstructionMaterial { get; set; }
        public object Company { get; set; }
    }
}
