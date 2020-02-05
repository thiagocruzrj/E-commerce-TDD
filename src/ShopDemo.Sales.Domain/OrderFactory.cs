using System;

namespace ShopDemo.Sales.Domain
{
    public partial class Order
    {
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
