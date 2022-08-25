using Moq;
using pizzeria.interfaces;
using pizzeria.Service;
using pizzeria_api.interfaces.Models;
using System.Collections.Generic;
using Xunit;

namespace pizzeria_unittest
{
    public class UserServiceTest
    {
        private readonly Mock<IUserRepository> _userRepositoryMock;
        private readonly UserService _userService;

        public UserServiceTest()
        {
            _userRepositoryMock = new Mock<IUserRepository>();
            _userService = new UserService(_userRepositoryMock.Object);
        }

        [Fact]
        public void GetAllUsers()
        {
            _userRepositoryMock.Setup(x => x.GetAllUser()).Returns(new List<User>());
            var result = _userService.GetAllUsers();
            _userRepositoryMock.Verify(x => x.GetAllUser());
            Assert.NotNull(result);
        }
    }
}
