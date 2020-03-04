using System;
using System.Threading.Tasks;

namespace ShopDemo.Catalog.Domain
{
    public interface IStockService : IDisposable
    {
        Task<bool> RemoveFromStock(Guid productId, int quantity);
        Task<bool> ReplanishOnStock(Guid productId, int quantity);
    }
}
