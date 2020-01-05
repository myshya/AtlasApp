namespace AtlasApp.Domain.Abstract
{
    public interface IDatabaseSettings
    {
        string ConnectionString { get; set; }
        string Database { get; set; }
    }
}