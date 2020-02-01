using System;
using System.Collections.Generic;
using System.Linq;

namespace ShopDemo.Sales.Domain
{
    public class Order
    {
        protected Order()
        {
            _orderItems = new List<OrderItem>();
        }

        public Guid ClientId { get; private set; }

        public decimal TotalValue { get; private set; }

        public OrderStatus OrderStatus { get; private set; }

        private readonly List<OrderItem> _orderItems;
        public IReadOnlyCollection<OrderItem> OrderItems => _orderItems;

        public void CalculateOrderValue()
        {
            TotalValue = OrderItems.Sum(i => i.CalculateValue());
        }

        public void AddItem(OrderItem orderItem)
        {
            if (_orderItems.Any(p => p.Id == orderItem.Id))
            {
                var existingItem = _orderItems.FirstOrDefault(p => p.Id == orderItem.Id);
                existingItem.AddUnits(orderItem.Quantity);
                orderItem = existingItem;

                _orderItems.Remove(existingItem);
            }
            _orderItems.Add(orderItem);
            CalculateOrderValue();
        }

        public void BecomeDraft()
        {
            OrderStatus = OrderStatus.Draft;
        }

        public static class OrderFactory
        {
            public static Order NewOrderDraft(Guid clientId)
            {
                var order = new Order
                {
                    ClientId = clientId,
                };

                order.BecomeDraft();
                return order;
            }
        }
    }

    public enum OrderStatus
    {
        Draft = 0,
        Started = 1,
        Paid = 4,
        Delivered = 5,
        Canceled = 6
    }

    public class OrderItem
    {
        public OrderItem(Guid id, string productName, int quantity, decimal unitValue)
        {
            Id = id;
            ProductName = productName;
            Quantity = quantity;
            UnitValue = unitValue;
        }

        public Guid Id { get; private set; }
        public string ProductName { get; private set; }
        public int Quantity { get; private set; }
        public decimal UnitValue { get; private set; }

        internal void AddUnits(int units)
        {
            Quantity += units;
        }

        internal decimal CalculateValue()
        {
            return Quantity * UnitValue;
        }
    }
}
