namespace eShop.Application.Test.Categories
{
    public class CategoryStorerTest
    {
        public CategoryStorerTest()
        {
            
        }

        [Fact]
        public void Should_Store_Category()
        {
            var categoryDto = new CategoryDto {
                name = "name"
            };

            var categoryRepository = new Mock<ICategoryRepository>();
            var categoryStorer = new CategoryStorer(categoryRepository.Object);

            categoryStorer.Store(categoryDto);

            categoryRepository.Verify(r => r.Add(It.Is<Category>(c => c.Name.Equals(categoryDto.name))));
        }
    }
}