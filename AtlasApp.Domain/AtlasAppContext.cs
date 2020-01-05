using System.ComponentModel.DataAnnotations.Schema;
using AtlasApp.Domain.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AtlasApp.Domain
{
    public class AtlasAppContext
    {
        private readonly IMongoDatabase _mongoDb;
        public AtlasAppContext()
        {
            var client = new MongoClient("mongodb+srv://OmniApp:<password>@omni-oedlw.azure.mongodb.net/test?retryWrites=true&w=majority");
            _mongoDb = client.GetDatabase("AtlasApp");
        }
        public IMongoCollection<T> DbSet<T>() where T: BaseModel 
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
