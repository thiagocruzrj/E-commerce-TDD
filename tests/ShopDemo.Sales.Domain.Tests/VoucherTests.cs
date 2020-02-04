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
            var voucher = new Voucher
            {
                Code = "PROMO-15-REAIS",
                DiscountValue = 15,
                DiscountPercent = null,
                Quantity = 1,
                ValidateDate = DateTime.Now,
                Active = true,
                Used = false
            };

            // Act
            var result = voucher.ValidateIfApplicable();

            // Assert
            Assert.True(result);
        }
    }
}
