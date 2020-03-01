using Microsoft.EntityFrameworkCore;
using ShopDemo.Core.Data;
using ShopDemo.Sales.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
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
            _context.OrderItems.Add(orderItem);
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task<OrderItem> GetItemByOrder(Guid orderId, Guid productId)
        {
            return await _context.OrderItems.FirstOrDefaultAsync(p => p.Id == productId && p.Id == orderId);
        }

        public async Task<IEnumerable<Order>> GetListByClientId(Guid clientId)
        {
            return await _context.Orders.AsNoTracking().Where(p => p.ClientId == clientId).ToListAsync();
        }

        public async Task<Order> GetOrderDraftByClientId(Guid clientId)
        {
            var order = await _context.Orders.FirstOrDefaultAsync(p => p.ClientId == clientId && p.OrderStatus == OrderStatus.Draft);
            if (order == null) return null;

            await _context.Entry(order).Collection(i => i.OrderItems).LoadAsync();

            if(order.VoucherId != null)
            {
                await _context.Entry(order).Reference(i => i.Voucher).LoadAsync();
            }
            return order;
        }

        public async Task<Voucher> GetVoucherByCode(string code)
        {
            return await _context.Vouchers.FirstOrDefaultAsync(p => p.Code == code);
        }

        public void RemoveItem(OrderItem orderItem)
        {
            _context.OrderItems.Remove(orderItem);
        }

        public void Update(Order order)
        {
            _context.Orders.Update(order);
        }

        public void UpdateItem(OrderItem orderItem)
        {
            _context.OrderItems.Update(orderItem);
        }
    }
}
