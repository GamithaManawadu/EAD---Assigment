using FuelMe.Models;

namespace FuelMe.Services
{
    public interface IFuelStatioService
    {
        List<FuelStation> Get();
        FuelStation Get(string id);
        FuelStation GetStationByOwner(string ownerId);
        FuelStation Create(FuelStation fuelStation);
        void Update(string id, FuelStation fuelStation);
        void Remove(string id);
    }
}
