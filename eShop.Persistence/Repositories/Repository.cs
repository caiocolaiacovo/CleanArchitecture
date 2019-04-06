using eShop.Domain.Entities;
using eShop.Domain.Interfaces;

namespace eShop.Persistence.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly ApplicationDbContext Context;

        public Repository(ApplicationDbContext context)
        {
            Context = context;
        }

        public void Add(T entity)
        {
            Context.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            throw new System.NotImplementedException();
        }
    }
}