using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Services.Catalog.Repositories.Interfaces;
using Services.Catalog.Settings;

namespace Services.Catalog.Repositories
{
    public class CourseRepository:MongoRepositoryBase<Models.Course>,ICourseRepository
    {
        public CourseRepository(IOptions<DatabaseSettings> options) : base(options)
        {
           
        }
    }
}
