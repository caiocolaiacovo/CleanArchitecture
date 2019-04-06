using Bogus;
using eShop.Domain.Entities;
using eShop.Domain.Products;

namespace eShop.Domain.Test._Builders
{
    public class OrderItemBuilder
    {
        private int quantity { get; set; }
        private Product product { get; set; }
        private decimal discount { get; set; }

        public OrderItemBuilder()
        {
            var faker = new Faker();
            var product = ProductBuilder.New().Build();

            this.quantity = faker.Random.Int(0, 100);
            this.product = product;
            this.discount = faker.Random.Decimal(0, product.Price);
        }

        public static OrderItemBuilder New()
        {
            return new OrderItemBuilder();
        }

        public OrderItem Build()
        {
            return new OrderItem(
                this.quantity, this.product, this.discount
            );
        }

        public OrderItemBuilder WithQuantity(int quantity)
        {
            this.quantity = quantity;
            return this;
        }

        public OrderItemBuilder WithProduct(Product product)
        {
            this.product = product;
            return this;
        }

        public OrderItemBuilder WithDiscount(decimal discount)
        {
            this.discount = discount;
            return this;
        }
    }
}