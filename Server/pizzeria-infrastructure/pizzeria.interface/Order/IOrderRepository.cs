using pizzeria.interfaces.Common;
using pizzeria_api.interfaces.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace pizzeria.interfaces
{
    public interface IOrderRepository : IBaseRepository<Order>
    {
        List<Order> GetAllOrder();
        List<Order> GetAllOrderByUserId(int userId);
        Order CreateOrder(Order order);
    }
}
