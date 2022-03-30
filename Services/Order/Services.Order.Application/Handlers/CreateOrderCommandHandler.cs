using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Course.Core.Utilities.Results;
using MediatR;
using Services.Order.Application.Commands;
using Services.Order.Application.Dtos;
using Services.Order.Domain.OrderAggregate;
using Services.Order.Infrastructure;

namespace Services.Order.Application.Handlers
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, IDataResult<CreatedOrderDto>>
    {
        private readonly OrderDbContext _orderDbContext;

        public CreateOrderCommandHandler(OrderDbContext orderDbContext)
        {
            _orderDbContext = orderDbContext;
        }
        public async Task<IDataResult<CreatedOrderDto>> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var newAddress = new Address(request.Address.Province, request.Address.District,
                request.Address.Street, request.Address.ZipCode, request
                    .Address.Line);
            Domain.OrderAggregate.Order newOrder = new Domain.OrderAggregate.Order(request.BuyerId,newAddress);
            request.OrderItemDtos.ForEach(x =>
            {
                newOrder.AddOrderItem(x.ProductId,x.ProductName,x.Price,x.PictureUrl);
            });

            await _orderDbContext.Orders.AddAsync(newOrder);
            await _orderDbContext.SaveChangesAsync();
            return new SuccessDataResult<CreatedOrderDto>(new CreatedOrderDto {OrderId = newOrder.Id});

        }
    }
}
