using System;
using System.Collections.Generic;
using System.Text;

namespace BH.ServiceLayer.DTOs.ConstructionMaterials.Models
{
    public class CompanyConstructionMaterialModel
    {
        public Guid Id { get; set; }
        public object Company { get; set; }
        public string ProductName{ get; set; }
        public decimal Price { get; set; }
    }
}
