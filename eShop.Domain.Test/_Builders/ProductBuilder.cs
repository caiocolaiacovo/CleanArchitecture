using System.Collections.Generic;
using Bogus;
using eShop.Domain.Entities;

namespace eShop.Domain.Test._Builders
{
    public class ProductBuilder
    {
        private int id;
        private string brand;
        private int categoryId;
        private string description;
        private List<string> photos;
        private decimal price;
        private string title;

        private ProductBuilder()
        {
            var faker = new Faker();

            this.id = faker.Random.Int();
            this.brand = faker.Company.Random.Word();
            this.categoryId = faker.Random.Int();
            this.description = faker.Lorem.Text();
            this.price = faker.Random.Decimal(0, 5000);
            this.title = faker.Lorem.Sentence();
            this.photos = new List<string>() { 
                $"images/products/${this.id}_1.jpg",
                $"images/products/${this.id}_2.jpg",
                $"images/products/${this.id}_3.jpg" 
            };
        }

        public static ProductBuilder New()
        {
            return new ProductBuilder();
        }

        public ProductBuilder WithId(int id)
        {
            this.id = id;
            return this;
        }

        public Product Build()
        {
            return new Product(
                this.id,
                this.title,
                this.description,
                this.price,
                this.brand,
                this.categoryId,
                this.photos
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

        public ProductBuilder WithPhotos(List<string> photos)
        {
            this.photos = photos;
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