using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace WizardStockFinder.DataAccess.DataContext
{
    public class WizardStockFinderDbContext
    {
        private readonly IMongoDatabase _db;

        public WizardStockFinderDbContext(IConfiguration configuration)
        {
            string? connectionString = configuration.GetConnectionString("WizardStockFinderConnection");
            var databaseName = MongoUrl.Create(connectionString).DatabaseName;

            var client = new MongoClient(connectionString);

            _db = client.GetDatabase(databaseName);
        }


        public IMongoCollection<T> GetCollection<T>(string collectionName)
        {
            return _db.GetCollection<T>(collectionName);
        }


    }
}
