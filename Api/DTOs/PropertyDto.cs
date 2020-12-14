using System;
using System.Collections.Generic;
using RealStateApp.Entities;

namespace RealStateApp.DTOs
{
    public class PropertyDto
    {
        public int Id { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public string OwnerName { get; set; }
        public string OwnerPhone { get; set; }
        public float Area { get; set; }
        public int Rooms { get; set; }
        public int Bathrooms { get; set; }
        public string Description { get; set; }
        public ICollection<PropertyCharacteristicDto> PropertyCharacteristics { get; set; }
    }
}