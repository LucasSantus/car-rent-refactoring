using System;

namespace car_rent_refactoring_backend.Models
{
    public class Entity{
        public Entity() {
            Id = Guid.NewGuid();
            CreatedAt = DateTime.Now;
            UpdateAt = DateTime.Now;
        }

        public Guid Id { get; protected set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdateAt { get; set; }

        public DateTime DeleteAt { get; set; }
    }
}
