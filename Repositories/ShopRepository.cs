using ShopCreator.Core.Data;
using ShopCreator.Core.interfaces;
using ShopCreator.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Microsoft.EntityFrameworkCore;

namespace ShopCreator.Core.Repositories
{
    public class ShopRepository : IShopRepository
    {
        private readonly AppDbContext _context;
        public ShopRepository(AppDbContext context) => _context = context;

        public async Task<Shop?> GetByIdAsync(Guid id) => await _context.Shops.FindAsync(id);
        public async Task<IEnumerable<Shop>> GetAllAsync()
        {
            return await _context.Shops
                .Include(s => s.Template)
                .ToListAsync();
        }
        public async Task AddAsync(Shop shop) => await _context.Shops.AddAsync(shop);
        public Task UpdateAsync(Shop shop) { _context.Shops.Update(shop); return Task.CompletedTask; }
        public async Task DeleteAsync(Guid id)
        {
            var shop = await GetByIdAsync(id);
            if (shop != null) _context.Shops.Remove(shop);
        }
    }
}
