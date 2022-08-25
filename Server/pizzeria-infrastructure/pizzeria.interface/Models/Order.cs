using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace pizzeria_api.interfaces.Models
{
    public class Order
    {
        [Key, Required]
        public long Id { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        [ForeignKey("NonPizzaItem")]
        public List<NonPizzaItem> NonPizzaItems { get; set; }
        public List<Pizza> Pizzas { get; set; }
        public string OrderStatus { get; set; }
        public double TotalAmmount { get; set; }
        public System.DateTime OrderCreationTime { get; set; }
    }
}
