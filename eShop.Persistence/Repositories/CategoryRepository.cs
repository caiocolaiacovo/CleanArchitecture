using System.Linq;
using eShop.Domain.Categories;
using eShop.Persistence.Contexts;

namespace eShop.Persistence.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(ApplicationDbContext context): base(context)
        {
        }

        public Category GetByName(string name)
        {
            var entity = Context.Set<Category>().Where(c => c.Name.Contains(name));

            if (entity.Any())
                return entity.First();

            return null;
        }
    }
}