using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ShopCreator.Core.Models
{
    public class User
    {
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public ICollection<Shop> Shops { get; set; } = new List<Shop>();

        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
