using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace pizzeria_api.interfaces.Models
{
    public class NonPizzaItem
    {
        [Key, Required]
        public long Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Image { get; set; }

        [ForeignKey("Ingredient")]
        public IList<string> IngredientIDs { get; set; }
        public int Quantity { get; set; }
    }
}
