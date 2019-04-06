using eShop.Domain.Entities;

namespace eShop.Domain.Interfaces
{
    public interface ICategoryRepository : IRepository<Category>
    {
         Category GetByName(string name);
    }
}