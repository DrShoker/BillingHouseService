using System;
using System.Collections.Generic;
using System.Text;
using BH.DTOL.Abstract;

namespace BH.DTOL.Entities
{
    public class CompanyContactPhones : Entity<Guid>
    {
        public string PhoneNumber { get; set; }
        public Guid CompanyId { get; set; }
        public Company Company { get; set; }
    }
}
