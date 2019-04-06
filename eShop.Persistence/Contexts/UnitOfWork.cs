using System.Threading.Tasks;
using eShop.Domain._Base;
using eShop.Persistence.Contexts;

namespace eShop.Persistence.Contexts
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