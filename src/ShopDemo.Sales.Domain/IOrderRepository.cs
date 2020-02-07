using System;
using System.Collections.Generic;
using System.Text;

namespace ShopDemo.Sales.Domain
{
    public interface IOrderRepository
    {
        void Add(Order order);
    }
}
