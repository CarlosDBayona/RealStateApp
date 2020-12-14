using System.Threading.Tasks;
using RealStateApp.Entities;

namespace RealStateApp.Repositories.IRepositories
{
    public interface IUnitOfWork
    {
        public CharacteristicTypeRepository CharacteristicTypeRepository { get; }
        public PropertyRepository PropertyRepository { get; }

        public PropertyCharacteristicRepository PropertyCharacteristicRepository { get; }
        public CharacteristicRepository CharacteristicRepository { get; }
        Task<bool> SaveAll();
        bool HasChanges();
    }
}