﻿using System.ComponentModel.DataAnnotations;

namespace pizzeria_api.interfaces.Models
{
    public class User
    {
        [Key, Required]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string PinCode { get; set; }
    }
}
