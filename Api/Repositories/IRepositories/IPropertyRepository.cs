using System.Collections.Generic;
using System.Threading.Tasks;
using RealStateApp.DTOs;
using RealStateApp.Entities;

namespace RealStateApp.Repositories.IRepositories
{
    public interface IPropertyRepository
    {
        void AddProperty(Property property);
        void UpdateProperty(Property property);
        void DeleteProperty(Property property);
        Task<List<Property>> GetAllPropertiesAsync();
        Task<PropertyDto> GetPropertyAsync(int id);
    }
}