using AutoMapper;
using ShopDemo.Catalog.Application.ViewModels;
using ShopDemo.Catalog.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ShopDemo.Catalog.Application.Services
{
    public class ProductAppService : IProductAppService
    {
        private readonly IProductRepository _productRepository;
        private readonly IStockService _stockService;
        private readonly IMapper _mapper;

        public ProductAppService(IProductRepository productRepository, IStockService stockService, IMapper mapper)
        {
            _productRepository = productRepository;
            _stockService = stockService;
            _mapper = mapper;
        }

        public Task<ProductViewModel> GetProductById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CategoryViewModel>> GetAllCategories()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ProductViewModel>> GetAllProducts()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ProductViewModel>> GetProductByCategory(int code)
        {
            throw new NotImplementedException();
        }

        public Task AddProduct(ProductViewModel productViewModel)
        {
            throw new NotImplementedException();
        }

        public Task UpdateProduct(ProductViewModel productViewModel)
        {
            throw new NotImplementedException();
        }

        public Task<ProductViewModel> RemoveFromStock(Guid id, int quantity)
        {
            throw new NotImplementedException();
        }

        public Task<ProductViewModel> ReplanishOnStock(Guid id, int quantity)
        {
            throw new NotImplementedException();
        }
    }
}
