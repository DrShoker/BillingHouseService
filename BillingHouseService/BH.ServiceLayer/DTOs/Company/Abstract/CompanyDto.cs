using System;
using System.Collections.Generic;
using System.Text;

namespace BH.ServiceLayer.DTOs.Company.Abstract
{
    public abstract class CompanyDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string HomePageLink { get; set; }
    }
}
