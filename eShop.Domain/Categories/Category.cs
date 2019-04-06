using System.Collections.Generic;
using eShop.Domain._Base;
using eShop.Domain._Util;
using eShop.Domain.Products;

namespace eShop.Domain.Categories
{
    public class Category : BaseEntity
    {
        public string Name { get; private set; }

        public virtual ICollection<Product> Products { get; private set; }

        private Category() { }

        public Category(string name) 
        { 
            DomainValidator.New().When(string.IsNullOrEmpty(name), "Name is required.");
            
            Name = name;
        }
    }
}