using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using eShop.Persistence.Repositories;
using eShop.Domain.Interfaces;
using eShop.Domain.Entities;

namespace eShop.DI
{
    public class StartupDI
    {
        public static void Configure(IServiceCollection services, string connectionString)
        {
            services.AddDbContext<eShop.Persistence.ApplicationDbContext>(options => options.UseSqlServer(connectionString));
            services.AddSingleton(typeof(IRepository<>), typeof(Repository<>));
            services.AddSingleton(typeof(ICategoryRepository), typeof(CategoryRepository));
            services.AddSingleton(typeof(IUnitOfWork), typeof(eShop.Persistence.UnitOfWork));
        }
    }
}