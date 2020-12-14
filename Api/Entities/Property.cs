using System;
using System.Collections.Generic;

namespace RealStateApp.Entities
{
    public class Property
    {
        public int Id { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public string Name { get; set; }
        public float Price { get; set; }
        public string OwnerName { get; set; }
        public string OwnerPhone { get; set; }
        public float Area { get; set; }
        public int Rooms { get; set; }
        public int Bathrooms { get; set; }
        public ICollection<PropertyCharacteristic> PropertyCharacteristics { get; set; }
    }
}