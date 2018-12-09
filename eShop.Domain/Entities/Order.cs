using System.Collections.Generic;
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

        public Order(int customerId, ICollection<OrderItem> orderItems)
        {
            DomainValidator.New()
                .When(customerId == 0, "CustomerId is required")
                .When(orderItems == null || orderItems.Count == 0, "OrderItems is required");

            this.CustomerId = customerId;
            this.OrderItems = orderItems;

            CalculateTotalsItems();
        }

        private void CalculateTotalsItems()
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
            DomainValidator.New().When(orderItem == null, "Parameter 'orderItem' cannot be null");

            OrderItems.Add(orderItem);
            CalculateTotalsItems();
        }
    }

    public class OrderItem : BaseEntity
    {
        public int Quantity { get; set; }
        public Product Product { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Discount { get; set; }
        public decimal Total { get; set; }
    }

    public class Payment : BaseEntity
    {
        public Payment()
        {
        }
    }
}