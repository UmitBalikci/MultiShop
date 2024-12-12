using MultiShop.Order.Application.Features.CQRS.Results.OrderDetailResults;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers
{
    public class GetOrderDetailQueryHandler
    {
        private readonly IRepository<OrderDetail> _repository;

        public GetOrderDetailQueryHandler(IRepository<OrderDetail> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetOrderDetailQueryResult>> Hadndle()
        {
            var values = await _repository.GetAllAsync();

            return values.Select(x => new GetOrderDetailQueryResult
            {
                OrderDetailID = x.OrderDetailID,
                ProductAmount = x.ProductAmount,
                ProductName = x.ProductName,
                ProductID = x.ProductID,
                ProductPrice = x.ProductPrice,
                ProductTotalPrice = x.ProductTotalPrice,
                OrderingID = x.OrderingID,
            }).ToList();
        }
    }
}
