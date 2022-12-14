namespace FuelMe.Helpers
{
    public interface IFuelMeDatabaseHelper
    {
        string DatabaseName { get; set; }
        string ConnectionString { get; set; }
        string UserCollectionName { get; set; }
        string FuelStationCollectionName { get; set; }
        string FuelTypeCollectionName { get; set; }
        string FuelInventoryCollectionName { get; set; }
        string VehicleQueueCollectionName { get; set; }
        string VehicleTypeCollectionName { get; set; }
        string VehicleCollectionName { get; set; }
    }
}
