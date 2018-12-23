namespace eShop.Domain.Entities
{
    public class OrderItem : BaseEntity
    {
        public int Quantity { get; set; }
        public Product Product { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Discount { get; set; }
        public decimal Total { get; set; }

        public OrderItem()
        {
            
        }

        public OrderItem(int quantity, Product product, decimal subtotal, int discount, decimal total)
        {
            Quantity = quantity;
            Product = product;
            Subtotal = subtotal;
            Discount = discount;
            Total = total;
        }
    }
}