using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Course.Core.Utilities.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Services.Order.Application.Dtos;
using Services.Order.Application.Mapping;
using Services.Order.Application.Queries;
using Services.Order.Infrastructure;

namespace Services.Order.Application.Handlers
{
    public class GetOrdersByUserIdQueryHandler : IRequestHandler<GetOrdersByUserIdQuery, IDataResult<List<OrderDto>>>
    {
        private readonly OrderDbContext _orderDbContext;

        public GetOrdersByUserIdQueryHandler(OrderDbContext orderDbContext)
        {
            _orderDbContext = orderDbContext;
        }
        public async Task<IDataResult<List<OrderDto>>> Handle(GetOrdersByUserIdQuery request, CancellationToken cancellationToken)
        {
            var orders = await _orderDbContext.Orders.Include(x => x.OrderItems).Where(x => x.BuyerId == request.UserId)
                .ToListAsync();
            if (!orders.Any())
            {
                return new SuccessDataResult<List<OrderDto>>(new List<OrderDto>());     

            }

            var ordersDto = ObjectMapper.Mapper.Map<List<OrderDto>>(orders);
            return new SuccessDataResult<List<OrderDto>>(ordersDto);
        }
    }
}
