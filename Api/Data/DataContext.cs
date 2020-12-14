using Microsoft.EntityFrameworkCore;
using RealStateApp.Entities;

namespace RealStateApp.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Property> Properties { get; set; }
        public DbSet<PropertyCharacteristic> PropertyCharacteristics { get; set; }
        public DbSet<CharacteristicType> CharacteristicTypes { get; set; }
        public DbSet<Characteristic> Characteristics { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<PropertyCharacteristic>()
                .HasOne(pc => pc.Characteristic)
                .WithMany(c => c.PropertyCharacteristicsOfCharacteristic)
                .HasForeignKey(pc => pc.CharacteristicId);
            builder.Entity<PropertyCharacteristic>()
                .HasOne(pc => pc.CharacteristicType)
                .WithMany(ct => ct.PropertyCharacteristicsOfType)
                .HasForeignKey(pc => pc.CharacteristicTypeId);
            builder.Entity<PropertyCharacteristic>()
                .HasOne(pc => pc.Property)
                .WithMany(p => p.PropertyCharacteristics)
                .HasForeignKey(pc => pc.PropertyId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}