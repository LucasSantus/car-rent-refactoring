using System;

namespace car_rent_refactoring_backend.Models
{

    public class Store : Entity
    {
        public string Name { get; set; }

        public string ZipCode { get; set; }

        public string Cnpj { get; set; }
    }
}
