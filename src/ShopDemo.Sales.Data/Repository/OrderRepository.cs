﻿using Microsoft.EntityFrameworkCore;
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
            return await _context.Orders.AsNoTracking().Where(p => p.Id == clientId).ToListAsync();
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
