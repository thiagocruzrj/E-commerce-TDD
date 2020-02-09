using System.Threading.Tasks;

namespace ShopDemo.Core.Data
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}
