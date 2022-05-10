using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Course.Shared.Utilities.Messages;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using Services.Order.Infrastructure;

namespace Services.Order.Application.Consumers
{
    public class CourseNameChangedEventConsumer:IConsumer<CourseNameChangeEvent>
    {
        private readonly OrderDbContext _orderDbContext;

        public CourseNameChangedEventConsumer(OrderDbContext orderDbContext)
        {
            _orderDbContext = orderDbContext;
        }

        public async Task Consume(ConsumeContext<CourseNameChangeEvent> context)
        {
            var orderItems = await _orderDbContext.OrderItems.Where(x => x.ProductId == context.Message.CourseId)
                .ToListAsync();
            orderItems.ForEach(x =>
            {
                x.UpdateOrderItem(context.Message.UpdatedName,x.PictureUrl,x.Price);
            });
            await _orderDbContext.SaveChangesAsync();
        }
    }
}
