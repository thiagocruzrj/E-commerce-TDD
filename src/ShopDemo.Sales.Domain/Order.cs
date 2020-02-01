using System;
using System.Collections.Generic;
using System.Linq;

namespace ShopDemo.Sales.Domain
{
    public class Order
    {
        public Order()
        {
            _orderItems = new List<OrderItem>();
        }

        public decimal TotalValue { get; private set; }

        private readonly List<OrderItem> _orderItems;
        public IReadOnlyCollection<OrderItem> OrderItems => _orderItems;

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
            TotalValue = OrderItems.Sum(i => i.Quantity * i.UnitValue);
        }
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
    }
}
