using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RealStateApp.DTOs;
using RealStateApp.Entities;
using RealStateApp.Repositories.IRepositories;

namespace RealStateApp.Controllers
{
    public class CharacteristicTypeController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;

        public CharacteristicTypeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        [HttpGet]
        public async Task<ActionResult<List<CharacteristicTypeDto>>> Index()
        {
            return Ok(await _unitOfWork.CharacteristicTypeRepository.GetAllCharacteristicTypeAsync());
        }
    }
}