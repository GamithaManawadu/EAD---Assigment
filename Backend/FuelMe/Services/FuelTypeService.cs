using FuelMe.Helpers;
using FuelMe.Models;
using MongoDB.Driver;

namespace FuelMe.Services
{
    public class FuelTypeService : IFuelTypeService
    {
        private readonly IMongoCollection<FuelType> _fuelTypes;

        public FuelTypeService(IFuelMeDatabaseHelper settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _fuelTypes = database.GetCollection<FuelType>(settings.FuelTypeCollectionName);
        }
        public FuelType Create(FuelType fuelType)
        {
            _fuelTypes.InsertOne(fuelType);
            return fuelType;
        }

        public List<FuelType> Get()
        {
            return _fuelTypes.Find(fuelType => true).ToList();
        }

        public FuelType Get(string id)
        {
            return _fuelTypes.Find(fuelType => fuelType.Id == id).FirstOrDefault();
        }

        public void Remove(string id)
        {
            _fuelTypes.DeleteOne(fuelType => fuelType.Id == id);
        }

        public void Update(string id, FuelType fuelType)
        {
            _fuelTypes.ReplaceOne(type => type.Id == id , fuelType);
        }
    }
}
