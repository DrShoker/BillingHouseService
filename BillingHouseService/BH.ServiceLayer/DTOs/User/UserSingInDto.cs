using BH.ServiceLayer.Extensions.Hashing;
using System;
using System.Collections.Generic;
using System.Text;

namespace BH.ServiceLayer.DTOs.User
{
    public class UserSingInDto
    {
        private string password;
        private string email;

        public string Email { get; set; }
        public string Password { get; set; }
    }
}
