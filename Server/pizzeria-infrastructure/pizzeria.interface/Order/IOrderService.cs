using pizzeria_api.interfaces.Models;
using System.Collections.Generic;

namespace pizzeria_api.Interfaces
{
    public interface IOrderService
    {
        List<Order> GetAllOrdersByUserId(int userId);
        Order CreateOrder(Order order);
    }
}
