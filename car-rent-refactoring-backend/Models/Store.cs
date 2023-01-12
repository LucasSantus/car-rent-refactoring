using System;

namespace car_rent_refactoring_backend.Models
{

    public class Fleet : Entity
    {
        public string Name { get; set; }

        public Guid StoreId
        {
            get; set;
        }
    }
}
