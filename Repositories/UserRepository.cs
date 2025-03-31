using ShopCreator.Core.Data;
using ShopCreator.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using ShopCreator.Core.interfaces;
using Microsoft.EntityFrameworkCore;

namespace ShopCreator.Core.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;
        public UserRepository(AppDbContext context) => _context = context;

        public async Task<User?> GetByIdAsync(Guid id) => await _context.Users.FindAsync(id);
        public async Task<IEnumerable<User>> GetAllAsync() => await _context.Users.ToListAsync();
        public async Task AddAsync(User user) => await _context.Users.AddAsync(user);
        public Task UpdateAsync(User user) { _context.Users.Update(user); return Task.CompletedTask; }
        public async Task DeleteAsync(Guid id)
        {
            var user = await GetByIdAsync(id);
            if (user != null) _context.Users.Remove(user);
        }
    }
}
