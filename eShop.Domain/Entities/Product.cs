using System.Collections.Generic;

namespace eShop.Domain.Entities
{
    public class Product : BaseEntity
    {
        public string Title { get; private set; }
        public string Description { get; private set; }
        public string Brand { get; private set; }
        public int CategoryId { get; private set; }
        public List<string> Photos { get; private set; }

        public virtual Category Category { get; set; }

        public Product(int id, string title, string description, decimal price, string brand, int categoryId, List<string> photos)
        {
            this.Id = id;
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

        public decimal Price { get; set; }
    }

    public class Category
    {
    }
}