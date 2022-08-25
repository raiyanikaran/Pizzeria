using Moq;
using pizzeria.interfaces;
using pizzeria.Service;
using pizzeria_api.interfaces.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace pizzeria_unittest
{
    public class OrderServiceTest
    {
        private readonly Mock<IOrderRepository> _orderRepositoryMock;
        private readonly OrderService _orderService;

        public OrderServiceTest()
        {
            _orderRepositoryMock = new Mock<IOrderRepository>();
            _orderService = new OrderService(_orderRepositoryMock.Object);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        public void GetAllOrdersByUserId(int userId)
        {
            _orderRepositoryMock.Setup(x => x.GetAllOrderByUserId(userId)).Returns(new List<Order>());
            var result = _orderService.GetAllOrdersByUserId(userId);
            _orderRepositoryMock.Verify(x => x.GetAllOrderByUserId(userId));
            Assert.NotNull(result);
        }

        [Fact]
        public void CreateOrder()
        {
            _orderRepositoryMock.Setup(x => x.Add(It.IsAny<Order>(), "Order")).Returns(new Order());
            var result = _orderService.CreateOrder(new Order { Id = 1 });
            Assert.NotNull(result);
        }
    }
}
