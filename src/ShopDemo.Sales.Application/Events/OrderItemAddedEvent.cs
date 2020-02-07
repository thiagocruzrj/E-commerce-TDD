using ShopDemo.Core.Messages;
using System;

namespace ShopDemo.Sales.Application.Events
{
    public class OrderItemAddedEvent : Event
    {
        public OrderItemAddedEvent(Guid clientId, Guid orderId, Guid productId, string productName, decimal unitValue, int quantity)
        {
            ClientId = clientId;
            OrderId = orderId;
            ProductId = productId;
            ProductName = productName;
            UnitValue = unitValue;
            Quantity = quantity;
        }

        public Guid ClientId { get; private set; }
        public Guid OrderId { get; private set; }
        public Guid ProductId { get; private set; }
        public string ProductName { get; private set; }
        public decimal UnitValue { get; private set; }
        public int Quantity { get; private set; }
    }
}
