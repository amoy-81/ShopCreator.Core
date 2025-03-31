using ShopCreator.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace ShopCreator.Core.interfaces
{
    public interface IProductRepository
    {
        Task<Product?> GetByIdAsync(Guid id);
        Task<IEnumerable<Product>> GetAllAsync();
        Task AddAsync(Product product);
        Task UpdateAsync(Product product);
        Task DeleteAsync(Guid id);
    }
}
