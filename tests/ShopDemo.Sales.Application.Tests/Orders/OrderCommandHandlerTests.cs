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
        private readonly AutoMocker _mocker;
        private readonly OrderCommandHandler _orderCommandHandler;
        private readonly Order _order;
        private readonly Guid _clientId;
        private readonly Guid _productId;

        public OrderCommandHandlerTests()
        {
            _mocker = new AutoMocker();
            _orderCommandHandler = _mocker.CreateInstance<OrderCommandHandler>();
            _clientId = Guid.NewGuid();
            _productId = Guid.NewGuid();
            _order = Order.OrderFactory.NewOrderDraft(_clientId);
        }

        [Fact(DisplayName = "Add Item New Order with Success")]
        [Trait("Category", "Sales - Order Command Handler")]
        public async Task AddItem_NewOrder_ShouldExeculteWithSuccess()
        {
            // Arrange
            var orderCommand = new AddItemOrderCommand(Guid.NewGuid(), Guid.NewGuid(), "Product Test", 2, 100);
            var orderHandler = _mocker.CreateInstance<OrderCommandHandler>();

            _mocker.GetMock<IOrderRepository>().Setup(r => r.UnitOfWork.Commit()).Returns(Task.FromResult(true));

            // Act
            var result = await _orderCommandHandler.Handle(orderCommand, CancellationToken.None);

            // Assert
            Assert.True(result);
            _mocker.GetMock<IOrderRepository>().Verify(r => r.Add(It.IsAny<Order>()), Times.Once);
            _mocker.GetMock<IMediator>().Verify(r => r.Publish(It.IsAny<INotification>(), CancellationToken.None), Times.Once);
        }

        [Fact(DisplayName = "Add New Draft Order Item with sucess")]
        [Trait("Category", "Sales - Order Command Handler")]
        public async Task AddItem_NewDraftOrderItem_ShouldExecuteWithSucess()
        {
            // Arrange
            var orderItemExistent = new OrderItem(Guid.NewGuid(), "Product Xpto", 2, 100);
            _order.AddItem(orderItemExistent);

            var orderCommand = new AddItemOrderCommand(_clientId, Guid.NewGuid(), "Product Test", 3, 15);

            var orderHandler = _mocker.CreateInstance<OrderCommandHandler>();

            _mocker.GetMock<IOrderRepository>().Setup(r => r.GetOrderDraftByClientId(_clientId)).Returns(Task.FromResult(_order));
            _mocker.GetMock<IOrderRepository>().Setup(r => r.UnitOfWork.Commit()).Returns(Task.FromResult(true));

            // Act
            var result = await _orderCommandHandler.Handle(orderCommand, CancellationToken.None);

            // Assert
            Assert.True(result);
            _mocker.GetMock<IOrderRepository>().Verify(r => r.AddItem(It.IsAny<OrderItem>()), Times.Once);
            _mocker.GetMock<IOrderRepository>().Verify(r => r.Update(It.IsAny<Order>()), Times.Once);
            _mocker.GetMock<IOrderRepository>().Verify(r => r.UnitOfWork.Commit(), Times.Once);
        }

        [Fact(DisplayName = "Add New Draft Existent Order Item with sucess")]
        [Trait("Category", "Sales - Order Command Handler")]
        public async Task AddItem_NewExistentDraftOrderItem_ShouldExecuteWithSucess()
        {
            // Assert
            var orderItemExistent = new OrderItem(_productId, "Product Xpto", 2, 100);
            _order.AddItem(orderItemExistent);

            var orderCommand = new AddItemOrderCommand(_clientId, _productId, "Product Xpto", 2, 100);

            var orderHandler = _mocker.CreateInstance<OrderCommandHandler>();

            _mocker.GetMock<IOrderRepository>().Setup(r => r.GetOrderDraftByClientId(_clientId)).Returns(Task.FromResult(_order));
            _mocker.GetMock<IOrderRepository>().Setup(r => r.UnitOfWork.Commit()).Returns(Task.FromResult(true));

            // Act
            var result = await _orderCommandHandler.Handle(orderCommand, CancellationToken.None);

            // Assert
            Assert.True(result);
            _mocker.GetMock<IOrderRepository>().Verify(r => r.UpdateItem(It.IsAny<OrderItem>()), Times.Once);
            _mocker.GetMock<IOrderRepository>().Verify(r => r.Update(It.IsAny<Order>()), Times.Once);
            _mocker.GetMock<IOrderRepository>().Verify(r => r.UnitOfWork.Commit(), Times.Once);
        }

        [Fact(DisplayName = "Add New Order Item Invalid")]
        [Trait("Category", "Sales - Order Command Handler")]
        public async Task AddItem_InvalidCommand_ShouldReturnFalseAndSendNotificationEvents()
        {
            // Arrage
            var orderCommand = new AddItemOrderCommand(Guid.Empty, Guid.Empty, "", 0, 0);
            var orderHandler = _mocker.CreateInstance<OrderCommandHandler>();

            // Act
            var result = await _orderCommandHandler.Handle(orderCommand, CancellationToken.None);

            // Assert
            Assert.False(result);
            _mocker.GetMock<IMediator>().Verify(r => r.Publish(It.IsAny<INotification>(), CancellationToken.None), Times.Exactly(5));
        }
    }
}