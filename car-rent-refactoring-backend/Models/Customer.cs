
using car_rent_refactoring_backend.Enums;

namespace car_rent_refactoring_backend.Models
{

    public class Customer : Entity
    {
        public string FullName { get; set; }

        public string Cpf { get; set; }

        public string CellPhone { get; set; }
    }
}
