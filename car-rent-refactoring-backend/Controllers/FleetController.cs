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
    public class FleetController : ControllerBase
    {
        public static List<Fleet> DB { get; set; } = new List<Fleet>();

        public FleetController() { }

        [HttpGet]
        public List<Fleet> GetAll()
        {
            return DB;
        }

        [HttpGet("GetById/{id}")]
        public Fleet GetById(Guid id)
        {
            return DB.FirstOrDefault(_ => _.Id == id);
        }

        [HttpPost]
        public Fleet Create([FromBody] Fleet item)
        {
            DB.Add(item);
            return item;
        }


        [HttpPut]
        public Fleet Update([FromBody] Fleet item)
        {
            var itemById = DB.FirstOrDefault(_ => _.Id == item.Id);
 
            if (itemById != null)
            {
                itemById.Name = item.Name;
                itemById.StoreId = item.StoreId;
                itemById.UpdateAt = DateTime.Now;
            }

            return itemById;
        }
        [HttpDelete]
        public List<Fleet> Delete(Guid Id)
        {
            var itemById = DB.FirstOrDefault(_ => _.Id == Id);
            DB.Remove(itemById);
            return DB;
        }

    }
}
