using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RealStateApp.Data;
using RealStateApp.Entities;

namespace RealStateApp.Seed
{
    public class SeedData
    {
        public static async Task SeedCharacteristicTypes(DataContext context)
        {
            if (await context.CharacteristicTypes.AnyAsync()) return;
            var types = new List<CharacteristicType>
            {
                new CharacteristicType() {Name = "Interior"},
                new CharacteristicType() {Name = "Exterior"}
            };

            await context.CharacteristicTypes.AddRangeAsync(types);
            await context.SaveChangesAsync();
        }
    }
}