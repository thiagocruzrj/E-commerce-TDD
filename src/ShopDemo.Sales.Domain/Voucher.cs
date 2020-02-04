using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopDemo.Sales.Domain
{
    public class Voucher
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

        public ValidationResult ValidateIfApplicable()
        {
            return new VoucherApplicableValidation().Validate(this);
        }
    }

    public class VoucherApplicableValidation : AbstractValidator<Voucher>
    {
        public static string CodeErrroMsg => "Voucher sem código válido.";
        public static string ExpirationDateErrorMsg => "Este voucher está expirado.";
        public static string ActiveErrorMsg => "Este voucher não é mais válido.";
        public static string UsedErrorMessage => "Este voucher já foi utilizado.";
        public static string QuantityErrorMsg => "Este voucher não está mais disponível";
        public static string DiscountValueErrorMsg => "O valor do desconto precisa ser superior a 0";
        public static string DiscountPercentErrorMsg => "O valor da porcentagem de desconto precisa ser superior a 0";

        public VoucherApplicableValidation()
        {
            RuleFor(c => c.Code)
                .NotEmpty()
                .WithMessage(CodeErrroMsg);

            RuleFor(c => c.ExpirationDate)
                .Must(ExpirationDateMustBeGreaterThanCurrent)
                .WithMessage(ExpirationDateErrorMsg);

            RuleFor(c => c.Active)
                .Equal(true)
                .WithMessage(ActiveErrorMsg);

            RuleFor(c => c.Used)
                .Equal(false)
                .WithMessage(UsedErrorMessage);

            RuleFor(c => c.Quantity)
                .GreaterThan(0)
                .WithMessage(QuantityErrorMsg);

            When(f => f.TypeVoucherDiscount == TypeVoucherDiscount.Percent, () =>
            {
                RuleFor(f => f.DiscountPercent)
                    .NotNull()
                    .WithMessage(DiscountPercentErrorMsg)
                    .GreaterThan(0)
                    .WithMessage(DiscountPercentErrorMsg);
            });

            When(f => f.TypeVoucherDiscount == TypeVoucherDiscount.Value, () =>
            {
                RuleFor(f => f.DiscountValue)
                    .NotNull()
                    .WithMessage(DiscountValueErrorMsg)
                    .GreaterThan(0)
                    .WithMessage(DiscountValueErrorMsg);
            });
        }

        protected static bool ExpirationDateMustBeGreaterThanCurrent(DateTime expDate)
        {
            return expDate >= DateTime.Now;
        }
    }

    public enum TypeVoucherDiscount
    {
        Percent = 1,
        Value = 2
    }
}
