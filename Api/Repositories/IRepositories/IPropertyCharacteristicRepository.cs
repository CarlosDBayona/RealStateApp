using System.Collections.Generic;
using RealStateApp.Entities;

namespace RealStateApp.Repositories.IRepositories
{
    public interface IPropertyCharacteristicRepository
    {
        public void DeleteRangePropertyCharacteristicsAsync(List<PropertyCharacteristic> characteristics);
    }
}