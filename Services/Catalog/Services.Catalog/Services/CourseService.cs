using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using AutoMapper;
using Course.Core.Utilities.Results;
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
        public IDataResult<List<CourseDto>> GetAll()
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
            return new SuccessDataResult<List<CourseDto>>(_mapper.Map<List<CourseDto>>(courses), "Kurslar listelendi");
        }

        public IDataResult<CourseDto> GetById(string id)
        {
            var courses = _courseRepository.GetById(x => x.Id == id);
            if (courses == null)
            {
                return new ErrorDataResult<CourseDto>("kurs bulunamadı");
            }
            courses.Category = _categoryRepository.GetById(c => c.Id == courses.CategoryId);
            return new SuccessDataResult<CourseDto>(_mapper.Map<CourseDto>(courses));
        }

        public IDataResult<List<CourseDto>> GetAllByUserId(string userId)
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
            return new SuccessDataResult<List<CourseDto>>(_mapper.Map<List<CourseDto>>(courses), "Kurslar listelendi");
        }

        public IDataResult<CourseDto> Create(CourseCreateDto courseCreateDto)
        {
            var newCourse = _mapper.Map<Models.Course>(courseCreateDto);
            newCourse.CreatedTime = DateTime.Now;
            _courseRepository.Create(newCourse);
            return new SuccessDataResult<CourseDto>(_mapper.Map<CourseDto>(newCourse), "Eklendi");

        }

        public IResult Update(CourseUpdatedDto courseUpdatedDto)
        {
            var updateCourse = _mapper.Map<Models.Course>(courseUpdatedDto);
            var result = _courseRepository.FindOneAndReplace(x => x.Id == courseUpdatedDto.Id, updateCourse);

            if (result == null)
            {
                return new ErrorResult("Kurs güncellenemedi");
            }

            return new SuccessResult("Kurs Güncellendi");
        }

        public IResult Delete(string id)
        {
            _courseRepository.Delete(x => x.Id == id);
            return new SuccessResult("Silindi");
        }
    }
}
