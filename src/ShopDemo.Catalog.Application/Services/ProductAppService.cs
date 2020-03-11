using AutoMapper;
using ShopDemo.Catalog.Application.ViewModels;
using ShopDemo.Catalog.Domain;
using ShopDemo.Catalog.Domain.Entities;
using ShopDemo.Core.DomainObjects;
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

        public async Task<IEnumerable<CategoryViewModel>> GetAllCategories()
        {
            return _mapper.Map<IEnumerable<CategoryViewModel>>(await _productRepository.GetAllCategories());
        }

        public async Task<IEnumerable<ProductViewModel>> GetAllProducts()
        {
            return _mapper.Map<IEnumerable<ProductViewModel>>(await _productRepository.GetAllProducts());
        }

        public async Task<IEnumerable<ProductViewModel>> GetProductByCategory(int code)
        {
            return _mapper.Map<IEnumerable<ProductViewModel>>(await _productRepository.GetProductByCategoryCode(code));
        }

        public async Task AddProduct(ProductViewModel productViewModel)
        {
            var product = _mapper.Map<Product>(productViewModel);
            _productRepository.AddProduct(product);

            await _productRepository.UnitOfWork.Commit();
        }

        public async Task UpdateProduct(ProductViewModel productViewModel)
        {
            var product = _mapper.Map<Product>(productViewModel);
            _productRepository.UpdateProduct(product);

            await _productRepository.UnitOfWork.Commit();
        }

        public async Task<ProductViewModel> RemoveFromStock(Guid id, int quantity)
        {
            if (!_stockService.RemoveFromStock(id, quantity).Result)
                throw new DomainException("Fail to remove product from stock");

            return _mapper.Map<ProductViewModel>(await _productRepository.GetProductById(id));
        }

        public Task<ProductViewModel> ReplanishOnStock(Guid id, int quantity)
        {
            throw new NotImplementedException();
        }
    }
}
