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
        Task<Response<List<CourseDto>>> GetAllAsync();

        Task<Response<CourseDto>> GetByIdAsync(string id);

        Task<Response<List<CourseDto>>> GetAllByUserIdAsync(string userId);

        Task<Response<CourseDto>> CreateAsync(CourseCreateDto courseCreateDto);

        Task<Response<NoContent>> UpdateAsync(CourseUpdatedDto courseUpdateDto);

        Task<Response<NoContent>> DeleteAsync(string id);
    }
}
