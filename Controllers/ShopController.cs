using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopCreator.Core.interfaces;
using ShopCreator.Core.Models;
using System.Threading.Tasks;
using System;
using ShopCreator.Core.DTO;

namespace ShopCreator.Core.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShopsController : ControllerBase
    {
        private readonly IShopService _shopService;

        public ShopsController(IShopService shopService)
        {
            _shopService = shopService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var shops = await _shopService.GetAllAsync();
            return Ok(shops);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var shop = await _shopService.GetByIdAsync(id);
            if (shop == null) return NotFound();
            return Ok(shop);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateShopDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var shop = new Shop
            {
                Name = dto.Name,
                SubDomain = dto.SubDomain,
                UserId = dto.UserId,
                TemplateId = dto.TemplateId
            };

            await _shopService.CreateAsync(shop);
            return CreatedAtAction(nameof(Get), new { id = shop.Id }, shop);
        }
    }
}
