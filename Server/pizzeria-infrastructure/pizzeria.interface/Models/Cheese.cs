using System.Collections.Generic;

namespace pizzeria_api.interfaces.Models
{
    public class Cheese
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public bool IsAdded { get; set; } = false;
    }
}
