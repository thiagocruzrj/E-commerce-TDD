using FluentValidation.Results;
using ShopDemo.Core.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ShopDemo.Sales.Domain
{
    public class Order
    {
        public static int MAX_UNIT_ITEM => 15;
        public static int MIN_UNIT_ITEM => 1;

        protected Order()
        {
            _orderItems = new List<OrderItem>();
        }

        public Guid ClientId { get; private set; }

        public decimal TotalValue { get; private set; }

        public OrderStatus OrderStatus { get; private set; }

        private readonly List<OrderItem> _orderItems;
        public IReadOnlyCollection<OrderItem> OrderItems => _orderItems;

        public ValidationResult ApplyVoucher(Voucher voucher)
        {
            return voucher.ValidateIfApplicable();
        }

        private void CalculateOrderValue()
        {
            TotalValue = OrderItems.Sum(i => i.CalculateValue());
        }

        private bool OrderItemExistent(OrderItem item)
        {
            return _orderItems.Any(p => p.Id == item.Id);
        }

        private void ValidateQuantityItemAllowed(OrderItem item)
        {
            var itemQuantity = item.Quantity;
            if (OrderItemExistent(item))
            {
                var itemExistent = _orderItems.FirstOrDefault(p => p.Id == p.Id);
                itemQuantity += itemExistent.Quantity;
            }

            if (itemQuantity > MAX_UNIT_ITEM) throw new DomainException($"Max of {MAX_UNIT_ITEM} units per product");
        }


        private void ValidateOrderItemNoexistent(OrderItem item)
        {
            if (!OrderItemExistent(item)) throw new DomainException($"Item doesn't exist on order");
        }

        public void AddItem(OrderItem orderItem)
        {
            ValidateQuantityItemAllowed(orderItem);

            if (OrderItemExistent(orderItem))
            {
                var existingItem = _orderItems.FirstOrDefault(p => p.Id == orderItem.Id);

                existingItem.AddUnits(orderItem.Quantity);
                orderItem = existingItem;
                _orderItems.Remove(existingItem);
            }
            _orderItems.Add(orderItem);
            CalculateOrderValue();
        }

        public void UpdateItem(OrderItem orderItem)
        {
            ValidateOrderItemNoexistent(orderItem);
            ValidateQuantityItemAllowed(orderItem);

            var itemExistent = OrderItems.FirstOrDefault(p => p.Id == orderItem.Id);

            _orderItems.Remove(itemExistent);
            _orderItems.Add(orderItem);

            CalculateOrderValue();
        }

        public void RemoveItem(OrderItem orderItem)
        {
            ValidateOrderItemNoexistent(orderItem);

            _orderItems.Remove(orderItem);

            CalculateOrderValue();
        }

        public void BecomeDraft()
        {
            OrderStatus = OrderStatus.Draft;
        }

        public static class OrderFactory
        {
            public static Order NewOrderDraft(Guid clientId)
            {
                var order = new Order
                {
                    ClientId = clientId,
                };

                order.BecomeDraft();
                return order;
            }
        }
    }
}
