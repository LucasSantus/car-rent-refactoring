
using car_rent_refactoring_backend.Enums;
using System;

namespace car_rent_refactoring_backend.Models
{

    public class Rent : Entity
    {
        public DateTime DtBegin { get; set; }

        public DateTime DtEnd { get; set; }

        public Guid CustomerId { get; set; }

        public Guid VehicleId { get; set; }
    }
}
