using ShopDemo.Catalog.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShopDemo.Catalog.Application.Services
{
    public interface IProductAppService
    {
        Task<IEnumerable<ProductViewModel>> GetProductByCategory(int code);
        Task<ProductViewModel> GetProductById(Guid id);
        Task<IEnumerable<ProductViewModel>> GetAllProducts();
        Task<IEnumerable<CategoryViewModel>> GetAllCategories();

        Task AddProduct(ProductViewModel productViewModel);
        Task UpdateProduct(ProductViewModel productViewModel);

        Task<ProductViewModel> RemoveFromStock(Guid id, int quantity);
        Task<ProductViewModel> ReplanishOnStock(Guid id, int quantity);
    }
}
