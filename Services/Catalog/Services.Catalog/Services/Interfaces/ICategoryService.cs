using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Course.Core.Utilities.Results;
using Services.Catalog.Dtos;
using Services.Catalog.Models;

namespace Services.Catalog.Services.Interfaces
{
    public interface ICategoryService
    {
        IDataResult<List<CategoryDto>> GetAll();
        IDataResult<CategoryDto> GetById(string id);
        IDataResult<CategoryDto> Create(CategoryDto categoryDto);

    }
}
