using System;
using System.Collections.Generic;
using System.Linq;
using Bogus;
using eShop.Domain.Entities;
using eShop.Domain._Exceptions;
using eShop.Domain.Test._Builders;
using eShop.Domain.Test._Util;
using ExpectedObjects;
using Xunit;

namespace eShop.Domain.Test.Entities
{
    public class ProductTest
    {
        private Faker faker;

        public ProductTest()
        {
            faker = new Faker();
        }

        [Fact]
        public void Should_Create_A_Product()
        {
            var expectedProduct = new {
                Title = faker.Commerce.ProductName(),
                Description = faker.Lorem.Text(),
                Price = faker.Random.Decimal(1, 5000),
                Brand = faker.Company.Random.Word(),
                CategoryId = faker.Random.Int(0),
            };

            var product = ProductBuilder.New()
                .WithTitle(expectedProduct.Title)
                .WithDescription(expectedProduct.Description)
                .WithPrice(expectedProduct.Price)
                .WithBrand(expectedProduct.Brand)
                .WithCategoryId(expectedProduct.CategoryId)
                .Build();

            expectedProduct.ToExpectedObject().ShouldMatch(product);
        }

        [Fact]
        public void Should_Not_Create_Product_Without_Title()
        {
            Assert.Throws<DomainException>(() => ProductBuilder.New().WithTitle(null).Build())
                .WithMessage("Title is required");
        }

        [Fact]
        public void Should_Not_Create_Product_Without_Description()
        {
            Assert.Throws<DomainException>(() => ProductBuilder.New().WithDescription(null).Build())
                .WithMessage("Description is required");
        }

        [Fact]
        public void Should_Not_Create_Product_With_Invalid_Price()
        {
            var invalidPrice = -1;

            Assert.Throws<DomainException>(() => ProductBuilder.New().WithPrice(invalidPrice).Build())
                .WithMessage("Price must be equal or greater than zero");
        }

        [Fact]
        public void Should_Not_Create_Product_Without_Brand()
        {
            Assert.Throws<DomainException>(() => ProductBuilder.New().WithBrand(null).Build())
                .WithMessage("Brand is required");
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        public void Should_Not_Create_Product_With_Invalid_CategoryId(int invalidCategoryId)
        {
            Assert.Throws<DomainException>(() => ProductBuilder.New().WithCategoryId(invalidCategoryId).Build())
                .WithMessage("Category is required");
        }
    }
}