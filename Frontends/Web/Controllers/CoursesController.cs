using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Course.Shared.Utilities.Services;
using Microsoft.AspNetCore.Authorization;
using Web.Services.Interfaces;

namespace Web.Controllers
{
    [Authorize]
    public class CoursesController : Controller
    {
        private readonly ICatalogService _catalogService;
        private readonly ISharedIdentityService _sharedIdentityService;

        public CoursesController(ICatalogService catalogService, ISharedIdentityService sharedIdentityService)
        {
            _catalogService = catalogService;
            _sharedIdentityService = sharedIdentityService;
        }

        public async Task<IActionResult> Index()
        {
            return View(_catalogService.GetAllCourseByUserIdAsync(_sharedIdentityService.GetUserId));
        }
    }
}
