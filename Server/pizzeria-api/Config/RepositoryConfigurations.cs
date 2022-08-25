using Microsoft.Extensions.DependencyInjection;
using pizzeria.data.Repository;
using pizzeria.interfaces;
using pizzeria.interfaces.Items;

namespace pizzeria_api.Config
{
    public static class RepositoryConfigurations
    {
        public static IServiceCollection AddRepository(this IServiceCollection services)
        {
            services.AddScoped<IPizzaRepository, PizzaRepository>();
            services.AddScoped<INonPizzaItemRepository, NonPizzaItemRepository>();
            services.AddScoped<IIngredientRepository, IngredientRepository>();
            services.AddScoped<IToppingRepository, ToppingRepository>();
            services.AddScoped<ICheeseRepository, CheeseRepository>();
            services.AddScoped<ICrustSauceRepository, CrustSauceRepository>();
            services.AddScoped<ICrustSizeRepository, CrustSizeRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            return services;
        }
    }
}
