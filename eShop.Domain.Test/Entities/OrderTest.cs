using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Bogus;
using eShop.Domain._Util;
using eShop.Domain.Entities;
using eShop.Domain.Exceptions;
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

            listOfOrderItems = new List<OrderItem>() {
                new OrderItem() {
                    Quantity = 1,
                    Product = ProductBuilder.New().WithPrice(125).Build(),
                    Subtotal = 125,
                    Discount = 25,
                    Total = 100,
                }
            };
        }

        [Fact]
        public void Should_Create_A_Order()
        {
            var expectedOrder = new {
                CustomerId = faker.Random.Int(),
                OrderItems = listOfOrderItems,
            };
            
            var order = OrderBuilder.New().WithCustomerId(expectedOrder.CustomerId).WithOrderItems(expectedOrder.OrderItems).Build();

            expectedOrder.ToExpectedObject().ShouldMatch(order);
        }

        [Fact]
        public void Should_Not_Create_A_Order_Without_CustomerId()
        {
            Assert.Throws<DomainException>(() => OrderBuilder.New().WithCustomerId(0).Build()).WithMessage("CustomerId is required");
        }

        [Fact]
        public void Should_Not_Create_A_Order_Without_OrderItems()
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

            Assert.Throws<DomainException>(() => order.AddOrderItem(null)).WithMessage("Parameter 'orderItem' cannot be null");
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

            var orderItem = new OrderItem() {
                Quantity = 1,
                Product = ProductBuilder.New().WithPrice(75).Build(),
                Subtotal = 75,
                Discount = 5,
                Total = 70m,
            };

            var order = OrderBuilder.New().WithOrderItems(listOfOrderItems).Build();    
            order.AddOrderItem(orderItem);

            Assert.True(order.OrderItems.Count == 2);
            expectValues.ToExpectedObject().ShouldMatch(order);
        }
    }
}