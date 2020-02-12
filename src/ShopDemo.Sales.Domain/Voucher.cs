using FluentValidation.Results;
using ShopDemo.Core.DomainObjects;
using System;
using System.Collections.Generic;

namespace ShopDemo.Sales.Domain
{
    public class Voucher : Entity
    {
        public Voucher(string code, decimal? discountPercent, decimal? discountValue, TypeVoucherDiscount typeVoucherDiscount, 
                       int quantity, DateTime expirationDate, bool active, bool used)
        {
            Code = code;
            DiscountPercent = discountPercent;
            DiscountValue = discountValue;
            TypeVoucherDiscount = typeVoucherDiscount;
            Quantity = quantity;
            ExpirationDate = expirationDate;
            Active = active;
            Used = used;
        }

        public string Code { get; private set; }
        public decimal? DiscountPercent { get; private set; }
        public decimal? DiscountValue { get; private set; }
        public TypeVoucherDiscount TypeVoucherDiscount { get; private set; }
        public int Quantity { get; private set; }
        public DateTime ExpirationDate { get; private set; }
        public bool Active { get; private set; }
        public bool Used { get; private set; }

        // EF Rel.
        public ICollection<Order> Orders { get; set; }

        public ValidationResult ValidateIfApplicable()
        {
            return new VoucherApplicableValidation().Validate(this);
        }
    }
}
