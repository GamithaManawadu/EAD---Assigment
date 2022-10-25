using FuelMe.Helpers;
using FuelMe.Models;
using MongoDB.Driver;

namespace FuelMe.Services
{
    public class VehicleQueueService : IVehicleQueueService
    {
        private readonly IMongoCollection<VehicleQueue> _vehicleQueue;

        public VehicleQueueService(IFuelMeDatabaseHelper settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _vehicleQueue = database.GetCollection<VehicleQueue>(settings.VehicleQueueCollectionName);
        }
        public VehicleQueue Create(VehicleQueue vehicleQueue)
        {
            _vehicleQueue.InsertOne(vehicleQueue);
            return vehicleQueue;
        }

        public List<VehicleQueue> Get()
        {
            return _vehicleQueue.Find(vehicleQueue => true).ToList();
        }

        public VehicleQueue Get(string id)
        {
            return _vehicleQueue.Find(vehicleQueue => vehicleQueue.Id == id).FirstOrDefault();
        }

        public void Remove(string id)
        {
            _vehicleQueue.DeleteOne(vehicleQueue => vehicleQueue.Id == id);
        }

        public void Update(string id, VehicleQueue vehicleQueue)
        {
            _vehicleQueue.ReplaceOne(type => type.Id == id, vehicleQueue);
        }
    }
}
