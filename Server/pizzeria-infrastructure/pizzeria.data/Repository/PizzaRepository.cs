using pizzeria.data.Helpers;
using pizzeria.interfaces.Items;
using pizzeria_api.interfaces.Models;
using System.Collections.Generic;
using System.Text;

namespace pizzeria.data.Repository
{
    public class PizzaRepository : BaseRepository<Pizza>, IPizzaRepository
    {
        public List<Pizza> GetAllPizza()
        {
            return GetAll("Pizza");
        }
    }
}
