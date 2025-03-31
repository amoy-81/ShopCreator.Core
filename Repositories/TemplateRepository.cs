using ShopCreator.Core.Data;
using ShopCreator.Core.interfaces;
using ShopCreator.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Microsoft.EntityFrameworkCore;

namespace ShopCreator.Core.Repositories
{
    public class TemplateRepository : ITemplateRepository
    {
        private readonly AppDbContext _context;
        public TemplateRepository(AppDbContext context) => _context = context;

        public async Task<Template?> GetByIdAsync(Guid id) => await _context.Templates.FindAsync(id);
        public async Task<IEnumerable<Template>> GetAllAsync() => await _context.Templates.ToListAsync();
        public async Task AddAsync(Template template) => await _context.Templates.AddAsync(template);
        public Task UpdateAsync(Template template) { _context.Templates.Update(template); return Task.CompletedTask; }
        public async Task DeleteAsync(Guid id)
        {
            var template = await GetByIdAsync(id);
            if (template != null) _context.Templates.Remove(template);
        }
    }
}
