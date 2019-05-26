using System;
using System.Collections.Generic;
using System.Text;

namespace BH.ServiceLayer.DTOs.User.Models
{
    public class UserSignInModel
    {
        public string Email { get; set; }
        public string DisplayName { get; set; }
        public string AuthToken { get; set; }
    }
}
