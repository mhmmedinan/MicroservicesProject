using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Course.Shared.Utilities.Dtos;
using Services.Catalog.Dtos;
using Services.Catalog.Models;

namespace Services.Catalog.Services.Interfaces
{
    public interface ICategoryService
    {
        Response<List<CategoryDto>> GetAll();
        Response<CategoryDto> GetById(string id);
        Response<CategoryDto> Create(CategoryDto categoryDto);

    }
}
