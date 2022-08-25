using System.Collections.Generic;

namespace pizzeria_api.interfaces.Models
{
    public class AllItems
    {
        public List<Pizza> Pizzas { get; set; }
        public List<NonPizzaItem> NonPizzaItems { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public List<Cheese> Cheese { get; set; }
        public List<CrustSauce> CrustSauces { get; set; }
        public List<CrustSize> CrustSizes { get; set; }
        public List<Topping> Toppings { get; set; }
    }
}
