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

            mocker.GetMock<IOrderRepository>().Setup(r => r.UnitOfWork.Commit()).Returns(Task.FromResult(true));

            // Act
            var result = await orderHandler.Handle(orderCommand, CancellationToken.None);

            // Assert
            Assert.True(result);
            mocker.GetMock<IOrderRepository>().Verify(r => r.Add(It.IsAny<Order>()), Times.Once);
            mocker.GetMock<IMediator>().Verify(r => r.Publish(It.IsAny<INotification>(), CancellationToken.None), Times.Once);
        }

        [Fact(DisplayName = "Add New Draft Order Item with sucess")]
        [Trait("Category", "Sales - Order Command Handler")]
        public async Task AddItem_NewDraftOrderItem_ShouldExeculteWithSucess()
        {
            // Arrange
            var clientId = Guid.NewGuid();

            var order = Order.OrderFactory.NewOrderDraft(clientId);
            var orderItemExistent = new OrderItem(Guid.NewGuid(), "Product Xpto", 2, 100);
            order.AddItem(orderItemExistent);

            var orderCommand = new AddItemOrderCommand(clientId, Guid.NewGuid(), "Product Test", 3, 15);

            var mocker = new AutoMocker();
            var orderHandler = mocker.CreateInstance<OrderCommandHandler>();

            mocker.GetMock<IOrderRepository>().Setup(r => r.GetDraftByClientId(clientId)).Returns(Task.FromResult(order));
            mocker.GetMock<IOrderRepository>().Setup(r => r.UnitOfWork.Commit()).Returns(Task.FromResult(true));

            // Act
            var result = await orderHandler.Handle(orderCommand, CancellationToken.None);

            // Assert
            Assert.True(result);
        }
    }
}