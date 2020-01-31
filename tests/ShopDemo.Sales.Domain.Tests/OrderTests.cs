using System;
using Xunit;

namespace ShopDemo.Sales.Domain.Tests
{
    public class OrderTests
    {
        [Fact(DisplayName = "Add Item Order Empty")]
        [Trait("Category", "Order Tests")]
        public void Add_OrderItem_NewOrder_ShouldUpdateValie()
        {
            // Arrange
            var order = new Order();
            var orderItem = new OrderItem(Guid.NewGuid(),"Product Test", 2, 100);

            // Act
            order.AddItem(orderItem);

            // Assert
            Assert.Equal(200, order.TotalValue);
        }
    }
}
