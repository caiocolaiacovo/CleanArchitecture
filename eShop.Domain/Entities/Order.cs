using System.Collections.Generic;
using eShop.Domain._Base;
using eShop.Domain._Util;

namespace eShop.Domain.Entities
{
    public class Order : BaseEntity
    {
        public int CustomerId { get; private set; }
        public int PaymentId { get; private set; }
        public string Voucher { get; private set; }
        public decimal SubtotalItems { get; private set; }
        public decimal TotalDiscountItems { get; private set; }
        public decimal TotalItems { get; private set; }
        public decimal ShippingCosts { get; private set; }
        public decimal Discount { get; private set; }
        public decimal Total { get; private set; }

        public virtual ICollection<OrderItem> OrderItems { get; private set; }
        public virtual Payment Payment { get; private set; }
        public virtual Customer Customer { get; private set; }

        private Order() { }

        public Order(int customerId, ICollection<OrderItem> orderItems)
        {
            DomainValidator.New()
                .When(customerId == 0, "Customer is required")
                .When(orderItems == null || orderItems.Count == 0, "OrderItems is required");

            this.CustomerId = customerId;
            this.OrderItems = orderItems;

            CalculateTotalItems();
        }
        
        private void CalculateTotalItems()
        {
            decimal subtotalItems = 0;
            decimal totalDiscountItems = 0;
            decimal totalItems = 0;

            foreach (var item in OrderItems)
            {
                subtotalItems += item.Subtotal;
                totalDiscountItems += item.Discount;
                totalItems += item.Total;
            }

            SubtotalItems = subtotalItems;
            TotalDiscountItems = totalDiscountItems;
            TotalItems = totalItems;
            
            CalculateOrderTotal();
        }

        private void CalculateOrderTotal()
        {
            Total = (TotalItems + ShippingCosts) - Discount;
        }

        public void AddOrderItem(OrderItem orderItem)
        {
            DomainValidator.New().When(orderItem == null, "OrderItem cannot be null");

            OrderItems.Add(orderItem);
            CalculateTotalItems();
        }

        // public void AddShippingCosts(decimal shippingCosts)
        // {
        //     ShippingCosts = shippingCosts;
        //     CalculateOrderTotal();
        // }

        // public void AddDiscount(decimal discount)
        // {
        //     Discount = discount;
        //     CalculateOrderTotal();
        // }
    }
}