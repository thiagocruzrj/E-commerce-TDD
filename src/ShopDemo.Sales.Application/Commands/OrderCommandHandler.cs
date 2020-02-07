using MediatR;
using ShopDemo.Sales.Application.Events;
using ShopDemo.Sales.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopDemo.Sales.Application.Commands
{
    public class OrderCommandHandler
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMediator _mediator;

        public OrderCommandHandler(IOrderRepository orderRepository, IMediator mediator)
        {
            _orderRepository = orderRepository;
            _mediator = mediator;
        }

        public bool Handler(AddItemOrderCommand message)
        {
            _orderRepository.Add(Order.OrderFactory.NewOrderDraft(message.ClientId));
            _mediator.Publish(new OrderItemAddedEvent());
            return true;
        }
    }
}
