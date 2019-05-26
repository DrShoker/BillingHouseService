using BH.ServiceLayer.Extensions.Hashing;
using System;
using System.Collections.Generic;
using System.Text;

namespace BH.ServiceLayer.DTOs.User
{
    public class PutUserRequestDto
    {
        private string password;
        private string repeatedPassword;
        private string newPassword;

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string RepeatedPassword { get; set; }
        public string NewPassword { get; set; }
    }
}
