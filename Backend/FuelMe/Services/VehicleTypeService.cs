using FuelMe.Helpers;
using FuelMe.Models;
using Microsoft.VisualBasic.FileIO;
using MongoDB.Driver;

namespace FuelMe.Services
{
    public class VehicleTypeService : IVehicleTypeService
    {
        private readonly IMongoCollection<VehicleType> _vehicleTypes;

        public VehicleTypeService(IFuelMeDatabaseHelper settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _vehicleTypes = database.GetCollection<VehicleType>(settings.VehicleTypeCollectionName);
        }
        public VehicleType Create(VehicleType vehicleType)
        {
            _vehicleTypes.InsertOne(vehicleType);
            return vehicleType;
        }

        public List<VehicleType> Get()
        {
            return _vehicleTypes.Find(fuelType => true).ToList();
        }

        public VehicleType Get(string id)
        {
            return _vehicleTypes.Find(fuelType => fuelType.Id == id).FirstOrDefault();
        }

        public void Remove(string id)
        {
            _vehicleTypes.DeleteOne(fuelType => fuelType.Id == id);
        }

        public void Update(string id, VehicleType vehicleType)
        {
            _vehicleTypes.ReplaceOne(type => type.Id == id, vehicleType);
        }
    }
}
