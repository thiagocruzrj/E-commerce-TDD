using ShopDemo.Catalog.Domain.Entities;
using ShopDemo.Core.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShopDemo.Catalog.Domain
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<IEnumerable<Product>> GetAllProducts();
        Task<Product> GetProductById(Guid id);
        Task<IEnumerable<Product>> GetProductByCategoryCode(int code);
        Task<IEnumerable<Category>> GetAllCategories();

        void AddProduct(Product product);
        void UpdateProduct(Product product);
        void AddCategory(Category category);
        void UpdateCategory(Category category);
    }
}
