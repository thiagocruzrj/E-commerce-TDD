using ShopDemo.Core.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShopDemo.Sales.Domain
{
    public interface IOrderRepository : IRepository<Order>
    {
        Task<IEnumerable<Order>> GetListByClientId(Guid clientId);
        Task<Order> GetOrderDraftByClientId(Guid clientId);
        void Add(Order order);
        void Update(Order order);

        Task<OrderItem> GetItemByOrder(Guid orderId, Guid productId);
        void AddItem(OrderItem orderItem);
        void UpdateItem(OrderItem orderItem);
        void RemoveItem(OrderItem orderItem);

        Task<Voucher> GetVoucherByCode(string code);
    }
}
