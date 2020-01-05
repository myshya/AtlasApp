using AtlasApp.Domain.Abstract;

namespace AtlasApp.Domain.Model
{
    public class DatabaseSettings : IDatabaseSettings
    {
        public string ConnectionString { get; set; }
        public string Database { get; set; }
    }
}