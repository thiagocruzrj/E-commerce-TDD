using ShopDemo.Core.DomainObjects;
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

        [Fact(DisplayName = "Update Order Item Quantity Above allowed")]
        [Trait("Category", "Sales - Order")]
        public void UpdateOrderItem_UnitItemAboveAlowed_shouldReturnException()
        {
            // Arrange
            var order = Order.OrderFactory.NewOrderDraft(Guid.NewGuid());
            var productId = Guid.NewGuid();
            var orderItemExistent1 = new OrderItem(productId, "Product Test", 3, 15);
            order.AddItem(orderItemExistent1);

            var orderItemUpdated = new OrderItem(productId, "Product Test", Order.MAX_UNIT_ITEM + 1, 15);

            // Act & Assert
            Assert.Throws<DomainException>(() => order.UpdateItem(orderItemUpdated));
        }

        [Fact(DisplayName = "Remove Order Item Noexistent")]
        [Trait("Categoria", "Sales - Order")]
        public void RemoveOrderItem_ItemNoexistentOnList_ShouldReturnTotalValue()
        {
            // Arrange
            var order = Order.OrderFactory.NewOrderDraft(Guid.NewGuid());
            var orderItemRemove = new OrderItem(Guid.NewGuid(), "Product Test", 5, 100);

            // Act & Act
            Assert.Throws<DomainException>(() => order.RemoveItem(orderItemRemove));
        }

        [Fact(DisplayName = "Remove Order Item Should Calculate total value")]
        [Trait("Categoria", "Sales - Order")]
        public void RemoveOrderItem_ItemExistent_ShouldUpdateTotalValue()
        {
            // Arrange
            var order = Order.OrderFactory.NewOrderDraft(Guid.NewGuid());
            var productId = Guid.NewGuid();
            var productItem1 = new OrderItem(Guid.NewGuid(), "Product Xpto", 2, 100);
            var productItem2 = new OrderItem(productId, "Product Test", 3, 15);
            order.AddItem(productItem1);
            order.AddItem(productItem2);

            var totalOrder = productItem2.Quantity * productItem2.UnitValue;

            // Act
            order.RemoveItem(productItem1);

            // Assert
            Assert.Equal(totalOrder, order.TotalValue);
        }

        [Fact(DisplayName = "Apply valid voucher")]
        [Trait("Categoria", "Sales - Order")]
        public void Order_ApplyValidVoucher_ShouldReturnWithNoErrors()
        {
            // Arrange
            var order = Order.OrderFactory.NewOrderDraft(Guid.NewGuid());
            var voucher = new Voucher("PROMO-15-REAIS", null, 15, TypeVoucherDiscount.Value, 1, DateTime.Now.AddDays(15), true, false);

            // Act
            var result = order.ApplyVoucher(voucher);

            // Assert
            Assert.True(result.IsValid);
        }

        [Fact(DisplayName = "Apply invalid voucher")]
        [Trait("Categoria", "Sales - Order")]
        public void Order_ApplyValidVoucher_ShouldReturnWithErrors()
        {
            // Arrange
            var order = Order.OrderFactory.NewOrderDraft(Guid.NewGuid());
            var voucher = new Voucher("", null, null, TypeVoucherDiscount.Value, 0, DateTime.Now.AddDays(-1), false, true);

            // Act
            var result = order.ApplyVoucher(voucher);

            // Assert
            Assert.False(result.IsValid);
        }

        [Fact(DisplayName = "Apply voucher type value discount")]
        [Trait("Category", "Sales - Order")]
        public void ApplyVoucher_VoucherTypeValueDiscount_ShouldDiscountTotalValue()
        {
            // Arrange
            var order = Order.OrderFactory.NewOrderDraft(Guid.NewGuid());
            var productItem1 = new OrderItem(Guid.NewGuid(), "Product Xpto", 2, 100);
            var productItem2 = new OrderItem(Guid.NewGuid(), "Product Test", 3, 15);
            order.AddItem(productItem1);
            order.AddItem(productItem2);

            var voucher = new Voucher("PROMO-15-REAIS", null, 15, TypeVoucherDiscount.Value, 1, DateTime.Now.AddDays(15), true, false);

            var valueWithDiscount = order.TotalValue - voucher.DiscountValue;

            // Act
            order.ApplyVoucher(voucher);

            // Assert
            Assert.Equal(valueWithDiscount, order.TotalValue);
        }

        [Fact(DisplayName = "Apply voucher type percent discount")]
        [Trait("Category", "Sales - Order")]
        public void ApplyVCoucher_VoucherTypePercentDiscount_ShouldDiscountTotalValue()
        {
            // Arrange
            var order = Order.OrderFactory.NewOrderDraft(Guid.NewGuid());
            var productItem1 = new OrderItem(Guid.NewGuid(), "Product Xpto", 2, 100);
            var productItem2 = new OrderItem(Guid.NewGuid(), "Product Test", 3, 15);
            order.AddItem(productItem1);
            order.AddItem(productItem2);

            var voucher = new Voucher("PROMO-15-REAIS", 10, null, TypeVoucherDiscount.Percent, 1, DateTime.Now.AddDays(15), true, false);

            var discountValue = (order.TotalValue * voucher.DiscountPercent) / 100;
            var valueWithDiscount = order.TotalValue - discountValue;

            // Act
            order.ApplyVoucher(voucher);

            // Assert
            Assert.Equal(valueWithDiscount, order.TotalValue);
        }
    }
}
