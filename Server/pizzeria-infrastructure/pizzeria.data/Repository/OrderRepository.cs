using pizzeria.data.Helpers;
using pizzeria.interfaces;
using pizzeria_api.interfaces.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace pizzeria.data.Repository
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        public List<Order> GetAllOrder()
        {
            return GetAll("Order");
        }

        public List<Order> GetAllOrderByUserId(int userId)
        {
            return GetAllOrder().FindAll(k => k.UserId == userId);
        }

        public Order CreateOrder(Order order)
        {
            return Add(order, "Order");
        }
    }
}

