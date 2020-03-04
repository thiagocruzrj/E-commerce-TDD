using System;
using System.Threading.Tasks;

namespace ShopDemo.Catalog.Domain
{
    public interface IStockService : IDisposable
    {
        Task<bool> RemoveItemFromStock(Guid productId, int quantity);
        Task<bool> ReplanishItemOnStock(Guid productId, int quantity);
    }
}
