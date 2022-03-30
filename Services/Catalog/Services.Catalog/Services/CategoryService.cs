using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Course.Core.Utilities.Results;
using MongoDB.Driver;
using Services.Catalog.Dtos;
using Services.Catalog.Models;
using Services.Catalog.Repositories.Interfaces;
using Services.Catalog.Services.Interfaces;


namespace Services.Catalog.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(IMapper mapper, ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;

        }

        public IDataResult<List<CategoryDto>> GetAll()
        {
            var categories = _categoryRepository.GetAll();

            return new SuccessDataResult<List<CategoryDto>>(_mapper.Map<List<CategoryDto>>(categories), "Listelendi");
        }

        public IDataResult<CategoryDto> GetById(string id)
        {
            var category = _categoryRepository.GetById(x => x.Id == id);
            if (category == null)
            {
                return new ErrorDataResult<CategoryDto>("Kategori bulunamadı");
            }
            return new SuccessDataResult<CategoryDto>(_mapper.Map<CategoryDto>(category), "Id'ye göre listelendi");
        }

        public IDataResult<CategoryDto> Create(CategoryDto categoryDto)
        {
            var category = _mapper.Map<Category>(categoryDto);
            _categoryRepository.Create(category);
            return new SuccessDataResult<CategoryDto>(_mapper.Map<CategoryDto>(categoryDto), "Eklendi");
        }
    }
}
