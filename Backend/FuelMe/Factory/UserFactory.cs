using FuelMe.Models;
using FuelMe.Services;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson.IO;
using System.Xml.Linq;
using JsonConvert = Newtonsoft.Json.JsonConvert;

namespace FuelMe.Factory
{
    public class UserFactory
    {
        private readonly IUserService userService;
        private readonly IVehicleService vehicleService;
        private readonly IFuelStatioService fuelStatioService;

        public UserFactory(IUserService userService , IVehicleService vehicleService, IFuelStatioService fuelStatioService)
        {
            this.userService = userService;
            this.vehicleService = vehicleService;
            this.fuelStatioService = fuelStatioService;
        }
        internal string RegisterDriver(Driver driver)
        {
            User user = new User();
            Vehicle vehicle = new Vehicle();
            user.NIC = driver.NIC;
            user.Name = driver.Name;
            user.Password = driver.Password;
            //user.Email = driver.Email;
            user.UserType = "Driver";
            userService.Create(user);
            vehicle.OwnerId = user.Id; 
            vehicle.VehicleNo = driver.VehicleNo;
            vehicle.VehicleType = driver.VehicleType;
            vehicle.FuelType = driver.FuelType;
            vehicleService.Create(vehicle);
            return JsonConvert.SerializeObject(new { user = user, vehicle = vehicle });
        }

        internal ActionResult<string> ValidateUser(User user)
        {
            User candidateUser = userService.GetValidUserByNic(user.NIC , user.Password);
            if (candidateUser != null)
            {
                if (candidateUser.UserType == "Driver")
                {
                    Vehicle vehicle = vehicleService.GetVehicleByOwnerId(candidateUser.Id);
                    return JsonConvert.SerializeObject(new { statusCode = StatusCodes.Status200OK, userType = candidateUser.UserType ,  user = candidateUser, vehicle = vehicle });
                }
                else if (candidateUser.UserType == "Station Owner")
                {
                    FuelStation fuelStation = fuelStatioService.GetStationByOwner(candidateUser.Id);
                    return JsonConvert.SerializeObject(new { statusCode = StatusCodes.Status200OK, userType = candidateUser.UserType, user = candidateUser, fuelStation = fuelStation });

                }
                else if (candidateUser.UserType == "Admin")
                {
                    return JsonConvert.SerializeObject(new { statusCode = StatusCodes.Status200OK, userType = candidateUser.UserType, user = candidateUser});

                }
                else 
                {
                    return JsonConvert.SerializeObject(new { statusCode = StatusCodes.Status401Unauthorized });
                }
            }
            else
            {
                return JsonConvert.SerializeObject(new { statusCode = StatusCodes.Status401Unauthorized });
            }
        }
    }
}
