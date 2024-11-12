using MongoDB.Driver;
using vetFoodShop.Catalog.Entities;

namespace vetFoodShop.Catalog.Settings
{
    public class MongoDBService
    {
        private readonly IMongoDatabase _database;
        private readonly IDatabaseSettings _settings; // _settings alanını tanımla

        public MongoDBService(IDatabaseSettings _settings)
        {
            var client = new MongoClient(_settings.ConnectionString);
            _database = client.GetDatabase(_settings.DatabaseName);
        }

        public IMongoCollection<Product> GetProductCollection() =>
            _database.GetCollection<Product>(_settings.ProductCollectionName);
    }
}
