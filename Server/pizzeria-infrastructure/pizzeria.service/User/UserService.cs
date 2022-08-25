using Newtonsoft.Json;
using pizzeria.interfaces;
using pizzeria_api.interfaces.Models;
using pizzeria_api.Interfaces;
using System.Collections.Generic;
using System.IO;

namespace pizzeria.Service
{
    public class UserService : IUserService
    {

        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public List<User> GetAllUsers()
        {
            var userList = _userRepository.GetAllUser();
            return userList;
        }
    }

}
