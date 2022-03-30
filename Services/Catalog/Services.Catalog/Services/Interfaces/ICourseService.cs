using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Course.Core.Utilities.Results;
using Services.Catalog.Dtos;
using Services.Catalog.Models;

namespace Services.Catalog.Services.Interfaces
{
    public interface ICourseService
    {
        IDataResult<List<CourseDto>> GetAll();
        IDataResult<CourseDto> GetById(string id);
        IDataResult<List<CourseDto>> GetAllByUserId(string userId);
        IDataResult<CourseDto> Create(CourseCreateDto courseCreateDto);
        IResult Update(CourseUpdatedDto courseUpdatedDto);
        IResult Delete(string id);
    }
}
