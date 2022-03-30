using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Services.Catalog.Models;

namespace Services.Catalog.Repositories.Interfaces
{
    public interface ICategoryRepository: IEntityRepository<Category>
    {
    }
}
