using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Course.Shared.Utilities.Services;
using Services.Discount.Services;

namespace Services.Discount.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountsController : ControllerBase
    {
        private readonly IDiscountService _discountService;
        private readonly ISharedIdentityService _sharedIdentityService;

        public DiscountsController(IDiscountService discountService,ISharedIdentityService sharedIdentityService)
        {
            _sharedIdentityService = sharedIdentityService;
            _discountService = discountService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _discountService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }


        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var result = _discountService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet]
        [Route("/api/[controller]/[action]/{code}")]
        public IActionResult GetByCode(string code)
        {
            var userId = _sharedIdentityService.GetUserId;
            var result = _discountService.GetByCodeAndUserId(code, userId);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }



        [HttpPost]
        public IActionResult Save(Models.Discount discount)
        {
            var result = _discountService.Save(discount);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPut]
        public IActionResult Update(Models.Discount discount)
        {
            var result = _discountService.Update(discount);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _discountService.Delete(id);
            if (result.Success)
            { 
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}
