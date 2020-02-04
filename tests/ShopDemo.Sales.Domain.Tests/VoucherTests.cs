using System;
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
    }
}
