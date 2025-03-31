using ShopCreator.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace ShopCreator.Core.interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAllAsync();
        Task<User?> GetByIdAsync(Guid id);
        Task CreateAsync(User user);
        Task UpdateAsync(User user);
        Task DeleteAsync(Guid id);
    }
}
