using pizzeria_api.interfaces.Models;
using System.Collections.Generic;

namespace pizzeria_api.Interfaces
{
    public interface IUserService
    {
        List<User> GetAllUsers();
    }
}
