using ShopDemo.Core.Data;
using System;
using System.Threading.Tasks;

namespace ShopDemo.Sales.Domain
{
    public interface IOrderRepository : IRepository<Order>
    {
        void Add(Order order);
        void Update(Order order);
        Task<Order> GetDraftByClientId(Guid clientId);
        void AddItem(OrderItem orderItem);
    }
}
