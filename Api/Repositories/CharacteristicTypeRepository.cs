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
    public class CharacteristicTypeRepository : ICharacteristicTypeRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public CharacteristicTypeRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<CharacteristicDto>> GetAllCharacteristicTypeAsync()
        {
            return await this._context.CharacteristicTypes
                .ProjectTo<CharacteristicDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }
    }
}