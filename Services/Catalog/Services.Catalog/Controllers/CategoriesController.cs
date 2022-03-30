using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Services.Catalog.Dtos;
using Services.Catalog.Services.Interfaces;

namespace Services.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result =  _categoryService.GetAll();

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);

        }


        [HttpGet("getbyid")]
        public IActionResult GetById(string id)
        {
            var result =  _categoryService.GetById(id);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);

        }


        [HttpPost]
        public  IActionResult Create(CategoryDto categoryDto)
        {
            var result =  _categoryService.Create(categoryDto);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);

        }

    }
}
