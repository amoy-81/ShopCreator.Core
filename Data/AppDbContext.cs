using Microsoft.EntityFrameworkCore;
using ShopCreator.Core.Models;

namespace ShopCreator.Core.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<User> Users => Set<User>();
    public DbSet<Shop> Shops => Set<Shop>();
    public DbSet<Product> Products => Set<Product>();
    public DbSet<Category> Categories => Set<Category>();
    public DbSet<Template> Templates => Set<Template>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // USER -> SHOPS
        modelBuilder.Entity<Shop>()
            .HasOne(s => s.User)
            .WithMany(u => u.Shops)
            .HasForeignKey(s => s.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        // USER -> PRODUCTS
        modelBuilder.Entity<Product>()
            .HasOne(p => p.User)
            .WithMany(u => u.Products)
            .HasForeignKey(p => p.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        // SHOP -> PRODUCTS
        modelBuilder.Entity<Product>()
            .HasOne(p => p.Shop)
            .WithMany(s => s.Products)
            .HasForeignKey(p => p.ShopId)
            .OnDelete(DeleteBehavior.Cascade);

        // PRODUCT -> CATEGORY
        modelBuilder.Entity<Product>()
            .HasOne(p => p.Category)
            .WithMany()
            .HasForeignKey(p => p.CategoryId)
            .OnDelete(DeleteBehavior.Restrict);

        // SHOP -> TEMPLATE
        modelBuilder.Entity<Shop>()
            .HasOne(s => s.Template)
            .WithMany(t => t.Shops)
            .HasForeignKey(s => s.TemplateId)
            .OnDelete(DeleteBehavior.Restrict);

        // CATEGORY -> SELF (PARENT/CHILD)
        modelBuilder.Entity<Category>()
            .HasMany(c => c.Children)
            .WithOne(c => c.Parent)
            .HasForeignKey(c => c.ParentId)
            .OnDelete(DeleteBehavior.Restrict);

        // DEFAULT VALUES FOR SHOP
        modelBuilder.Entity<Shop>()
            .Property(s => s.Name)
            .HasDefaultValue("فروشگاه");

        modelBuilder.Entity<Shop>()
            .Property(s => s.Description)
            .HasDefaultValue("فروشگاه آنلاین");

        // UNIQUE INDEX ON USER EMAIL
        modelBuilder.Entity<User>()
            .HasIndex(u => u.Email)
            .IsUnique();
    }
}