using System.Collections.Generic;
using RealStateApp.Data;
using RealStateApp.Entities;
using RealStateApp.Repositories.IRepositories;

namespace RealStateApp.Repositories
{
    public class PropertyCharacteristicRepository: IPropertyCharacteristicRepository
    {
        private readonly DataContext _context;

        public PropertyCharacteristicRepository(DataContext context)
        {
            _context = context;
        }
        public void DeleteRangePropertyCharacteristicsAsync(List<PropertyCharacteristic> propertyCharacteristics)
        {
            this._context.PropertyCharacteristics.RemoveRange(propertyCharacteristics);
        }
    }
}