using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TestPizzeria
{
    public class OrderControllerTest : BaseUnitTest
    {
        public OrderControllerTest() : base() { }

        [Theory]
        [InlineData(1)]
        public async Task GetOrders(int userId)
        {
            var response = await HttpClient.GetAsync("/api/Orders/" + userId); ;
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task CreateOrder()
        {
            var payload = "{\"Id\":1661269511356,\"UserId\":1,\"NonPizzaItems\":[],\"Pizzas\":" +
                "[{\"Id\":1661269510169,\"Name\":\"Chilli Paneer\",\"Price\":940,\"Image\":\"http://localhost:5000/chilli-paneer-pizza.png\",\"IngredientIDs\":[\"ONION\",\"CAPS\",\"TOMT\",\"PNR\"]," +
                "\"ToppingIDs\":[\"PEPRN\",\"ONION\",\"PNR\",\"CAPS\"],\"CheeseIDs\":[\"MOZ\",\"CHED\",\"MAYO\"],\"CrustSauceIDs\":[\"CHEESE\",\"RANCH\"],\"SizeId\":\"LRG\",\"Quantity\":1}]," +
                "\"OrderStatus\":null,\"TotalAmmount\":940,\"OrderCreationTime\":\"2022-08-23T15:45:11.35Z\"}";

            HttpContent c = new StringContent(payload, Encoding.UTF8, "application/json");
            var response = await HttpClient.PostAsync("/api/Orders/", c); ;
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }


    }
}
