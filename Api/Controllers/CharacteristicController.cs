using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RealStateApp.DTOs;
using RealStateApp.Repositories.IRepositories;

namespace RealStateApp.Controllers
{
    public class CharacteristicController: BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;

        public CharacteristicController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<List<CharacteristicDto>>> ListCharacteristics()
        {
            return await this._unitOfWork.CharacteristicRepository.GetAllCharacteristicsAsync();
        }
    }
}