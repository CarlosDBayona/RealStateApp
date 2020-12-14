using RealStateApp.Entities;
using Property = Microsoft.EntityFrameworkCore.Metadata.Internal.Property;

namespace RealStateApp.DTOs
{
    public class PropertyCharacteristicDto
    {
        public int Id { get; set; }
        public string CharacteristicTypeName { get; set; }
        public int CharacteristicTypeId { get; set; }
        public int CharacteristicId { get; set; }
        public string CharacteristicName { get; set; }
    }
}