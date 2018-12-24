using eShop.Domain._Util;

namespace eShop.Domain.Entities
{
    public class OrderItem : BaseEntity
    {
        public int Quantity { get; set; }
        public Product Product { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Discount { get; set; }
        public decimal Total { get; set; }
        
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