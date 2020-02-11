using Microsoft.EntityFrameworkCore;
using ShopDemo.Core.Data;
using System;
using System.Threading.Tasks;

namespace ShopDemo.Catalog.Data
{
    public class SalesContext : DbContext, IUnitOfWork
    {
        public Task<bool> Commit()
        {
            throw new NotImplementedException();
        }
    }
}
