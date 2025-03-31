using System;
using System.Collections.Generic;

namespace ShopCreator.Core.Models
{
    public class Template
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public ICollection<Shop> Shops { get; set; } = new List<Shop>();
    }
}
