using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Course.Core.Utilities.Results;
using MediatR;
using Services.Order.Application.Dtos;

namespace Services.Order.Application.Queries
{
    public class GetOrdersByUserIdQuery:IRequest<IDataResult<List<OrderDto>>>
    {
        public string UserId { get; set; }
    }
}
