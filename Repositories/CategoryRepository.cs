using ShopCreator.Core.Data;
using ShopCreator.Core.interfaces;
using ShopCreator.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Microsoft.EntityFrameworkCore;

namespace ShopCreator.Core.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _context;
        public CategoryRepository(AppDbContext context) => _context = context;

        public async Task<Category?> GetByIdAsync(Guid id) => await _context.Categories.FindAsync(id);
        public async Task<IEnumerable<Category>> GetAllAsync() => await _context.Categories.ToListAsync();
        public async Task AddAsync(Category category) => await _context.Categories.AddAsync(category);
        public Task UpdateAsync(Category category) { _context.Categories.Update(category); return Task.CompletedTask; }
        public async Task DeleteAsync(Guid id)
        {
            var category = await GetByIdAsync(id);
            if (category != null) _context.Categories.Remove(category);
        }
    }
}
