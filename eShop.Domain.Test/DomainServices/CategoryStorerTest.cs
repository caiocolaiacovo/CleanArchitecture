using System;
using eShop.Domain.Categories;
using Moq;
using Xunit;

namespace eShop.Domain.Test.DomainServices
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

        private class CategoryDto
        {
            public string name { get; set; }
        }

        private class CategoryStorer
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
}