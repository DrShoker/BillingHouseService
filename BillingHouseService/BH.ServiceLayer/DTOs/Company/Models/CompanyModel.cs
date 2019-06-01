using System;
using System.Collections.Generic;
using System.Text;

namespace BH.ServiceLayer.DTOs.Company.Models
{
    public class CompanyModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string HomePageLink { get; set; }
    }
}
