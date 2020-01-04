using AtlasApp.Domain.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace AtlasApp.Domain
{
    public class AtlasAppContext
    {
        private readonly IMongoDatabase _mongoDb;
        public AtlasAppContext()
        {
            var client = new MongoClient("mongodb+srv://sarathlal:<password>@sarathlal-6k9bj.azure.mongodb.net?retryWrites=true");
            _mongoDb = client.GetDatabase("SarathDB");
        }
        public IMongoCollection<Employee> Employee
        {
            get
            {
                return _mongoDb.GetCollection<Employee>("Employee");
            }
        }
    }
}
