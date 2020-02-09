using MediatR;
using ShopDemo.Sales.Application.Events;
using ShopDemo.Sales.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ShopDemo.Sales.Application.Commands
{
    public class OrderCommandHandler : IRequestHandler<AddItemOrderCommand, bool>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMediator _mediator;

        public OrderCommandHandler(IOrderRepository orderRepository, IMediator mediator)
        {
            _orderRepository = orderRepository;
            _mediator = mediator;
        }

        public async Task<bool> Handle(AddItemOrderCommand message, CancellationToken cancellationToken)
        {
            var orderItem = new OrderItem(message.ProductId, message.Name, message.Quantity, message.UnitValue);
            var order = Order.OrderFactory.NewOrderDraft(message.ClientId);
            order.AddItem(orderItem);

            _orderRepository.Add(order);

            await _mediator.Publish(new OrderItemAddedEvent(order.ClientId, order.Id, message.ProductId, message.Name
                , message.UnitValue, message.Quantity), cancellationToken);

            return await _orderRepository.UnitOfWork.Commit();
        }
    }
}
