using eShop.Domain.Entities;
using eShop.Domain._Exceptions;
using eShop.Domain.Test._Builders;
using eShop.Domain.Test._Util;
using ExpectedObjects;
using Xunit;

namespace eShop.Domain.Test.Entities
{
    public class OrderItemTest
    {
        [Fact]
        public void Should_Create_An_OrderItem()
        {
            var product = ProductBuilder.New().Build();
            var quantity = 1;
            var subTotal = quantity * product.Price;
            var discount = 0m;
            var total = subTotal - discount;

            var expectedOrderItem = new {
                Quantity = quantity,
                Product = product,
                Subtotal = subTotal,
                Discount = discount,
                Total = total,
            };

            var orderItem = OrderItemBuilder.New()
                .WithQuantity(expectedOrderItem.Quantity)
                .WithProduct(expectedOrderItem.Product)
                .WithDiscount(0)
                .Build();

            expectedOrderItem.ToExpectedObject().ShouldMatch(orderItem);
        }

        [Fact]
        public void Should_Not_Create_An_OrderItem_With_Quantity_Zero()
        {
            Assert.Throws<DomainException>(() => OrderItemBuilder.New().WithQuantity(0).Build()).WithMessage("Quantity must be grater than zero");
        }

        [Fact]
        public void Should_Not_Create_An_OrderItem_With_Quantity_Greater_Than_100()
        {
            Assert.Throws<DomainException>(() => OrderItemBuilder.New().WithQuantity(101).Build()).WithMessage("Quantity must be less than 100");
        }

        [Fact]
        public void Should_Not_Create_An_OrderItem_Without_A_Product()
        {
            Assert.Throws<DomainException>(() => OrderItemBuilder.New().WithProduct(null).Build()).WithMessage("Product is required");
        }

        [Fact]
        public void Should_Not_Create_An_OrderItem_With_Discount_Less_Than_Zero()
        {
            Assert.Throws<DomainException>(() => OrderItemBuilder.New().WithDiscount(-1).Build()).WithMessage("Discount must be greater than zero");
        }

        [Fact]
        public void Should_Not_Create_An_OrderItem_With_Discount_Greater_Than_Product_Price()
        {
            var product = ProductBuilder.New().Build();
            var invalidDiscount = (product.Price * 2) + 1;

            Assert.Throws<DomainException>(() => 
                OrderItemBuilder.New().WithQuantity(2).WithProduct(product).WithDiscount(invalidDiscount).Build()
            ).WithMessage("Discount cannot be greater than the subtotal of products");
        }

        [Fact]
        public void Should_Set_Subtotal_And_Total_When_Create_An_OrderItem()
        {
            var quantity = 2;
            var product = ProductBuilder.New().WithPrice(100).Build();
            var discount = 25m;
            
            var expectedOrderItem = new {
                Subtotal = 200m,
                Total = 175m
            };

            var orderItem = OrderItemBuilder.New().WithQuantity(quantity).WithProduct(product).WithDiscount(discount).Build();
            
            expectedOrderItem.ToExpectedObject().ShouldMatch(orderItem);
        }
    }
}