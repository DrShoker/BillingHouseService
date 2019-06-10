using BH.ServiceLayer.DTOs.ConstructionWorks.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace BH.ServiceLayer.DTOs.ConstructionWorks
{
    public class UpdateCompanyConstructionWorksDto : CompanyConstructionWorksDto
    {
        public Guid Id { get; set; }
    }
}
