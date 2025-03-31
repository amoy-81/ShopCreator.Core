using ShopCreator.Core.Data;
using ShopCreator.Core.interfaces;
using System.Threading.Tasks;

namespace ShopCreator.Core.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        public IUserRepository Users { get; }
        public IShopRepository Shops { get; }
        public IProductRepository Products { get; }
        public ICategoryRepository Categories { get; }
        public ITemplateRepository Templates { get; }

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            Users = new UserRepository(_context);
            Shops = new ShopRepository(_context);
            Products = new ProductRepository(_context);
            Categories = new CategoryRepository(_context);
            Templates = new TemplateRepository(_context);
        }

        public Task<int> SaveChangesAsync() => _context.SaveChangesAsync();
    }
}
