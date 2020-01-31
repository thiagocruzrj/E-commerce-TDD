using System;
using System.Collections.Generic;
using System.Text;

namespace ShopDemo.Sales.Domain
{
    public class Order
    {
        public decimal TotalValue { get; set; }
        public void AddItem(OrderItem orderItem)
        {
            TotalValue = 200;
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

        public Guid Id { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal UnitValue { get; set; }
    }
}
