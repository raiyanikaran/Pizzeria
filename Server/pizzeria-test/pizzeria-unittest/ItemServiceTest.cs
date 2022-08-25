using Moq;
using pizzeria.interfaces.Items;
using pizzeria.Service;
using pizzeria_api.interfaces.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace pizzeria_unittest
{
    public class ItemServiceTest
    {
        private readonly Mock<IPizzaRepository> _pizzaRepository;
        private readonly Mock<INonPizzaItemRepository> _nonPizzaItemRepository;
        private readonly Mock<IToppingRepository> _toppingRepository;
        private readonly Mock<ICheeseRepository> _cheeseRepository;
        private readonly Mock<ICrustSizeRepository> _crustSizeRepository;
        private readonly Mock<ICrustSauceRepository> _crustSauceRepository;
        private readonly Mock<IIngredientRepository> _ingredientRepository;
        private readonly ItemService _itemService;

        public ItemServiceTest()
        {
            _pizzaRepository = new Mock<IPizzaRepository>();
            _nonPizzaItemRepository = new Mock<INonPizzaItemRepository>();
            _toppingRepository = new Mock<IToppingRepository>();
            _cheeseRepository = new Mock<ICheeseRepository>();
            _crustSizeRepository = new Mock<ICrustSizeRepository>();
            _crustSauceRepository = new Mock<ICrustSauceRepository>();
            _ingredientRepository = new Mock<IIngredientRepository>();
            _itemService = new ItemService(_pizzaRepository.Object, _nonPizzaItemRepository.Object,
                _toppingRepository.Object, _cheeseRepository.Object, _crustSizeRepository.Object,
                _crustSauceRepository.Object, _ingredientRepository.Object);
        }

        [Fact]
        public void GetAllItems()
        {
            _pizzaRepository.Setup(x => x.GetAllPizza()).Returns(new List<Pizza>());
            _nonPizzaItemRepository.Setup(x => x.GetAllNonPizzaItem()).Returns(new List<NonPizzaItem>());
            _toppingRepository.Setup(x => x.GetAllTopping()).Returns(new List<Topping>());
            _cheeseRepository.Setup(x => x.GetAllCheese()).Returns(new List<Cheese>());
            _crustSizeRepository.Setup(x => x.GetAllCrustSize()).Returns(new List<CrustSize>());
            _crustSauceRepository.Setup(x => x.GetAllCrustSauce()).Returns(new List<CrustSauce>());
            _ingredientRepository.Setup(x => x.GetAllIngredient()).Returns(new List<Ingredient>());
            var result = _itemService.GetAllItems();
            _pizzaRepository.Verify(x => x.GetAllPizza());
            _nonPizzaItemRepository.Verify(x => x.GetAllNonPizzaItem());
            _toppingRepository.Verify(x => x.GetAllTopping());
            _cheeseRepository.Verify(x => x.GetAllCheese());
            _crustSizeRepository.Verify(x => x.GetAllCrustSize());
            _crustSauceRepository.Verify(x => x.GetAllCrustSauce());
            _ingredientRepository.Verify(x => x.GetAllIngredient());
            Assert.NotNull(result);
        }
    }
}
