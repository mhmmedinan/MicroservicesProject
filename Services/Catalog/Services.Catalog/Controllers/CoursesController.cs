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
    public class CoursesController : CustomBaseController
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
            return CreateActionResultInstance(result);

        }

        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {
            var result = _courseService.GetById(id);
            return CreateActionResultInstance(result);

        }

        [HttpGet]
        [Route("/api/[controller]/GetAllByUserId/{userId}")]
        public IActionResult GetAllByUserId(string userId)
        {
            var result =  _courseService.GetAllByUserId(userId);
            return CreateActionResultInstance(result);

        }


        [HttpPost]
        public  IActionResult Create(CourseCreateDto courseCreateDto)
        {
            var result =  _courseService.Create(courseCreateDto);
            return CreateActionResultInstance(result);
        }



        [HttpPut]
        public IActionResult Update(CourseUpdatedDto courseUpdatedDto)
        {
            var result =  _courseService.Update(courseUpdatedDto);
            return CreateActionResultInstance(result);

        }


        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var result =_courseService.Delete(id);
            return CreateActionResultInstance(result);

        }
    }
}
