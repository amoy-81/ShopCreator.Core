using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopCreator.Core.Models
{
    public class Shop
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = "فروشگاه";

        public string Description { get; set; } = "فروشگاه آنلاین";

        [Required]
        public string SubDomain { get; set; }

        public Guid UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }

        [Required]
        public Guid TemplateId { get; set; }
        [ForeignKey("TemplateId")]
        public Template Template { get; set; }

        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
