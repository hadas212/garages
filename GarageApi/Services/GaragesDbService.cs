using GarageApi.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using GarageApi.Data;

namespace GarageApi.Services
{
    public class GaragesDbService
    {
        private readonly IMongoCollection<Garage> _garages;

        public GaragesDbService(IOptions<MongoDbSettings> mongoDbSettings)
        {
            var client = new MongoClient(mongoDbSettings.Value.ConnectionString);
            var database = client.GetDatabase(mongoDbSettings.Value.DatabaseName);
            _garages = database.GetCollection<Garage>(mongoDbSettings.Value.CollectionName);
        }

        public async Task<List<Garage>> GetAsync() =>
            await _garages.Find(_ => true).ToListAsync();

        public async Task CreateAsync(Garage garage) =>
            await _garages.InsertOneAsync(garage);
    }
}
