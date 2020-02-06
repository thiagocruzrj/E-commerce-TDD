using ShopDemo.Sales.Application.Commands;
using System;
using Xunit;
namespace ShopDemo.Sales.Application.Tests.Orders
{
    public class AddItemOrderCommandTests
    {
        [Fact(DisplayName = "Add Item Command Valid")]
        [Trait("Category", "Sales - OrderCommands")]
        public void AddItemOrderCommand_CommandIsValid_ShouldPassInValidation()
        {
            // Arrange
            var orderCommand = new AddItemOrderCommand(Guid.NewGuid(), Guid.NewGuid(), "Product Test", 2, 100);

            // Act
            var result = orderCommand.IsValid();

            // Assert
            Assert.True(result);
        }
    }
}
