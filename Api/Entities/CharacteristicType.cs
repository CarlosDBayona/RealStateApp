using System.Collections.Generic;

namespace RealStateApp.Entities
{
    public class CharacteristicType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<PropertyCharacteristic> PropertyCharacteristicsOfType { get; set; }
    }
}