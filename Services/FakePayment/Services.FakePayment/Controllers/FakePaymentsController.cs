using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.FakePayment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FakePaymentsController : ControllerBase
    {
        [HttpPost]
        public IActionResult ReceivePayment()
        {
            var result = true;
            if (result)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}
