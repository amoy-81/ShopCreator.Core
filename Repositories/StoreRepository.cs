using Microsoft.EntityFrameworkCore;
using ShopCreator.Core.Data;
using ShopCreator.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShopCreator.Core.Repositories;

public class StoreRepository
{
    private readonly AppDbContext _context;

    public StoreRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Store> CreateAsync(string name)
    {
        var store = new Store { Name = name };
        _context.Stores.Add(store);
        await _context.SaveChangesAsync();
        return store;
    }

    public Task<List<Store>> GetAllAsync()
    {
        return _context.Stores.ToListAsync();
    }
}