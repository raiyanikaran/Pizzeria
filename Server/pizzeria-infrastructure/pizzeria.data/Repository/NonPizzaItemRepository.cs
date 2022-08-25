using pizzeria.data.Helpers;
using pizzeria.interfaces.Items;
using pizzeria_api.interfaces.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace pizzeria.data.Repository
{
    public class NonPizzaItemRepository : BaseRepository<NonPizzaItem>, INonPizzaItemRepository
    {
        public List<NonPizzaItem> GetAllNonPizzaItem()
        {
            return GetAll("NonPizzaItem");
        }
    }
}
