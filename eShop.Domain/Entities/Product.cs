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
        public List<string> Photos { get; private set; }

        public virtual Category Category { get; set; }

        public Product(string title, string description, decimal price, string brand, int categoryId, List<string> photos)
        {
            DomainValidator.New()
                .When(string.IsNullOrEmpty(title), "Title is required")
                .When(string.IsNullOrEmpty(description), "Description is required")
                .When(price < 0, "Price must be equal or greater than zero")
                .When(string.IsNullOrEmpty(brand), "Brand is required")
                .When(categoryId <= 0, "Category is required")
                .When(photos == null, "Photos is required")
                .When(photos.Count == 0, "Product must have at least one photo");

            this.Title = title;
            this.Description = description;
            this.Price = price;
            this.Brand = brand;
            this.CategoryId = categoryId;
            this.Photos = photos;
        }

        public Product()
        {
            
        }
    }

    public class Category
    {
    }
}