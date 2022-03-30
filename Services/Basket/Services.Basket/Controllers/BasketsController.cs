using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Course.Shared.Utilities.Services;
using Services.Basket.Dtos;
using Services.Basket.Services;

namespace Services.Basket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketsController : ControllerBase
    {
        private readonly IBasketService _basketService;
        private readonly ISharedIdentityService _sharedIdentityService;

        public BasketsController(IBasketService basketService, ISharedIdentityService sharedIdentityService)
        {
            _basketService = basketService;
            _sharedIdentityService = sharedIdentityService;
        }

        [HttpGet]
        public IActionResult GetBasket()
        {
            var claims = User.Claims;
            var result = _basketService.GetBasket(_sharedIdentityService.GetUserId);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost]
        public IActionResult SaveOrUpdate(BasketDto basketDto)
        {
            var result = _basketService.SaveOrUpdate(basketDto);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpDelete]
        public IActionResult Delete(BasketDto basketDto)
        {
            var result = _basketService.Delete(_sharedIdentityService.GetUserId);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }



    }
}
