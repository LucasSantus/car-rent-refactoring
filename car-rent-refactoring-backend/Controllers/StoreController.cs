using car_rent_refactoring_backend.Models;
using car_rent_refactoring_backend.Validators;
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
    public class StoreController : ControllerBase
    {
        public static List<Store> DB { get; set; } = new List<Store>();

        public StoreController() { }

        [HttpGet]
        public List<Store> GetAll()
        {
            return DB;
        }

        [HttpGet("GetById/{id}")]
        public Store GetById(Guid id)
        {
            return DB.FirstOrDefault(_ => _.Id == id);
        }

        [HttpPost]
        public List<Store> Create([FromBody] Store item)
        {
            if(Validate(item)) DB.Add(item);

            return DB;
        }


        [HttpPut]
        public Store Update([FromBody] Store item)
        {
            var itemById = DB.FirstOrDefault(_ => _.Id == item.Id);

            if (itemById != null)
            {
                itemById.Name = item.Name;
                itemById.ZipCode = item.ZipCode;
                itemById.Cnpj = item.Cnpj;
                itemById.UpdateAt = DateTime.Now;
            }

            return itemById;
        }
        [HttpDelete]
        public List<Store> Delete(Guid Id)
        {
            var itemById = DB.FirstOrDefault(_ => _.Id == Id);
            DB.Remove(itemById);
            return DB;
        }

        private bool Validate(Store item) => new StoreValidator(item).CheckCnpj().isValid;

    }
}
