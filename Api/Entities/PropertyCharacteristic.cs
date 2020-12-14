namespace RealStateApp.Entities
{
    public class PropertyCharacteristic
    {
        public int Id { get; set; }
        public CharacteristicType CharacteristicType { get; set; }
        public int CharacteristicTypeId { get; set; }
        public Property Property { get; set; }
        public int PropertyId { get; set; }
        public Characteristic Characteristic { get; set; }
        public int CharacteristicId { get; set; }
    }
}