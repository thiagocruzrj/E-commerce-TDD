using ShopDemo.Core.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ShopDemo.Sales.Domain
{
    public class Order
    {
        public static int MAX_UNIT_ITEM => 15;
        public static int MIN_UNIT_ITEM => 1;

        protected Order()
        {
            _orderItems = new List<OrderItem>();
        }

        public Guid ClientId { get; private set; }

        public decimal TotalValue { get; private set; }

        public OrderStatus OrderStatus { get; private set; }

        private readonly List<OrderItem> _orderItems;
        public IReadOnlyCollection<OrderItem> OrderItems => _orderItems;

        private void CalculateOrderValue()
        {
            TotalValue = OrderItems.Sum(i => i.CalculateValue());
        }

        public void AddItem(OrderItem orderItem)
        {
            if (orderItem.Quantity > MAX_UNIT_ITEM) throw new DomainException($"Max of {MAX_UNIT_ITEM} units per product");
            if (orderItem.Quantity < MIN_UNIT_ITEM) throw new DomainException($"Min of {MIN_UNIT_ITEM} units per product");

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
