using System;

namespace ShopDemo.Sales.Application.Commands
{
    public class AddItemOrderCommand
    {
        public AddItemOrderCommand(Guid clientId, Guid productId, string name, int quantity, decimal unitValue)
        {
            ClientId = clientId;
            ProductId = productId;
            Name = name;
            Quantity = quantity;
            UnitValue = unitValue;
        }

        public Guid ClientId { get; set; }
        public Guid ProductId { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal UnitValue { get; set; }

        public bool IsValid()
        {
            return false;
        }
    }
}
