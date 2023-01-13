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
    public class RentController : ControllerBase
    {
        public static List<Rent> DB { get; set; } = new List<Rent>();

        public RentController() { }

        [HttpGet]
        public List<Rent> GetAll()
        {
            return DB;
        }

        [HttpGet("GetById/{id}")]
        public Rent GetById(Guid id)
        {
            return DB.FirstOrDefault(_ => _.Id == id);
        }

        [HttpPost]
        public Rent Create([FromBody] Rent item)
        {
            DB.Add(item);
            return item;
        }


        [HttpPut]
        public Rent Update([FromBody] Rent item)
        {
            var itemById = DB.FirstOrDefault(_ => _.Id == item.Id);
 
            if (itemById != null)
            {
                itemById.DtBegin = item.DtBegin;
                itemById.DtEnd = item.DtEnd;
                itemById.CustomerId = item.CustomerId;
                itemById.VehicleId = item.VehicleId;
                itemById.UpdateAt = DateTime.Now;
            }

            return itemById;
        }
        [HttpDelete]
        public List<Rent> Delete(Guid Id)
        {
            var itemById = DB.FirstOrDefault(_ => _.Id == Id);
            DB.Remove(itemById);
            return DB;
        }

    }
}
