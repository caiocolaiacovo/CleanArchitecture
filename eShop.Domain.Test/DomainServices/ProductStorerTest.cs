using System;
using System.Collections;
using System.Collections.Generic;
using eShop.Domain.Products;
using Moq;
using Xunit;

namespace eShop.Domain.Test.DomainServices
{
    public class ProductStorerTest
    {
        [Fact]
        public void Should_Store_Product()
        {
            var productDto = new ProductDto {
                title = "title",
                description = "description",
                price = 10m,
                brand = "Brand",
                categoryId = 1,
            };

            var productRepository = new Mock<IProductRepository>();

            var productStorer = new ProductStorer(productRepository.Object);

            productStorer.Store(productDto);

            productRepository.Verify(r => r.Add(It.Is<Product>(p => p.Title == productDto.title)), Times.Once);
        }
    }

    public class ProductStorer
    {
        private readonly IProductRepository productRepository;

        public ProductStorer(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public void Store(ProductDto productDto)
        {
            var product = new Product(
                productDto.title, 
                productDto.description, 
                productDto.price, 
                productDto.brand, 
                productDto.categoryId);

            productRepository.Add(product);
        }
    }

    public class ProductDto
    {
        public string title { get; set; }
        public string description { get; set; }
        public decimal price { get; set; }
        public string brand { get; set; }
        public int categoryId { get; set; }
    }
}