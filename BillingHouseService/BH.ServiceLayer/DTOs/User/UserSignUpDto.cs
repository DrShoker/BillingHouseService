using BH.ServiceLayer.Extensions.Hashing;
using System;
using System.Collections.Generic;
using System.Text;

namespace BH.ServiceLayer.DTOs.User
{
    public class UserSignUpDto
    {
        private string password;
        private string repeatedPassword;
        private string email;

        public string Email
        {
            get { return email; }
            set { email = value.ToLower(); }
        }
        public string Password { get; set; }

        public string RepeatedPassword { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
