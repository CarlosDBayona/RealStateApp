using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RealStateApp.Entities;
using RealStateApp.Repositories.IRepositories;

namespace RealStateApp.Controllers
{
    public class PropertyCharacteristicController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;

        public PropertyCharacteristicController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        public async Task<ActionResult> DeleteRangePropertyCharacteristicsRepository(
            List<PropertyCharacteristic> propertyCharacteristics)
        {
            this._unitOfWork.PropertyCharacteristicRepository.DeleteRangePropertyCharacteristicsAsync(propertyCharacteristics);
            if (await this._unitOfWork.SaveAll()) return Ok();
            return BadRequest("Error deleting property characteristics");
        }
    }
}