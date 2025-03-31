using ShopCreator.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace ShopCreator.Core.interfaces
{
    public interface IShopRepository
    {
        Task<Shop?> GetByIdAsync(Guid id);
        Task<IEnumerable<Shop>> GetAllAsync();
        Task AddAsync(Shop shop);
        Task UpdateAsync(Shop shop);
        Task DeleteAsync(Guid id);
    }
}
