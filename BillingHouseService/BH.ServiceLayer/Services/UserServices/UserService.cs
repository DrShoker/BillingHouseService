using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using BH.DTOL.Entities;
using BH.DTOL.Interfaces;
using BH.ServiceLayer.DTOs.User;
using BH.ServiceLayer.DTOs.User.Models;
using BH.ServiceLayer.Services.Interfaces.User;

namespace BH.ServiceLayer.Services.UserServices
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _contextEntities;
        private readonly IMapper _mapper;

        public UserService(IUnitOfWork contextEntities, IMapper mapper)
        {
            _mapper = mapper;
            _contextEntities = contextEntities;
        }

        public void SignUpUser(UserSignUpDto userRequestData)
        {
            if (userRequestData.Password != userRequestData.RepeatedPassword)
                throw new Exception("Wrong repeated password");

            var userToCreate = _mapper.Map<UserSignUpDto, User>(userRequestData);

            userToCreate.Id = Guid.NewGuid();

            _contextEntities.Create(userToCreate);
            _contextEntities.Save();
        }

        public UserSignInModel SingInUser(UserSingInDto userRequestData)
        {
            var dbUser = _contextEntities.Repository.GetAll<User>(usr =>
                usr.Email == userRequestData.Email &&
                usr.Password == userRequestData.Password)
            .First();
            var responseData = _mapper.Map<User, UserSignInModel>(dbUser);

            return responseData;
        }
    }
}
