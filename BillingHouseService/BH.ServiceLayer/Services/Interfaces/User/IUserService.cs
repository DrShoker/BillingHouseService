using System;
using System.Collections.Generic;
using System.Text;
using BH.ServiceLayer.DTOs.User;
using BH.ServiceLayer.DTOs.User.Models;

namespace BH.ServiceLayer.Services.Interfaces.User
{
    public interface IUserService
    {
        void SignUpUser(UserSignUpDto userRequestData);
        UserSignInModel SingInUser(UserSingInDto userRequestData);
        
    }
}
