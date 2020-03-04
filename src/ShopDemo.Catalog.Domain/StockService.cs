using MediatR;
using ShopDemo.Core.DomainObjects;
using System;
using System.Threading.Tasks;

namespace ShopDemo.Catalog.Domain
{
    public class StockService : IStockService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMediator _mediator;

        public StockService(IProductRepository productRepository, IMediator mediator)
        {
            _productRepository = productRepository;
            _mediator = mediator;
        }

        public async Task<bool> ReplanishOnStock(Guid productId, int quantity)
        {
            var success = await ReplanisItemhOnStock(productId, quantity);

            if (!success) return false;

            return await _productRepository.UnitOfWork.Commit();
        }

        private async Task<bool> ReplanisItemhOnStock(Guid productId, int quantity)
        {
            var product = await _productRepository.GetProductById(productId);

            if (product == null) return false;

            if (!product.HasOnStock(quantity))
            {
                await _mediator.Publish(new DomainNotification("Stock", $"Product - {product.Name} out of stock"));
                return false;
            }

            product.RemoveStockItem(quantity);
            _productRepository.UpdateProduct(product);
            return true;
        }

        public Task<bool> RemoveFromStock(Guid productId, int quantity)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
