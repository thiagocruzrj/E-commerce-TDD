using ShopDemo.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopDemo.Sales.Domain
{
    public interface IOrderRepository : IRepository<Order>
    {
        void Add(Order order);
    }
}
