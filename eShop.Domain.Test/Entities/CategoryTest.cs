using Bogus;
using eShop.Domain._Exceptions;
using eShop.Domain.Categories;
using eShop.Domain.Test._Util;
using Xunit;

namespace eShop.Domain.Test.Entities
{
    public class CategoryTest
    {
        private Faker faker;

        public CategoryTest()
        {
            faker = new Faker();
        }

        [Fact]
        public void Should_Create_Category() 
        {
            var name = faker.Name.ToString();

            var category = new Category(name);

            Assert.Equal(name, category.Name);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void Should_Not_Create_Category_With_Invalid_Name(string invalidName)
        {
            Assert.Throws<DomainException>(() => new Category(invalidName)).WithMessage("Name is required.");
        }
    }
}