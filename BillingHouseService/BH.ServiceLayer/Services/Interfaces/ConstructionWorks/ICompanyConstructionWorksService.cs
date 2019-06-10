using BH.ServiceLayer.DTOs.ConstructionWorks;
using BH.ServiceLayer.DTOs.ConstructionWorks.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BH.ServiceLayer.Services.Interfaces.ConstructionWorks
{
    public interface ICompanyConstructionWorksService
    {
        IEnumerable<CompanyConstructionWorksModel> GetCompanyConstructionWorksByWorksId(Guid worksId);
        CompanyConstructionWorksModel GetCompanyConstructionWorksById(Guid id);
        CompanyConstructionWorksModel CreateCompanyConstructionWorks(CreateCompanyConstructionWorksDto requestData);
        CompanyConstructionWorksModel UpdateCompanyConstructionWorks(UpdateCompanyConstructionWorksDto requestData);
        void DeleteCompanyConstructionWorks(Guid id);
    }
}
