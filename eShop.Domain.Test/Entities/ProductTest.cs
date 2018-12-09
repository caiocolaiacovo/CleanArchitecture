using System;
using System.Collections.Generic;
using System.Linq;
using Bogus;
using eShop.Domain.Entities;
using eShop.Domain.Exceptions;
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
            var hash = faker.Random.Hash();

            var expectedProduct = new {
                Title = faker.Commerce.ProductName(),
                Description = faker.Lorem.Text(),
                Price = faker.Random.Decimal(1, 5000),
                Brand = faker.Company.Random.Word(),
                CategoryId = faker.Random.Int(0),
                Photos = new List<string>() {
                    $"images/products/${hash}_1.jpg",
                    $"images/products/${hash}_2.jpg",
                    $"images/products/${hash}_3.jpg"
                }
            };

            var product = ProductBuilder.New()
                .WithTitle(expectedProduct.Title)
                .WithDescription(expectedProduct.Description)
                .WithPrice(expectedProduct.Price)
                .WithBrand(expectedProduct.Brand)
                .WithCategoryId(expectedProduct.CategoryId)
                .WithPhotos(expectedProduct.Photos)
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
                .WithMessage("Price cannot be negative");
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
                .WithMessage("CategoryId must be greater than zero");
        }

        [Theory]
        [InlineData(null, "Photos is required")]
        [InlineData((object)new string[] {}, "Product must have at least one photo")]
        public void Should_Not_Create_Product_With_Invalid_Photos(string [] invalidPhotos, string message)
        {
            //xUnit workaround
            var _invalidPhotos = invalidPhotos != null ? invalidPhotos.OfType<string>().ToList() : null;

            Assert.Throws<DomainException>(() => ProductBuilder.New().WithPhotos(_invalidPhotos).Build())
                .WithMessage(message);
        }
    }
}