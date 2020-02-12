using ShopDemo.Core.DomainObjects;
using System;

namespace ShopDemo.Sales.Domain
{
    public class OrderItem
    {
        public OrderItem(Guid id, string productName, int quantity, decimal unitValue)
        {
            if (quantity < Order.MIN_UNIT_ITEM) throw new DomainException($"Min of {Order.MIN_UNIT_ITEM} units per product");

            Id = id;
            ProductName = productName;
            Quantity = quantity;
            UnitValue = unitValue;
        }

        public Guid Id { get; private set; }
        public string ProductName { get; private set; }
        public int Quantity { get; private set; }
        public decimal UnitValue { get; private set; }

        // EF Rel.
        public Order Order { get; set; }

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
