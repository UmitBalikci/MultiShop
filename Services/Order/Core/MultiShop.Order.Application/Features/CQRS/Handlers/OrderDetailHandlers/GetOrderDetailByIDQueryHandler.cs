using MultiShop.Order.Application.Features.CQRS.Queries.OrderDetailQueries;
using MultiShop.Order.Application.Features.CQRS.Results.OrderDetailResults;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers
{
    public class GetOrderDetailByIDQueryHandler
    {
        private readonly IRepository<OrderDetail> _repository;

        public GetOrderDetailByIDQueryHandler(IRepository<OrderDetail> repository)
        {
            _repository = repository;
        }

        public async Task<GetOrderDetailByIDQueryResult> Handle(GetOrderDetailByIDQuery query)
        {
            var value = await _repository.GetByIDAsync(query.OrderDetailID);

            return new GetOrderDetailByIDQueryResult
            {
                OrderDetailID = query.OrderDetailID,
                OrderingID = value.OrderingID,
                ProductID = value.ProductID,
                ProductName = value.ProductName,
                ProductPrice = value.ProductPrice,
                ProductAmount = value.ProductAmount,
                ProductTotalPrice = value.ProductTotalPrice,
            };
        }
    }
}
