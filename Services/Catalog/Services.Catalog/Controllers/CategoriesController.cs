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
        public IActionResult GetAll()
        {
            var result =  _categoryService.GetAll();

            return CreateActionResultInstance(result);

        }


        [HttpGet("getbyid")]
        public IActionResult GetById(string id)
        {
            var result =  _categoryService.GetById(id);
            return CreateActionResultInstance(result);

        }


        [HttpPost]
        public  IActionResult Create(CategoryDto categoryDto)
        {
            var result =  _categoryService.Create(categoryDto);

            return CreateActionResultInstance(result);

        }

    }
}
