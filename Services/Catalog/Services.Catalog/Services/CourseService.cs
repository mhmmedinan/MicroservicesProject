﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Course.Shared.Utilities.Dtos;
using Course.Shared.Utilities.Messages;
using MassTransit;
using MongoDB.Driver;
using Services.Catalog.Dtos;
using Services.Catalog.Models;
using Services.Catalog.Services.Interfaces;
using Services.Catalog.Settings;


namespace Services.Catalog.Services
{
    public class CourseService : ICourseService
    {
        private readonly IMongoCollection<Models.Course> _courseCollection;
        private readonly IMongoCollection<Category> _categoryCollection;
        private readonly IMapper _mapper;
        private readonly IPublishEndpoint _publishEndpoint;
        

        public CourseService(IMapper mapper, IDatabaseSettings databaseSettings, IPublishEndpoint publishEndpoint)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);

            var database = client.GetDatabase(databaseSettings.DatabaseName);

            _courseCollection = database.GetCollection<Models.Course>(databaseSettings.CourseCollectionName);

            _categoryCollection = database.GetCollection<Category>(databaseSettings.CategoryCollectionName);
            _mapper = mapper;
            _publishEndpoint = publishEndpoint;
        }

        public async Task<Course.Shared.Utilities.Dtos.Response<List<CourseDto>>> GetAllAsync()
        {
            var courses = await _courseCollection.Find(course => true).ToListAsync();

            if (courses.Any())
            {
                foreach (var course in courses)
                {
                    course.Category = await _categoryCollection.Find<Category>(x => x.Id == course.CategoryId).FirstAsync();
                }
            }
            else
            {
                courses = new List<Models.Course>();
            }

            return Course.Shared.Utilities.Dtos.Response<List<CourseDto>>.Success(_mapper.Map<List<CourseDto>>(courses), 200);
        }

        public async Task<Course.Shared.Utilities.Dtos.Response<CourseDto>> GetByIdAsync(string id)
        {
            var course = await _courseCollection.Find<Models.Course>(x => x.Id == id).FirstOrDefaultAsync();

            if (course == null)
            {
                return Course.Shared.Utilities.Dtos.Response<CourseDto>.Fail("Course not found", 404);
            }
            course.Category = await _categoryCollection.Find<Category>(x => x.Id == course.CategoryId).FirstAsync();

            return Course.Shared.Utilities.Dtos.Response<CourseDto>.Success(_mapper.Map<CourseDto>(course), 200);
        }

        public async Task<Course.Shared.Utilities.Dtos.Response<List<CourseDto>>> GetAllByUserIdAsync(string userId)
        {
            var courses = await _courseCollection.Find<Models.Course>(x => x.UserId == userId).ToListAsync();

            if (courses.Any())
            {
                foreach (var course in courses)
                {
                    course.Category = await _categoryCollection.Find<Category>(x => x.Id == course.CategoryId).FirstAsync();
                }
            }
            else
            {
                courses = new List<Models.Course>();
            }

            return Course.Shared.Utilities.Dtos.Response<List<CourseDto>>.Success(_mapper.Map<List<CourseDto>>(courses), 200);
        }

        public async Task<Course.Shared.Utilities.Dtos.Response<CourseDto>> CreateAsync(CourseCreateDto courseCreateDto)
        {
            var newCourse = _mapper.Map<Models.Course>(courseCreateDto);

            newCourse.CreatedTime = DateTime.Now;
            await _courseCollection.InsertOneAsync(newCourse);

            return Course.Shared.Utilities.Dtos.Response<CourseDto>.Success(_mapper.Map<CourseDto>(newCourse), 200);
        }

        public async Task<Course.Shared.Utilities.Dtos.Response<NoContent>> UpdateAsync(CourseUpdatedDto courseUpdateDto)
        {
            var updateCourse = _mapper.Map<Models.Course>(courseUpdateDto);

            var result = await _courseCollection.FindOneAndReplaceAsync(x => x.Id == courseUpdateDto.Id, updateCourse);

            if (result == null)
            {
                return Course.Shared.Utilities.Dtos.Response<NoContent>.Fail("Course not found", 404);
            }

            await _publishEndpoint.Publish<CourseNameChangeEvent>(new CourseNameChangeEvent
                {CourseId = updateCourse.Id, UpdatedName = courseUpdateDto.Name});

            return Course.Shared.Utilities.Dtos.Response<NoContent>.Success(204);
        }

        public async Task<Course.Shared.Utilities.Dtos.Response<NoContent>> DeleteAsync(string id)
        {
            var result = await _courseCollection.DeleteOneAsync(x => x.Id == id);

            if (result.DeletedCount > 0)
            {
                return Course.Shared.Utilities.Dtos.Response<NoContent>.Success(204);
            }
            else
            {
                return Course.Shared.Utilities.Dtos.Response<NoContent>.Fail("Course not found", 404);
            }
        }
    }
}
