using MediatR;
using MultiShop.Order.Application.Features.Mediator.Queries.OrderingQueries;
using MultiShop.Order.Application.Features.Mediator.Results.OrderingResults;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Application.Features.Mediator.Handlers.OrderingHandlers
{
    public class GetOrderingByIDQueryHandler : IRequestHandler<GetOrderingByIDQuery, GetOrderingByIDQueryResult>
    {
        private readonly IRepository<Ordering> _repository;

        public GetOrderingByIDQueryHandler(IRepository<Ordering> repository)
        {
            _repository = repository;
        }

        public async Task<GetOrderingByIDQueryResult> Handle(GetOrderingByIDQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIDAsync(request.OrderingID);

            return new GetOrderingByIDQueryResult
            {
                OrderingID = value.OrderingID,
                OrderDate = value.OrderDate,
                TotalPrice = value.TotalPrice,
                UserID = value.UserID
            };
        }
    }
}
