using eShop.Domain._Base;
using eShop.Domain._Util;
using eShop.Domain.Products;

namespace eShop.Domain.Entities
{
    public class OrderItem : BaseEntity
    {
        public int Quantity { get; private set; }
        public int OrderId { get; private set; }
        public Product Product { get; private set; }
        public decimal Subtotal { get; private set; }
        public decimal Discount { get; private set; }
        public decimal Total { get; private set; }

        public virtual Order Order { get; private set; }
        
        private OrderItem() { }
        public OrderItem(int quantity, Product product, decimal discount)
        {
            var domainValidator = DomainValidator.New();

            domainValidator.When(quantity == 0, "Quantity must be grater than zero")
                .When(quantity > 100, "Quantity must be less than 100")
                .When(product == null, "Product is required")
                .When(discount < 0, "Discount must be greater than zero");

            Quantity = quantity;
            Product = product;
            Discount = discount;

            CalculateTotal();

            domainValidator.When(Total < 0, "Discount cannot be greater than the subtotal of products");
        }
        
        private void CalculateTotal()
        {
            Subtotal = Quantity * Product.Price;
            Total = Subtotal - Discount;
        }
    }
}