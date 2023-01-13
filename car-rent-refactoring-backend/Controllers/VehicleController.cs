using car_rent_refactoring_backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace car_rent_refactoring_backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VehicleController : ControllerBase
    {
        public static List<Vehicle> DB { get; set; } = new List<Vehicle>();

        public VehicleController() { }

        [HttpGet]
        public List<Vehicle> GetAll()
        {
            return DB;
        }

        [HttpGet("GetById/{id}")]
        public Vehicle GetById(Guid id)
        {
            return DB.FirstOrDefault(_ => _.Id == id);
        }

        [HttpPost]
        public List<Vehicle> Create([FromBody] Vehicle item)
        {
            DB.Add(item);
            return DB;
        }


        [HttpPut]
        public Vehicle Update([FromBody] Vehicle item)
        {
            var itemById = DB.FirstOrDefault(_ => _.Id == item.Id);
 
            if (itemById != null)
            {
                itemById.Description = item.Description;
                itemById.Type = item.Type;
                itemById.UpdateAt = DateTime.Now;
            }

            return itemById;
        }
        [HttpDelete]
        public List<Vehicle> Delete(Guid Id)
        {
            var itemById = DB.FirstOrDefault(_ => _.Id == Id);
            DB.Remove(itemById);
            return DB;
        }

    }
}
