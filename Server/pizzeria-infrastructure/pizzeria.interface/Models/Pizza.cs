using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace pizzeria_api.interfaces.Models
{
    public class Pizza
    {
        [Key, Required]
        public long Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }

        public string Image { get; set; }

        [ForeignKey("Ingredient")]
        public IList<string> IngredientIDs { get; set; }

        [ForeignKey("Topping")]
        public IList<string> ToppingIDs { get; set; }

        [ForeignKey("Cheese")]
        public IList<string> CheeseIDs { get; set; }

        [ForeignKey("CrustSauce")]
        public IList<string> CrustSauceIDs { get; set; }

        [ForeignKey("Size")]
        public string SizeId { get; set; }

        public int Quantity { get; set; }
    }

    
}
