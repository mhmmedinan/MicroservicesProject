using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Course.Shared.Utilities.ControllerBases;
using Services.Catalog.Dtos;
using Services.Catalog.Services.Interfaces;

namespace Services.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : CustomBaseController
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await  _categoryService.GetAllAsync();

            return CreateActionResultInstance(result);

        }


        [HttpGet("getbyid")]
        public async Task<IActionResult> GetById(string id)
        {
            var result = await _categoryService.GetByIdAsync(id);
            return CreateActionResultInstance(result);

        }


        [HttpPost]
        public async Task<IActionResult> Create(CategoryDto categoryDto)
        {
            var result = await  _categoryService.CreateAsync(categoryDto);

            return CreateActionResultInstance(result);

        }

    }
}
