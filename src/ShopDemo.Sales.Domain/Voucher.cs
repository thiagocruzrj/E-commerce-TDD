using System;
using System.Collections.Generic;
using System.Text;

namespace ShopDemo.Sales.Domain
{
    public class Voucher
    {
        public string Code { get; set; }
        public decimal? DiscountPercent { get; set; }
        public decimal? DiscountValue { get; set; }
        public int Quantity { get; set; }
        public DateTime ValidateDate { get; set; }
        public bool Active { get; set; }
        public bool Used { get; set; }

        public bool ValidateIfApplicable()
        {
            return false;
        }
    }
}
