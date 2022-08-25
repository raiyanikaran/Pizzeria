using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace TestPizzeria
{
    public class ItemControllerTest : BaseUnitTest
    {
        public ItemControllerTest() : base() { }

        [Fact]
        public async Task GetAllItems()
        {
            var response = await HttpClient.GetAsync("/api/Items");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
