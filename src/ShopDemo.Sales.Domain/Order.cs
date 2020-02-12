using FluentValidation.Results;
using ShopDemo.Core.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ShopDemo.Sales.Domain
{
    public partial class Order : Entity, IAggregateRoot
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

        public bool VoucherUsed { get; private set; }
        public Voucher Voucher { get; private set; }
        public Guid? VoucherId { get; private set; }
        public decimal Discount { get; private set; }

        private readonly List<OrderItem> _orderItems;
        public IReadOnlyCollection<OrderItem> OrderItems => _orderItems;

        public ValidationResult ApplyVoucher(Voucher voucher)
        {
            var result = voucher.ValidateIfApplicable();
            if (!result.IsValid) return result;

            Voucher = voucher;
            VoucherUsed = true;

            CalculateTotalDiscountValue();

            return result;
        }

        public void CalculateTotalDiscountValue()
        {
            if (!VoucherUsed) return;

            decimal discount = 0;
            var value = TotalValue;
            
            if (Voucher.TypeVoucherDiscount == TypeVoucherDiscount.Value)
            {
                if (Voucher.DiscountValue.HasValue)
                {
                    discount = Voucher.DiscountValue.Value;
                    value -= discount;
                }
            } else
            {
                if (Voucher.DiscountPercent.HasValue)
                {
                    discount = (TotalValue * Voucher.DiscountPercent.Value) / 100;
                    value -= discount;
                }
            }
            TotalValue = value < 0 ? 0 : value;
            Discount = discount;
        }

        private void CalculateOrderValue()
        {
            TotalValue = OrderItems.Sum(i => i.CalculateValue());
            CalculateTotalDiscountValue();
        }

        public bool OrderItemExistent(OrderItem item)
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
    }
}
