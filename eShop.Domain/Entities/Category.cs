using System.Collections.Generic;

namespace eShop.Domain.Entities
{
    public class Category : BaseEntity
    {
        public string Name { get; private set; }

        public virtual ICollection<Product> Products { get; private set; }


        private Category() { }
    }
}