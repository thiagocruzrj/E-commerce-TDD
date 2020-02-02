﻿using ShopDemo.Core.DomainObjects;
using System;
using System.Linq;
using Xunit;

namespace ShopDemo.Sales.Domain.Tests
{
    public class OrderTests
    {
        [Fact(DisplayName = "Add Item Order Empty")]
        [Trait("Category", "Sales - Order")]
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
        [Trait("Category", "Sales - Order")]
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
        [Trait("Category", "Sales - Order")]
        public void AddOrdenItem_ItemAboveAlowed_ShouldReturnException()
        {
            // Arrange
            var order = Order.OrderFactory.NewOrderDraft(Guid.NewGuid());
            var productId = Guid.NewGuid();
            var orderItem = new OrderItem(productId, "Product Test", Order.MAX_UNIT_ITEM + 1, 11);

            // Act & Assert
            Assert.Throws<DomainException>(() => order.AddItem(orderItem)); 
        }

        [Fact(DisplayName = "Add Existent Item Order Above Alowed")]
        [Trait("Category", "Sales - Order")]
        public void AddOrdenItem_ItemExistentSumUnitsAboveAlowed_ShouldReturnException()
        {
            // Arrange
            var order = Order.OrderFactory.NewOrderDraft(Guid.NewGuid());
            var productId = Guid.NewGuid();
            var orderItem = new OrderItem(productId, "Product Test", 1, 11);
            var orderItem2 = new OrderItem(productId, "Product Test", Order.MAX_UNIT_ITEM, 11);
            order.AddItem(orderItem);

            // Act & Assert
            Assert.Throws<DomainException>(() => order.AddItem(orderItem2));
        }

        [Fact(DisplayName = "Update Order Item Noexistent")]
        [Trait("Category", "Sales - Order")]
        public void UpdateOrderItem_ItemNoexistOnList_ShouldReturnException()
        {
            // Arrange
            var order = Order.OrderFactory.NewOrderDraft(Guid.NewGuid());
            var orderItemUpdated = new OrderItem(Guid.NewGuid(), "Product Test", 5, 10);
            // Act & Assert
            Assert.Throws<DomainException>(() => order.UpdateItem(orderItemUpdated));
        }

        [Fact(DisplayName = "Update Order Item Valid")]
        [Trait("Category", "Sales - Order")]
        public void UpdateOrderItem_ValidItem_ShouldUpdateQuantity()
        {
            // Arrange
            var order = Order.OrderFactory.NewOrderDraft(Guid.NewGuid());
            var productId = Guid.NewGuid();
            var orderItem = new OrderItem(productId, "product test", 2, 100);
            order.AddItem(orderItem);
            var orderItemUpdated = new OrderItem(productId, "product test", 4, 100);
            var newQuantity = orderItemUpdated.Quantity;

            // Act
            order.UpdateItem(orderItemUpdated);

            // Assert
            Assert.Equal(newQuantity, order.OrderItems.FirstOrDefault(p => p.Id == p.Id).Quantity);
        }

        [Fact(DisplayName = "Update Item Order Validate Total")]
        [Trait("Category", "Sales - Order")]
        public void UpdateOrderItem_OrderWithDifferentProducts_ShouldUpdateTotalValue()
        {
            // Arrange
            var order = Order.OrderFactory.NewOrderDraft(Guid.NewGuid());
            var productId = Guid.NewGuid();
            var orderItemExistent1 = new OrderItem(Guid.NewGuid(), "Product Xpto", 2, 100);
            var orderItemExistent2 = new OrderItem(productId, "Product Test", 3, 15);
            order.AddItem(orderItemExistent1);
            order.AddItem(orderItemExistent2);

            var orderItemUpdated = new OrderItem(productId, "Product Test", 5, 15);
            var totalOrderValue = orderItemExistent1.Quantity * orderItemExistent1.UnitValue +
                                  orderItemUpdated.Quantity * orderItemUpdated.UnitValue;

            // Act
            order.UpdateItem(orderItemUpdated);

            // Assert
            Assert.Equal(totalOrderValue, order.TotalValue);
        }
    }
}
