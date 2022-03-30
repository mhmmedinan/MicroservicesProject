using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace Services.Catalog.Repositories.Interfaces
{
    public interface IEntityRepository<T> where T : class, new()
    {
        List<T> GetAll(Expression<Func<T, bool>> filter = null);
        T GetById(Expression<Func<T, bool>> filter);
        void Create(T model);
        T FindOneAndReplace(Expression<Func<T, bool>> filter, T model);
        void Delete(Expression<Func<T, bool>> filter);

    }
}
