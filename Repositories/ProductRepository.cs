using ShopCreator.Core.Data;
using ShopCreator.Core.interfaces;
using ShopCreator.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Microsoft.EntityFrameworkCore;

namespace ShopCreator.Core.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;
        public ProductRepository(AppDbContext context) => _context = context;

        public async Task<Product?> GetByIdAsync(Guid id) => await _context.Products.FindAsync(id);
        public async Task<IEnumerable<Product>> GetAllAsync() => await _context.Products.ToListAsync();
        public async Task AddAsync(Product product) => await _context.Products.AddAsync(product);
        public Task UpdateAsync(Product product) { _context.Products.Update(product); return Task.CompletedTask; }
        public async Task DeleteAsync(Guid id)
        {
            var product = await GetByIdAsync(id);
            if (product != null) _context.Products.Remove(product);
        }
    }
}
