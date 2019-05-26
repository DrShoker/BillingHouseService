using System;
using System.Collections.Generic;
using System.Text;
using BH.DTOL.Abstract;

namespace BH.DTOL.Entities
{
    public class UserFeedbackAboutCompany : Entity<Guid>
    {
        public string Message { get; set; }
        public DateTime DateOfCreation { get; set; }
        public Guid UserId { get; set; }
        public Guid CompanyId { get; set; }
        public User User { get; set; }
        public Company Company { get; set; }
    }
}
