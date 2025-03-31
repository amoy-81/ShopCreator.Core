using ShopCreator.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using ShopCreator.Core.DTO;

namespace ShopCreator.Core.interfaces
{
    public interface IShopService
    {
        Task<IEnumerable<ShopDto>> GetAllAsync();
        Task<Shop?> GetByIdAsync(Guid id);
        Task CreateAsync(Shop shop);
        Task UpdateAsync(Shop shop);
        Task DeleteAsync(Guid id);
    }
}
