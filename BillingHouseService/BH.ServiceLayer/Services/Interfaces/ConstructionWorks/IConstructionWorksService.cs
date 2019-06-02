using BH.ServiceLayer.DTOs.ConstructionWorks;
using BH.ServiceLayer.DTOs.ConstructionWorks.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BH.ServiceLayer.Services.Interfaces.ConstructionWorks
{
    public interface IConstructionWorksService
    {
        IEnumerable<ConstructionWorksModel> GetConstructionWorks();
        ConstructionWorksModel GetConstructionWorksById(Guid id);
        ConstructionWorksModel CreateConstructionWorks(CreateConstructionWorksDto requestData);
        ConstructionWorksModel UpdateConstructionWorks(UpdateConstructionWorksDto requestData);
        void DeleteConstructionWorks(Guid id);
    }
}
