using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Course.Shared.Utilities.Messages;
using MassTransit;
using Services.Order.Domain.OrderAggregate;
using Services.Order.Infrastructure;

namespace Services.Order.Application.Consumers
{
    public class CreateOrderMessageCommandConsumer:IConsumer<CreateOrderMessageCommand>
    {
        private readonly OrderDbContext _orderDbContext;

        public CreateOrderMessageCommandConsumer(OrderDbContext orderDbContext)
        {
            _orderDbContext = orderDbContext;
        }

        public async Task Consume(ConsumeContext<CreateOrderMessageCommand> context)
        {
            var newAddress = new Address(context.Message.Province, context.Message.District, context.Message.Street,
                context.Message.Line, context.Message.ZipCode);
            Domain.OrderAggregate.Order order = new Domain.OrderAggregate.Order(context.Message.BuyerId, newAddress);
            context.Message.OrderItems.ForEach(x =>
            {
                order.AddOrderItem(x.ProductId,x.ProductName,x.Price,x.PictureUrl);
            });
           await _orderDbContext.Orders.AddAsync(order);
           await _orderDbContext.SaveChangesAsync();
        }
    }
}
