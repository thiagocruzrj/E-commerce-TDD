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

        public async Task<ProductViewModel> GetProductById(Guid id)
        {
            return _mapper.Map<ProductViewModel>(await _productRepository.GetProductById(id));
        }

        public Task<IEnumerable<CategoryViewModel>> GetAllCategories()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ProductViewModel>> GetAllProducts()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ProductViewModel>> GetProductByCategory(int code)
        {
            return _mapper.Map<IEnumerable<ProductViewModel>>(await _productRepository.GetProductByCategoryCode(code));
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
