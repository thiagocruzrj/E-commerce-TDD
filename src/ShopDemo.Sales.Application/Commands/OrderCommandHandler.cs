using MediatR;
using ShopDemo.Sales.Application.Events;
using ShopDemo.Sales.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
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
            if (!message.IsValid())
            {
                foreach (var error in message.ValidationResult.Errors)
                {
                    _mediator.Publish(new DomainNotification(message.MessageType, error.ErrorMessage));
                }

                return false;
            }

            var order = await _orderRepository.GetDraftByClientId(message.ClientId);
            var orderItem = new OrderItem(message.ProductId, message.Name, message.Quantity, message.UnitValue);

            if (order == null)
            {
                order = Order.OrderFactory.NewOrderDraft(message.ClientId);
                order.AddItem(orderItem);

                _orderRepository.Add(order);
            } else
            {
                var orderItemExistent = order.OrderItemExistent(orderItem);
                order.AddItem(orderItem);

                if (orderItemExistent)
                {
                    _orderRepository.UpdateItem(order.OrderItems.FirstOrDefault(p => p.Id == orderItem.Id));
                } else
                {
                    _orderRepository.AddItem(orderItem);
                }

                _orderRepository.Update(order);
            }

            await _mediator.Publish(new OrderItemAddedEvent(order.ClientId, order.Id, message.ProductId, message.Name
                , message.UnitValue, message.Quantity));

            return await _orderRepository.UnitOfWork.Commit();
        }
    }
}
