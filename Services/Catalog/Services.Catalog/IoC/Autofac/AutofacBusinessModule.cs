using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Services.Catalog.Repositories;
using Services.Catalog.Repositories.Interfaces;
using Services.Catalog.Services;
using Services.Catalog.Services.Interfaces;

namespace Services.Catalog.IoC.Autofac
{
    public class AutofacBusinessModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CategoryService>().As<ICategoryService>().SingleInstance();
            builder.RegisterType<CategoryRepository>().As<ICategoryRepository>().SingleInstance();

            builder.RegisterType<CourseService>().As<ICourseService>().SingleInstance();
            builder.RegisterType<CourseRepository>().As<ICourseRepository>().SingleInstance();
        }
    }
}
