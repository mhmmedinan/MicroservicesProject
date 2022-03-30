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
    public class CoursesController : ControllerBase
    {
        private readonly ICourseService _courseService;

        public CoursesController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result =  _courseService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);

        }

        [HttpGet("{getbyid}")]
        public IActionResult GetById(string id)
        {
            var result = _courseService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);

        }

        [HttpGet]
        [Route("/api/[controller]/GetAllByUserId/{userId}")]
        public IActionResult GetAllByUserId(string userId)
        {
            var result =  _courseService.GetAllByUserId(userId);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);

        }


        [HttpPost]
        public  IActionResult Create(CourseCreateDto courseCreateDto)
        {
            var result =  _courseService.Create(courseCreateDto);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);

        }



        [HttpPut]
        public IActionResult Update(CourseUpdatedDto courseUpdatedDto)
        {
            var result =  _courseService.Update(courseUpdatedDto);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);

        }


        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var result =_courseService.Delete(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);

        }
    }
}
