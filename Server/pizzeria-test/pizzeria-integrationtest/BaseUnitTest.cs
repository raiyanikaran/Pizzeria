using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using pizzeria.data.Repository;
using pizzeria.interfaces;
using pizzeria.interfaces.Items;
using pizzeria.Service;
using pizzeria_api;
using pizzeria_api.Interfaces;
using pizzeria_api.Interfaces.Items;
using System.Net.Http;
namespace TestPizzeria
{
    public class BaseUnitTest : WebApplicationFactory<Program>
    {
        private HttpClient httpClient;
        public HttpClient HttpClient
        {
            get
            {
                if (httpClient == null)
                {
                    httpClient = CreateClient();
                }
                return httpClient;
            }
        }
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.UseWebRoot("Assets");
            builder.ConfigureServices(services =>
            {
                services.AddScoped<IUserService, UserService>();
                services.AddScoped<IOrderService, OrderService>();
                services.AddScoped<IItemService, ItemService>();
                services.AddScoped<IPizzaRepository, PizzaRepository>();
                services.AddScoped<INonPizzaItemRepository, NonPizzaItemRepository>();
                services.AddScoped<IIngredientRepository, IngredientRepository>();
                services.AddScoped<IToppingRepository, ToppingRepository>();
                services.AddScoped<ICheeseRepository, CheeseRepository>();
                services.AddScoped<ICrustSauceRepository, CrustSauceRepository>();
                services.AddScoped<ICrustSizeRepository, CrustSizeRepository>();
                services.AddScoped<IOrderRepository, OrderRepository>();
                services.AddScoped<IUserRepository, UserRepository>();
            });
            builder.UseUrls("http://localhost:5000");
            base.ConfigureWebHost(builder);
        }
    }
}
