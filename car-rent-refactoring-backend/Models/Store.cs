﻿using System;

namespace car_rent_refactoring_backend.Models
{

    public class Store : Entity
    {
        public string Name { get; set; }

        public string Cpf { get; set; }

        public string CellPhone { get; set; }
    }
}
