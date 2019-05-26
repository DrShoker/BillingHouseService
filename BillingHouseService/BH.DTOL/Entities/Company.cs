using System;
using System.Collections.Generic;
using System.Text;
using BH.DTOL.Abstract;

namespace BH.DTOL.Entities
{
    public class Company : Entity<Guid>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string HomePageLink { get; set; }
        public IEnumerable<CompanyContactPhones> ContactPhones { get; set; }
        public IEnumerable<UserFeedbackAboutCompany> Feedbacks { get; set; }
        public IEnumerable<CompanyConstructionWorks> ConstructionWorks { get; set; }
        public IEnumerable<CompanyConstructionMaterial> ConstructionMaterials { get; set; }
    }
}