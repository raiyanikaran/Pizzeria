using pizzeria.data.Helpers;
using pizzeria.interfaces;
using pizzeria_api.interfaces.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace pizzeria.data.Repository
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public List<User> GetAllUser()
        {
            return GetAll("User");
        }
    }
}
