using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Services.Catalog.Models;
using Services.Catalog.Repositories.Interfaces;
using Services.Catalog.Settings;

namespace Services.Catalog.Repositories
{
    public class CategoryRepository:MongoRepositoryBase<Category>,ICategoryRepository
    {
        public CategoryRepository(IOptions<DatabaseSettings> options) : base(options)
        {
            
        }
    }
}
