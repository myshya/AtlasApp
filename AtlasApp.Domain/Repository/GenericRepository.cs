using AtlasApp.Domain.Entities;
using AtlasApp.Domain.IRepository;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AtlasApp.Domain.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseModel
    {
        private AtlasAppContext _dbContext;
        public IMongoCollection<T> Collection { get; private set; }

        public GenericRepository(AtlasAppContext dbContext)
        {
            _dbContext = dbContext;
            Collection = _dbContext.DbSet<T>();
        }

        public async Task<T> GetById(string id)
        {
            if (string.IsNullOrWhiteSpace(id)) return null;

            var filterId = Builders<T>.Filter.Eq("Id", id);
            return await Collection.Find(filterId).FirstOrDefaultAsync();
        }

        public async Task Update(T model)
        {
            try
            {
                var filterId = Builders<T>.Filter.Eq("Id", model.Id);
                await Collection.FindOneAndReplaceAsync(filterId, model);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task Create(T model)
        {
            try
            {
                await Collection.InsertOneAsync(model);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task Delete(string id)
        {
            try
            {
                await Collection.DeleteOneAsync(Builders<T>.Filter.Eq("Id", id));
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await Collection.Find(FilterDefinition<T>.Empty).ToListAsync();
        }

        public async Task<IEnumerable<T>> Query(Expression<Func<T, bool>> filter)
        {
            return await Collection.Find(filter).ToListAsync();
        }
    }
}