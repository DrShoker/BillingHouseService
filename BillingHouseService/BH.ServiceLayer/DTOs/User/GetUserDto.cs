using System;
using System.Collections.Generic;
using System.Text;

namespace BH.ServiceLayer.DTOs.User
{
    public class GetUserDto
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
