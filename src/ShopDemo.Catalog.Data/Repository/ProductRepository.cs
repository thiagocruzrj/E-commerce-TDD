using Microsoft.EntityFrameworkCore;
using ShopDemo.Catalog.Domain;
using ShopDemo.Catalog.Domain.Entities;
using ShopDemo.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<IEnumerable<Category>> GetAllCategories()
        {
            return await _context.Categories.AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            return await _context.Products.AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProductByCategoryCode(int code)
        {
            return await _context.Products.AsNoTracking().Include(p => p.Category).Where(c => c.Category.Code == code).ToListAsync();
        }

        public async Task<Product> GetProductById(Guid id)
        {
            return await _context.Products.FindAsync(id);
        }

        public void AddCategory(Category category)
        {
            _context.Categories.Add(category);
        }

        public void AddProduct(Product product)
        {
            _context.Products.Add(product);
        }

        public void UpdateCategory(Category category)
        {
            _context.Categories.Update(category);
        }

        public void UpdateProduct(Product product)
        {
            _context.Products.Update(product);
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
