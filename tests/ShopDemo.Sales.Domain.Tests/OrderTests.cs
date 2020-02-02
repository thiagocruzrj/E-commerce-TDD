using ShopDemo.Core.DomainObjects;
using System;
using System.Linq;
using Xunit;

namespace ShopDemo.Sales.Domain.Tests
{
    public class OrderTests
    {
        [Fact(DisplayName = "Add Item Order Empty")]
        [Trait("Category", "Order Tests")]
        public void AddOrderItem_NewOrder_ShouldUpdateValie()
        {
            // Arrange
            var order = Order.OrderFactory.NewOrderDraft(Guid.NewGuid());
            var orderItem = new OrderItem(Guid.NewGuid(),"Product Test", 2, 100);

            // Act
            order.AddItem(orderItem);

            // Assert
            Assert.Equal(200, order.TotalValue);
        }

        [Fact(DisplayName = "Add Item Order Exist")]
        [Trait("Category", "Order Tests")]
        public void AddOrdenItem_ItemExist_ShouldIncrementUnitsAndSumValues()
        {
            // Arrange
            var order = Order.OrderFactory.NewOrderDraft(Guid.NewGuid());
            var productId = Guid.NewGuid();
            var orderItem = new OrderItem(productId, "Product Test", 2, 100);
            order.AddItem(orderItem);
            var orderItem2 = new OrderItem(productId, "Product Test", 1, 100);
            // Act
            order.AddItem(orderItem2);
            // Assert
            Assert.Equal(300, order.TotalValue);
            Assert.Equal(1, order.OrderItems.Count);
            Assert.Equal(3, order.OrderItems.FirstOrDefault(i => i.Id == i.Id).Quantity);
        }

        [Fact(DisplayName = "Add Item Order Above Alowed")]
        [Trait("Category", "Order Tests")]
        public void AddOrdenItem_ItemAboveAlowed_ShouldReturnException()
        {
            // Arrange
            var order = Order.OrderFactory.NewOrderDraft(Guid.NewGuid());
            var productId = Guid.NewGuid();
            var orderItem = new OrderItem(productId, "Product Test", Order.MAX_UNIT_ITEM + 1, 11);

            // Act & Assert
            Assert.Throws<DomainException>(() => order.AddItem(orderItem)); 
        }
    }
}
