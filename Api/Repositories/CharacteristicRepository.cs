using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using RealStateApp.Data;
using RealStateApp.DTOs;
using RealStateApp.Repositories.IRepositories;

namespace RealStateApp.Repositories
{
    public class CharacteristicRepository: ICharacteristicRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public CharacteristicRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<CharacteristicDto>> GetAllCharacteristicsAsync()
        {
            return await this._context.Characteristics
                .ProjectTo<CharacteristicDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }
    }
}