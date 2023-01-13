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
    public class CustomerController : ControllerBase
    {
        public static List<Customer> DB { get; set; } = new List<Customer>();

        public CustomerController() { }

        [HttpGet]
        public List<Customer> GetAll()
        {
            return DB;
        }

        [HttpGet("GetById/{id}")]
        public Customer GetById(Guid id)
        {
            return DB.FirstOrDefault(_ => _.Id == id);
        }

        [HttpPost]
        public List<Customer> Create([FromBody] Customer item)
        {
            DB.Add(item);
            return DB;
        }


        [HttpPut]
        public Customer Update([FromBody] Customer item)
        {
            var itemById = DB.FirstOrDefault(_ => _.Id == item.Id);
 
            if (itemById != null)
            {
                itemById.FullName = item.FullName;
                itemById.Cpf = item.Cpf;
                itemById.CellPhone = item.Cpf;
                itemById.UpdateAt = DateTime.Now;
            }

            return itemById;
        }
        [HttpDelete]
        public List<Customer> Delete(Guid Id)
        {
            var itemById = DB.FirstOrDefault(_ => _.Id == Id);
            DB.Remove(itemById);
            return DB;
        }

    }
}
