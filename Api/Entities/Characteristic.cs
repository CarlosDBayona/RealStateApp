using System.Collections.Generic;

namespace RealStateApp.Entities
{
    public class Characteristic
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<PropertyCharacteristic> PropertyCharacteristicsOfCharacteristic { get; set; }
    }
}