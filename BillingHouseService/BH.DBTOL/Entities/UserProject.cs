using System;
using System.Collections.Generic;
using System.Text;
using BH.DTOL.Abstract;

namespace BH.DTOL.Entities
{
    public class UserProject : Entity<Guid>
    {
        public string Name { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public IEnumerable<ProjectScheme> ProjectShemes { get; set; }
    }
}
