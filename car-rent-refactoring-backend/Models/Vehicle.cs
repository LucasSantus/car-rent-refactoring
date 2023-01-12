
using car_rent_refactoring_backend.Enums;

namespace car_rent_refactoring_backend.Models
{

    public class Vehicle : Entity
    {
        public string Description { get; set; }

        public EVehicleType Type
        {
            get; set;
        }
    }
}
