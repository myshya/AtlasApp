using AtlasApp.Domain.Abstract;
using AtlasApp.Domain.Entities;
using AtlasApp.Domain.Model;
using MongoDB.Driver;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace AtlasApp.Domain
{
    public class AtlasAppContext
    {
        private readonly IMongoDatabase _mongoDb;

        public AtlasAppContext(IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            _mongoDb = client.GetDatabase(databaseSettings.Database);
        }

        public IMongoCollection<T> DbSet<T>() where T : BaseModel
        {
            var tableName = GetTableName<T>();
            return _mongoDb.GetCollection<T>(tableName);
        }

        public string GetTableName<T>()
        {
            var attr = typeof(T).GetCustomAttributes(typeof(TableAttribute), true).FirstOrDefault() as TableAttribute;
            return attr?.Name;
        }
    }
}