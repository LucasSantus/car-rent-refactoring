
using car_rent_refactoring_backend.Controllers;
using car_rent_refactoring_backend.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace car_rent_refactoring_backend.Services
{
    public class StoreServices
    {

        [HttpGet("GetVehicleAvailability")]
        public List<Vehicle> VehicleAvailabilityService(DateTime DtBegin, DateTime DtEnd)
        {
            var DB = VehicleController.DB;

            return DB;
        }
    }
}
