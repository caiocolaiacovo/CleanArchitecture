using System.Threading.Tasks;
using eShop.Domain.Categories;
using eShop.Domain.Products;
using Microsoft.EntityFrameworkCore;

namespace eShop.Persistence.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<eShop.Domain.Entities.Customer> Customers { get; set; }
        public DbSet<eShop.Domain.Entities.Order> Orders { get; set; }
        public DbSet<eShop.Domain.Entities.OrderItem> OrderItems { get; set; }
        public DbSet<eShop.Domain.Entities.Payment> Payments { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public async Task Commit()
        {
            await SaveChangesAsync();
        }
    }
}