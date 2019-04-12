namespace eShop.Application.Categories
{
    public class CategoryStorer
    {
        private ICategoryRepository CategoryRepository;

        public CategoryStorer(ICategoryRepository categoryRepository)
        {
            CategoryRepository = categoryRepository;
        }

        public void Store(CategoryDto categoryDto)
        {
            var category = new Category(categoryDto.name);

            CategoryRepository.Add(category);
        }
    }
}