using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using RealStateApp.Data;
using RealStateApp.DTOs;
using RealStateApp.Entities;
using RealStateApp.Repositories.IRepositories;

namespace RealStateApp.Repositories
{
    public class PropertyRepository : IPropertyRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public PropertyRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public void AddProperty(Property property)
        {
            _context.Properties.Add(property);
        }

        public void UpdateProperty(Property property)
        {
            this._context.Properties.Update(property);
        }

        public void DeleteProperty(Property property)
        {
            this._context.Properties.Remove(property);
        }

        public async Task<List<Property>> GetAllPropertiesAsync()
        {
            return await this._context.Properties
                .ToListAsync();
        }

        public async Task<PropertyDto> GetPropertyAsync(int id)
        {
            return await this._context.Properties
                .ProjectTo<PropertyDto>(_mapper.ConfigurationProvider)
                .SingleOrDefaultAsync(p => p.Id == id);
        }
    }
}