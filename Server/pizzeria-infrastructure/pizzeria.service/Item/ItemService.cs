using pizzeria.interfaces.Items;
using pizzeria_api.interfaces.Models;
using pizzeria_api.Interfaces.Items;

namespace pizzeria.Service
{
    public class ItemService : IItemService
    {
        private readonly IPizzaRepository _pizzaRepository;
        private readonly INonPizzaItemRepository _nonPizzaItemRepository;
        private readonly IToppingRepository _toppingRepository;
        private readonly ICheeseRepository _cheeseRepository;
        private readonly ICrustSizeRepository _crustSizeRepository;
        private readonly ICrustSauceRepository _crustSauceRepository;
        private readonly IIngredientRepository _ingredientRepository;

        public ItemService(IPizzaRepository pizzaRepository, INonPizzaItemRepository nonPizzaItemRepository,
            IToppingRepository toppingRepository, ICheeseRepository cheeseRepository,
            ICrustSizeRepository crustSizeRepository, ICrustSauceRepository crustSauceRepository,
            IIngredientRepository ingredientRepository)
        {
            _pizzaRepository = pizzaRepository;
            _nonPizzaItemRepository = nonPizzaItemRepository;
            _toppingRepository = toppingRepository;
            _cheeseRepository = cheeseRepository;
            _crustSizeRepository = crustSizeRepository;
            _crustSauceRepository = crustSauceRepository;
            _ingredientRepository = ingredientRepository;
        }

        public AllItems GetAllItems()
        {
            var pizzaList = _pizzaRepository.GetAllPizza();
            var nonPizzaList = _nonPizzaItemRepository.GetAllNonPizzaItem();
            var ingredientsList = _ingredientRepository.GetAllIngredient();
            var toppingsList = _toppingRepository.GetAllTopping();
            var crustSizesList = _crustSizeRepository.GetAllCrustSize();
            var crustSaucesList = _crustSauceRepository.GetAllCrustSauce();
            var cheeseList = _cheeseRepository.GetAllCheese();

            return new AllItems()
            {
                Pizzas = pizzaList,
                NonPizzaItems = nonPizzaList,
                Ingredients = ingredientsList,
                Toppings = toppingsList,
                CrustSizes = crustSizesList,
                CrustSauces = crustSaucesList,
                Cheese = cheeseList
            };
        }
    }

}
