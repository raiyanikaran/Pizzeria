using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace pizzeria_api.interfaces.Models
{
    public class CrustSize
    {
        [Key, Required]
        public string Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
    }
}
