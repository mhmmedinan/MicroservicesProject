using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using Services.Catalog.Models;
using Services.Catalog.Repositories.Interfaces;
using Services.Catalog.Settings;

namespace Services.Catalog.Repositories
{
    public class MongoRepositoryBase<TModel> : IEntityRepository<TModel>
        where TModel : class, new()
    {
        private readonly IMongoCollection<TModel> _mongoCollection;
        private readonly DatabaseSettings databaseSettings;

        public MongoRepositoryBase(IOptions<DatabaseSettings> options)
        {
            this.databaseSettings = options.Value;
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.Database);

            _mongoCollection = database.GetCollection<TModel>(typeof(TModel).Name.ToLowerInvariant());
        }


        public List<TModel>  GetAll(Expression<Func<TModel, bool>> filter = null)
        {
            return _mongoCollection.Find(filter => true).ToList();
        }

        public TModel GetById(Expression<Func<TModel, bool>> filter)
        {

            return  _mongoCollection.Find<TModel>(filter).FirstOrDefault();
        }


        public void Create(TModel model)
        {
           _mongoCollection.InsertOne(model);
           
        }

        public TModel FindOneAndReplace(Expression<Func<TModel, bool>> filter, TModel model)
        {
    
           return  _mongoCollection.FindOneAndReplace(filter=>true, model);
        }

        public void Delete(Expression<Func<TModel, bool>> filter)
        {

            _mongoCollection.DeleteOne(filter=>true);
         
        }
    }
}
