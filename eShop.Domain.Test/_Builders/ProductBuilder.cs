using System.Collections.Generic;
using Bogus;
using eShop.Domain.Entities;
using eShop.Domain.Products;

namespace eShop.Domain.Test._Builders
{
    public class ProductBuilder
    {
        private string brand;
        private int categoryId;
        private string description;
        private decimal price;
        private string title;

        private ProductBuilder()
        {
            var faker = new Faker();
            var hash = faker.Random.Hash();

            this.brand = faker.Company.Random.Word();
            this.categoryId = faker.Random.Int(0);
            this.description = faker.Lorem.Text();
            this.price = faker.Random.Decimal(1, 1000000);
            this.title = faker.Commerce.ProductName();
        }

        public static ProductBuilder New()
        {
            return new ProductBuilder();
        }

        public Product Build()
        {
            return new Product(
                this.title,
                this.description,
                this.price,
                this.brand,
                this.categoryId
            );
        }

        public ProductBuilder WithBrand(string brand)
        {
            this.brand = brand;
            return this;
        }

        public ProductBuilder WithCategoryId(int categoryId)
        {
            this.categoryId = categoryId;
            return this;
        }

        public ProductBuilder WithDescription(string description)
        {
            this.description = description;
            return this;
        }

        public ProductBuilder WithPrice(decimal price)
        {
            this.price = price;
            return this;
        }

        public ProductBuilder WithTitle(string title)
        {
            this.title = title;
            return this;
        }
    }
}