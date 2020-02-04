using System;
using System.Linq;
using Xunit;
namespace ShopDemo.Sales.Domain.Tests
{
    public class VoucherTests
    {
        [Fact(DisplayName = "Validate Voucher Type Valid Value")]
        [Trait("Category", "Sales - Voucher")]
        public void Voucher_ValidateVoucherTypeValue_ShouldBeValid()
        {
            // Arrange
            var voucher = new Voucher("PROMO-15-REAIS", null, 15, TypeVoucherDiscount.Value, 1, DateTime.Now.AddDays(15), true, false);

            // Act
            var result = voucher.ValidateIfApplicable();

            // Assert
            Assert.True(result.IsValid);
        }

        [Fact(DisplayName = "Validate Voucher Type Invalid Value")]
        [Trait("Category", "Sales - Voucher")]
        public void Voucher_ValidateVoucherTypeValue_ShouldBeInvalid()
        {
            // Arrange
            var voucher = new Voucher("", null, null, TypeVoucherDiscount.Value, 0, DateTime.Now.AddDays(-1), false, true);

            // Act
            var result = voucher.ValidateIfApplicable();

            // Assert
            Assert.False(result.IsValid);
            Assert.Equal(6, result.Errors.Count);
            Assert.Contains(VoucherApplicableValidation.ActiveErrorMsg, result.Errors.Select(c => c.ErrorMessage));
            Assert.Contains(VoucherApplicableValidation.CodeErrroMsg, result.Errors.Select(c => c.ErrorMessage));
            Assert.Contains(VoucherApplicableValidation.ExpirationDateErrorMsg, result.Errors.Select(c => c.ErrorMessage));
            Assert.Contains(VoucherApplicableValidation.QuantityErrorMsg, result.Errors.Select(c => c.ErrorMessage));
            Assert.Contains(VoucherApplicableValidation.UsedErrorMessage, result.Errors.Select(c => c.ErrorMessage));
            Assert.Contains(VoucherApplicableValidation.DiscountValueErrorMsg, result.Errors.Select(c => c.ErrorMessage));
        }
    }
}
