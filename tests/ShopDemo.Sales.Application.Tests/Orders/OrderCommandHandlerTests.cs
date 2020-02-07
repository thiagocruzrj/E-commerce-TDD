using MediatR;
using Moq;
using Moq.AutoMock;
using ShopDemo.Sales.Application.Commands;
using ShopDemo.Sales.Domain;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
namespace ShopDemo.Sales.Application.Tests.Orders
{
    public class OrderCommandHandlerTests
    {
        [Fact(DisplayName = "Add Item New Order with Success")]
        [Trait("Category", "Sales - Order Command Handler")]
        public async Task AddItem_NewOrder_ShouldExeculteWithSuccess()
        {
            // Arrange
            var orderCommand = new AddItemOrderCommand(Guid.NewGuid(), Guid.NewGuid(), "Product Test", 2, 100);

            var mocker = new AutoMocker();
            var orderHandler = mocker.CreateInstance<OrderCommandHandler>();

            // Act
            var result = await orderHandler.Handle(orderCommand, CancellationToken.None);

            // Assert
            Assert.True(result);
            mocker.GetMock<IOrderRepository>().Verify(r => r.Add(It.IsAny<Order>()), Times.Once);
            mocker.GetMock<IMediator>().Verify(r => r.Publish(It.IsAny<INotification>(), CancellationToken.None), Times.Once);
        }
    }
}