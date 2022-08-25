using pizzeria.interfaces;
using pizzeria_api.interfaces.Models;
using pizzeria_api.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace pizzeria.Service
{
    public class OrderService : IOrderService
    {

        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public List<Order> GetAllOrdersByUserId(int userId)
        {
            List<Order> orders = _orderRepository.GetAllOrderByUserId(userId).OrderByDescending(k => k.OrderCreationTime).ToList();
            return orders;
        }

        public Order CreateOrder(Order order)
        {
            _orderRepository.CreateOrder(order);
            return order;
        }

    }
}
