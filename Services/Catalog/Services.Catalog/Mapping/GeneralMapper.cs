using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Services.Catalog.Dtos;
using Services.Catalog.Models;

namespace Services.Catalog.Mapping
{
    public class GeneralMapper:Profile
    {
        public GeneralMapper()
        {
            CreateMap<Models.Course, CourseDto>().ReverseMap();
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Feature, FeatureDto>().ReverseMap();

            CreateMap<Models.Course, CourseCreateDto>().ReverseMap();
            CreateMap<Models.Course, CourseUpdatedDto>().ReverseMap();
        }
    }
}
