using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using eShop.Persistence;
using eShop.Domain.Interfaces;

namespace eShop.DI
{
    public class StartupDI
    {
        public static void Configure(IServiceCollection services, string connectionString)
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));
            services.AddSingleton(typeof(IRepository<>), typeof(Repository<>));
            services.AddSingleton(typeof(IUnitOfWork), typeof(UnitOfWork));
        }
    }
}