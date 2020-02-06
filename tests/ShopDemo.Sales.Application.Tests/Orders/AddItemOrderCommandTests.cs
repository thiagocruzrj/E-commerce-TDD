using ShopDemo.Sales.Application.Commands;
using ShopDemo.Sales.Domain;
using System;
using System.Linq;
using Xunit;
namespace ShopDemo.Sales.Application.Tests.Orders
{
    public class AddItemOrderCommandTests
    {
        [Fact(DisplayName = "Add Item Command Valid")]
        [Trait("Category", "Sales - OrderCommands")]
        public void AddItemOrderCommand_CommandIsValid_ShouldPassOnValidation()
        {
            // Arrange
            var orderCommand = new AddItemOrderCommand(Guid.NewGuid(), Guid.NewGuid(), "Product Test", 2, 100);

            // Act
            var result = orderCommand.IsValid();

            // Assert
            Assert.True(result);
        }

        [Fact(DisplayName = "Add Item Command Invalid")]
        [Trait("Category", "Sales - OrderCommands")]
        public void AddItemOrderCommand_CommandIsInvalid_ShouldntPassOnValidation()
        {
            // Arrange
            var orderCommand = new AddItemOrderCommand(Guid.Empty, Guid.Empty, "", 0, 0);

            // Act
            var result = orderCommand.IsValid();

            // Assert
            Assert.False(result);
            Assert.Contains(AddOrderItemValidation.IdClientErrorMsg, orderCommand.ValidationResult.Errors.Select(c => c.ErrorMessage));
            Assert.Contains(AddOrderItemValidation.IdProductErrorMsg, orderCommand.ValidationResult.Errors.Select(c => c.ErrorMessage));
            Assert.Contains(AddOrderItemValidation.NameErrorMsg, orderCommand.ValidationResult.Errors.Select(c => c.ErrorMessage));
            Assert.Contains(AddOrderItemValidation.QtyMinErrorMsg, orderCommand.ValidationResult.Errors.Select(c => c.ErrorMessage));
            Assert.Contains(AddOrderItemValidation.ValueErrorMsg, orderCommand.ValidationResult.Errors.Select(c => c.ErrorMessage));
        }

        [Fact(DisplayName = "Add Item Command unit above the allowed")]
        [Trait("Category", "Sales - OrderCommands")]
        public void AddItemOrderCommand_UnitQuantityAboveAllowed_ShouldntPassOnValidation()
        {
            // Arrange
            var orderCommand = new AddItemOrderCommand(Guid.NewGuid(), Guid.NewGuid(), "Product Test", Order.MAX_UNIT_ITEM + 1, 100);

            // Act
            var result = orderCommand.IsValid();

            // Assert
            Assert.False(result);
            Assert.Contains(AddOrderItemValidation.QtyMaxErrorMsg, orderCommand.ValidationResult.Errors.Select(c => c.ErrorMessage));
        }
    }
}
