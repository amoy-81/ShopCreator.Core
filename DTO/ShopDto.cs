using System;
using System.ComponentModel.DataAnnotations;

namespace ShopCreator.Core.DTO
{
    public class ShopDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string SubDomain { get; set; }
        public TemplateDto Template { get; set; }
    }

    public class ShopResponseDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string SubDomain { get; set; }

        public TemplateDto Template { get; set; }
    }

    public class CreateShopDto
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(100)]
        public string SubDomain { get; set; }

        [Required]
        public Guid UserId { get; set; }

        [Required]
        public Guid TemplateId { get; set; }
    }
}
