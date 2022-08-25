using Microsoft.AspNetCore.Mvc;
using pizzeria_api.interfaces.Models;
using pizzeria_api.Interfaces;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace pizzeria_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService orderService;
        public OrdersController(IOrderService _orderService)
        {
            orderService = _orderService;
        }

        [HttpGet, Route("{userId}")]
        public ActionResult<List<Order>> GetOrders(int userId)
        {
            try
            {
                var orders = orderService.GetAllOrdersByUserId(userId);
                return Ok(orders);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
                throw;
            }
        }

        [HttpPost]
        public ActionResult<Order> CreateOrder([FromBody] Order order)
        {
            try
            {
                return Ok(orderService.CreateOrder(order));
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
                throw;
            }
        }

    }
}
