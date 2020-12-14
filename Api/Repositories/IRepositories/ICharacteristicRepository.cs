using System.Collections.Generic;
using System.Threading.Tasks;
using RealStateApp.DTOs;

namespace RealStateApp.Repositories.IRepositories
{
    public interface ICharacteristicRepository
    {
        Task<List<CharacteristicDto>> GetAllCharacteristicsAsync();
    }
}