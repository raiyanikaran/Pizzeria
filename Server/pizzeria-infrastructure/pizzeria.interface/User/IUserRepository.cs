using pizzeria.interfaces.Common;
using pizzeria_api.interfaces.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace pizzeria.interfaces
{
    public interface IUserRepository : IBaseRepository<User>
    {
        List<User> GetAllUser();
    }
}
