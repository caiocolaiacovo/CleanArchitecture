using System.Collections.Generic;
using eShop.Domain._Util;

namespace eShop.Domain.Entities
{
    public class Product : BaseEntity
    {
        public string Title { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public string Brand { get; private set; }
        public int CategoryId { get; private set; }

        public virtual Category Category { get; private set; }

        private Product() { }

        public Product(string title, string description, decimal price, string brand, int categoryId)
        {
            DomainValidator.New()
                .When(string.IsNullOrEmpty(title), "Title is required")
                .When(string.IsNullOrEmpty(description), "Description is required")
                .When(price < 0, "Price must be equal or greater than zero")
                .When(string.IsNullOrEmpty(brand), "Brand is required")
                .When(categoryId <= 0, "Category is required");

            this.Title = title;
            this.Description = description;
            this.Price = price;
            this.Brand = brand;
            this.CategoryId = categoryId;
        }
    }
}