using ShopDemo.Core.Data;
using ShopDemo.Sales.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShopDemo.Sales.Data.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly SalesContext _context;

        public OrderRepository(SalesContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;

        public void Add(Order order)
        {
            _context.Orders.Add(order);
        }

        public void AddItem(OrderItem orderItem)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task<OrderItem> GetItemByOrder(Guid orderId, Guid productId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Order>> GetListByClientId(Guid clientId)
        {
            throw new NotImplementedException();
        }

        public Task<Order> GetOrderDraftByClientId(Guid clientId)
        {
            throw new NotImplementedException();
        }

        public Task<Voucher> GetVoucherByCode(string codigo)
        {
            throw new NotImplementedException();
        }

        public void RemoveItem(OrderItem orderItem)
        {
            throw new NotImplementedException();
        }

        public void Update(Order order)
        {
            throw new NotImplementedException();
        }

        public void UpdateItem(OrderItem orderItem)
        {
            throw new NotImplementedException();
        }
    }
}
