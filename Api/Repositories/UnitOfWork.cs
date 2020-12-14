using System.Threading.Tasks;
using AutoMapper;
using RealStateApp.Data;
using RealStateApp.Repositories.IRepositories;

namespace RealStateApp.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public UnitOfWork(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public CharacteristicTypeRepository CharacteristicTypeRepository =>
            new CharacteristicTypeRepository(_context, _mapper);

        public PropertyRepository PropertyRepository => new PropertyRepository(_context, _mapper);

        public PropertyCharacteristicRepository PropertyCharacteristicRepository => new PropertyCharacteristicRepository(_context);

        public CharacteristicRepository CharacteristicRepository => new CharacteristicRepository(_context, _mapper);

        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public bool HasChanges()
        {
            return _context.ChangeTracker.HasChanges();
        }
    }
}