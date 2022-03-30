using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Course.Core.Utilities.Results;
using MediatR;
using Services.Order.Application.Dtos;

namespace Services.Order.Application.Commands
{
    public class CreateOrderCommand:IRequest<IDataResult<CreatedOrderDto>>
    {
        public string BuyerId { get; set; }
        public List<OrderItemDto> OrderItemDtos { get; set; }
        public AddressDto Address { get; set; }
    }
}
