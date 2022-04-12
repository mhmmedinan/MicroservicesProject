using System;
using System.Collections.Generic;
using System.Text;
using Course.Shared.Utilities.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Course.Shared.Utilities.ControllerBases
{
    public class CustomBaseController : ControllerBase
    {
        public IActionResult CreateActionResultInstance<T>(Response<T> response)
        {
            return new ObjectResult(response)
            {
                StatusCode = response.StatusCode
            };
        }
    }
}
