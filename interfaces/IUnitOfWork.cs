using System.Threading.Tasks;

namespace ShopCreator.Core.interfaces
{
    public interface IUnitOfWork
    {
        IUserRepository Users { get; }
        IShopRepository Shops { get; }
        IProductRepository Products { get; }
        ICategoryRepository Categories { get; }
        ITemplateRepository Templates { get; }

        Task<int> SaveChangesAsync();
    }
}
