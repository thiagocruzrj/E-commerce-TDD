using ShopDemo.Core.DomainObjects;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ShopDemo.Sales.Domain.Tests
{
    public class OrderItemTests
    {
        [Fact(DisplayName = "New Item Order with units Below Alowed")]
        [Trait("Category", "Order Item Tests")]
        public void AddOrdenItem_ItemBelowAlowed_ShouldReturnException()
        {
            // Arrage, Act & Assert
            Assert.Throws<DomainException>(() => new OrderItem(Guid.NewGuid(), "Product Test", Order.MIN_UNIT_ITEM - 1, 11));
        }
    }
}
