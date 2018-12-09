using System;
using System.Collections.Generic;
using Bogus;
using eShop.Domain.Entities;
using eShop.Domain.Test._Builders;
using Xunit;

namespace eShop.Domain.Test.Entities
{
    public class ProductTest
    {
        [Fact]
        public void Should_Create_A_Product()
        {
            var expectedProduct = new {
                Id = 1,
                Title = "iPhone X 64gb",
                Description = @"
                    Lorem ipsum dolor sit amet, consectetur adipiscing elit. 
                    Nunc in nulla quis metus gravida tempor et eget libero. 
                    Mauris imperdiet eros quis mauris tempor, id tincidunt felis semper. 
                    Fusce sit amet tristique sem.",
                Price = 10m,
                Brand = "Apple",
                CategoryId = 1,
                Photos = new List<string>() {
                    "images/products/1_1.jpg",
                    "images/products/1_2.jpg",
                    "images/products/1_3.jpg"
                }
            };

            var product = ProductBuilder.New()
                .WithId(expectedProduct.Id)
                .WithTitle(expectedProduct.Title)
                .WithDescription(expectedProduct.Description)
                .WithPrice(expectedProduct.Price)
                .WithBrand(expectedProduct.Brand)
                .WithCategoryId(expectedProduct.CategoryId)
                .WithPhotos(expectedProduct.Photos)
                .Build();
        }
    }
}