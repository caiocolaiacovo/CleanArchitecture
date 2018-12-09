using System;
using System.Collections.Generic;
using Bogus;
using eShop.Domain.Entities;

namespace eShop.Domain.Test._Builders
{
    public class OrderBuilder
    {
        private int customerId;
        private ICollection<OrderItem> orderItems;

        private OrderBuilder()
        {
            var faker = new Faker();

            customerId = faker.Random.Number(int.MaxValue);
            orderItems = new List<OrderItem>();
        }

        public static OrderBuilder New()
        {
            return new OrderBuilder();
        }

        public Order Build()
        {
            var order = new Order(
                this.customerId, 
                this.orderItems
            );

            return order;
        }

        public OrderBuilder WithCustomerId(int customerId)
        {
            this.customerId = customerId;
            return this;
        }

        public OrderBuilder WithOrderItems(ICollection<OrderItem> orderItems)
        {
            this.orderItems = orderItems;
            return this;
        }
    }
}