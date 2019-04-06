using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Bogus;
using eShop.Domain._Util;
using eShop.Domain.Entities;
using eShop.Domain._Exceptions;
using eShop.Domain.Test._Builders;
using eShop.Domain.Test._Util;
using ExpectedObjects;
using Xunit;

namespace eShop.Domain.Test
{
    public class OrderTest
    {
        private List<OrderItem> listOfOrderItems;
        private Faker faker;

        public OrderTest()
        {
            faker = new Faker();
            var product = ProductBuilder.New().WithPrice(125).Build();
            var orderItem = OrderItemBuilder.New().WithQuantity(1).WithProduct(product).WithDiscount(25).Build();

            listOfOrderItems = new List<OrderItem>() {
                orderItem,
            };
        }

        [Fact]
        public void Should_Create_An_Order()
        {
            var expectedOrder = new {
                CustomerId = faker.Random.Int(),
                OrderItems = listOfOrderItems,
            };
            
            var order = OrderBuilder.New().WithCustomerId(expectedOrder.CustomerId).WithOrderItems(expectedOrder.OrderItems).Build();

            expectedOrder.ToExpectedObject().ShouldMatch(order);
        }

        [Fact]
        public void Should_Not_Create_An_Order_Without_CustomerId()
        {
            Assert.Throws<DomainException>(() => OrderBuilder.New().WithCustomerId(0).Build()).WithMessage("Customer is required");
        }

        [Fact]
        public void Should_Not_Create_An_Order_Without_OrderItems()
        {
            Assert.Throws<DomainException>(() => OrderBuilder.New().WithOrderItems(null).Build()).WithMessage("OrderItems is required");
        }

        [Fact]
        public void Should_Set_SubtotalItems_TotalDiscountItems_TotalItems_And_Total_When_Create_An_Order()
        {
            var expectValues = new {
                SubtotalItems = 125m,
                TotalDiscountItems = 25m,
                TotalItems = 100m,
                Total = 100m
            };

            var order = OrderBuilder.New()
                .WithOrderItems(listOfOrderItems)
                .Build();

            expectValues.ToExpectedObject().ShouldMatch(order);
        }

        [Fact]
        public void Should_Not_Add_A_New_OrderItem_When_It_Is_Null()
        {
            var order = OrderBuilder.New().WithOrderItems(listOfOrderItems).Build();   

            Assert.Throws<DomainException>(() => order.AddOrderItem(null)).WithMessage("OrderItem cannot be null");
        }

        [Fact]
        public void Should_Update_SubtotalItems_TotalDiscountItems_TotalItems_And_Total_When_Add_A_New_OrderItem()
        {
            var expectValues = new {
                SubtotalItems = 200m,
                TotalDiscountItems = 30m,
                TotalItems = 170m,
                Total = 170m
            };

            var product = ProductBuilder.New().WithPrice(75).Build();
            var orderItem = OrderItemBuilder.New().WithQuantity(1).WithProduct(product).WithDiscount(5).Build();

            var order = OrderBuilder.New().WithOrderItems(listOfOrderItems).Build();    
            order.AddOrderItem(orderItem);

            Assert.True(order.OrderItems.Count == 2);
            expectValues.ToExpectedObject().ShouldMatch(order);
        }
    }
}