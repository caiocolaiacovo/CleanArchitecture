using System.Threading.Tasks;
using eShop.Domain.Interfaces;

namespace eShop.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext Context;

        public UnitOfWork(ApplicationDbContext context)
        {
             Context = context;
        }

        public async Task Commit()
        {
            await Context.SaveChangesAsync();
        }
    }
}