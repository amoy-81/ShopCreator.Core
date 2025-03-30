using Microsoft.EntityFrameworkCore;
using ShopCreator.Core.Models;

namespace ShopCreator.Core.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Store> Stores => Set<Store>();
}