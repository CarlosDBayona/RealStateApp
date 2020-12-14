using System.Collections.Generic;
using System.Threading.Tasks;
using RealStateApp.DTOs;
using RealStateApp.Entities;

namespace RealStateApp.Repositories.IRepositories
{
    public interface ICharacteristicTypeRepository
    {
        Task<List<CharacteristicDto>> GetAllCharacteristicTypeAsync();
    }
}