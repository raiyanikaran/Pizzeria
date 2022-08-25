using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace TestPizzeria
{
    public class UserControllerTest : BaseUnitTest
    {
        public UserControllerTest() : base() { }

        [Fact]
        public async Task GetUsers()
        {
            var response = await HttpClient.GetAsync("/api/Users");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
