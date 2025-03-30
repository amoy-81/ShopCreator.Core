using Microsoft.AspNetCore.Mvc;
using ShopCreator.Core.Services;
using System.Threading.Tasks;

namespace ShopCreator.Core.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StoreController : ControllerBase
{
    private readonly StoreService _storeService;

    public StoreController(StoreService storeService)
    {
        _storeService = storeService;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromQuery] string name)
    {
        var store = await _storeService.CreateStoreAsync(name);
        return Ok(store);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var stores = await _storeService.GetStoresAsync();
        return Ok(stores);
    }
}