using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using AutoMapper;
using Course.Shared.Utilities.Dtos;
using Services.Catalog.Dtos;
using Services.Catalog.Models;
using Services.Catalog.Repositories.Interfaces;
using Services.Catalog.Services.Interfaces;

namespace Services.Catalog.Services
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CourseService(ICourseRepository courseRepository, ICategoryRepository categoryRepository, IMapper mapper)
        {
            _mapper = mapper;
            _courseRepository = courseRepository;
            _categoryRepository = categoryRepository;

        }
        public Response<List<CourseDto>> GetAll()
        {
            var courses = _courseRepository.GetAll(course => true);
            if (courses.Any())
            {
                foreach (var course in courses)
                {
                    course.Category = _categoryRepository.GetById(c => c.Id == course.CategoryId);
                }
            }
            else
            {
                courses = new List<Models.Course>();
            }
            return Response<List<CourseDto>>.Success(_mapper.Map<List<CourseDto>>(courses), 200);
        }

        public Response<CourseDto> GetById(string id)
        {
            var course = _courseRepository.GetById(x => x.Id == id);
            if (course == null)
            {
                return Response<CourseDto>.Fail("Course not found", 404);
            }
            course.Category = _categoryRepository.GetById(c => c.Id == course.CategoryId);
            return Response<CourseDto>.Success(_mapper.Map<CourseDto>(course), 200);
        }

        public Response<List<CourseDto>> GetAllByUserId(string userId)
        {
            var courses = _courseRepository.GetAll(c => c.UserId == userId);
            if (courses.Any())
            {
                foreach (var course in courses)
                {
                    course.Category = _categoryRepository.GetById(c => c.Id == course.CategoryId);
                }
            }
            else
            {
                courses = new List<Models.Course>();
            }
            return Response<List<CourseDto>>.Success(_mapper.Map<List<CourseDto>>(courses), 200);
        }

        public Response<CourseDto> Create(CourseCreateDto courseCreateDto)
        {
            var newCourse = _mapper.Map<Models.Course>(courseCreateDto);
            newCourse.CreatedTime = DateTime.Now;
            _courseRepository.Create(newCourse);
            return Response<CourseDto>.Success(_mapper.Map<CourseDto>(newCourse), 200);

        }

        public Response<NoContent> Update(CourseUpdatedDto courseUpdatedDto)
        {
            var updateCourse = _mapper.Map<Models.Course>(courseUpdatedDto);
            var result = _courseRepository.FindOneAndReplace(x => x.Id == courseUpdatedDto.Id, updateCourse);

            if (result == null)
            {
                return Response<NoContent>.Fail("Course not found", 404);
            }

            return Response<NoContent>.Success(204);
        }

        public Response<NoContent> Delete(string id)
        {
            _courseRepository.Delete(x => x.Id == id);
            return Response<NoContent>.Success(204);
        }
    }
}
