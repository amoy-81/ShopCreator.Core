using ShopCreator.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace ShopCreator.Core.interfaces
{
    public interface IUserRepository
    {
        Task<User?> GetByIdAsync(Guid id);
        Task<IEnumerable<User>> GetAllAsync();
        Task AddAsync(User user);
        Task UpdateAsync(User user);
        Task DeleteAsync(Guid id);
    }
}
