using ShopCreator.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace ShopCreator.Core.interfaces
{
    public interface ITemplateRepository
    {
        Task<Template?> GetByIdAsync(Guid id);
        Task<IEnumerable<Template>> GetAllAsync();
        Task AddAsync(Template template);
        Task UpdateAsync(Template template);
        Task DeleteAsync(Guid id);
    }
}
