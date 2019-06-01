using BH.ServiceLayer.DTOs.Company.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace BH.ServiceLayer.DTOs.Company
{
    public class UpdateCompanyDto : CompanyDto
    {
        public Guid Id { get; set; }
    }
}
