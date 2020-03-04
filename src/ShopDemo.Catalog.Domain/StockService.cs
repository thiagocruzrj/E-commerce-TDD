using MediatR;
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

        public Task<bool> ReplanishItemOnStock(Guid productId, int quantity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveItemFromStock(Guid productId, int quantity)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
