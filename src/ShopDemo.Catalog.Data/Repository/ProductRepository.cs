using ShopDemo.Catalog.Domain;
using ShopDemo.Catalog.Domain.Entities;
using ShopDemo.Core.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShopDemo.Catalog.Data.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly CatalogContext _context;

        public ProductRepository(CatalogContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;

        public Task<IEnumerable<Category>> GetAllCategories()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Product>> GetAllProducts()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Product>> GetProductByCategoryCode(int code)
        {
            throw new NotImplementedException();
        }

        public Task<Product> GetProductById(Guid id)
        {
            throw new NotImplementedException();
        }

        public void AddCategory(Category category)
        {
            throw new NotImplementedException();
        }

        public void AddProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public void UpdateCategory(Category category)
        {
            throw new NotImplementedException();
        }

        public void UpdateProduct(Product product)
        {
            throw new NotImplementedException();
        }


        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
