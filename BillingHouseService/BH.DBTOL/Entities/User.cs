using System;
using System.Collections.Generic;
using System.Text;
using BH.DTOL.Abstract;

namespace BH.DTOL.Entities
{
    public class User : Entity<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password {
            get { return this.Password; }
            set { this.Password = this.Password.GetHashCode().ToString(); }
        }
        public IEnumerable<UserProject> UserProjects { get; set; }
        public string DisplayName { get { return $"{this.FirstName} {this.LastName}"; } }
    }
}
