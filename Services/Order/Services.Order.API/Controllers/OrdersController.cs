using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Course.Shared.Utilities.ControllerBases;
using Course.Shared.Utilities.Dtos;
using Course.Shared.Utilities.Services;
using MediatR;
using Services.Order.Application.Commands;
using Services.Order.Application.Queries;

namespace Services.Order.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : CustomBaseController
    {
        private readonly IMediator _mediator;
        private readonly ISharedIdentityService _sharedIdentityService;

        public OrdersController(IMediator mediator, ISharedIdentityService sharedIdentityService)
        {
            _mediator = mediator;
            _sharedIdentityService = sharedIdentityService;
        }

        [HttpGet]
        public async Task<IActionResult> GetOrders()
        {
            var result = await _mediator.Send(new GetOrdersByUserIdQuery {UserId = _sharedIdentityService.GetUserId});
            return CreateActionResultInstance(result);
        }

        [HttpPost]
        public async Task<IActionResult> SaveOrder(CreateOrderCommand createOrderCommand)
        {
            
            var result = await _mediator.Send(createOrderCommand);
            return CreateActionResultInstance(result);
        }

    }
}
