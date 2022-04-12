using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Course.Shared.Utilities.Dtos;
using Services.Catalog.Dtos;
using Services.Catalog.Models;

namespace Services.Catalog.Services.Interfaces
{
    public interface ICourseService
    {
        Response<List<CourseDto>> GetAll();
        Response<CourseDto> GetById(string id);
        Response<List<CourseDto>> GetAllByUserId(string userId);
        Response<CourseDto> Create(CourseCreateDto courseCreateDto);
        Response<NoContent> Update(CourseUpdatedDto courseUpdatedDto);
        Response<NoContent> Delete(string id);
    }
}
