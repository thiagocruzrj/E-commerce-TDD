using ShopDemo.Core.Data;
using ShopDemo.Sales.Domain;
using System;
using System.Threading.Tasks;

namespace ShopDemo.Catalog.Data.Repository
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
            throw new NotImplementedException();
        }

        public void AddItem(OrderItem orderItem)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task<Order> GetDraftByClientId(Guid clientId)
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
