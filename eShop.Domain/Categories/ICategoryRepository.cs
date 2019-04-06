using eShop.Domain._Base;
using eShop.Domain.Entities;

namespace eShop.Domain.Categories
{
    public interface ICategoryRepository : IRepository<Category>
    {
         Category GetByName(string name);
    }
}