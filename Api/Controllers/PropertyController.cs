using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RealStateApp.DTOs;
using RealStateApp.Entities;
using RealStateApp.Repositories.IRepositories;

namespace RealStateApp.Controllers
{
    public class PropertyController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PropertyController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        
        [HttpGet]
        public async Task<List<Property>> GetProperties()
        {
            return await _unitOfWork.PropertyRepository.GetAllPropertiesAsync();
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<PropertyDto>> GetProperties(int id)
        {
            var property = await _unitOfWork.PropertyRepository.GetPropertyAsync(id);
            if (property != null) return Ok(property);;
            return NotFound();
        }

        [HttpPost]
        public async Task<ActionResult> AddProperty(PropertyDto propertyDto)
        {
            var property =  _mapper.Map<Property>(propertyDto);
            property.CreatedAt = DateTime.UtcNow;
            this._unitOfWork.PropertyRepository.AddProperty(property);
            if (await _unitOfWork.SaveAll()) return Ok();
            return BadRequest("Error adding property");
        }

        [HttpPut]
        public async Task<ActionResult> UpdateProperty(PropertyDto propertyDto)
        {
            var property = _mapper.Map<Property>(propertyDto);
            this._unitOfWork.PropertyRepository.UpdateProperty(property);
            if (await _unitOfWork.SaveAll()) return Ok();
            return BadRequest("Error updating property");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProperty(int id)
        {
            var property = await this._unitOfWork.PropertyRepository.GetPropertyAsync(id);
            this._unitOfWork.PropertyRepository.DeleteProperty(_mapper.Map<Property>(property));
            if (await _unitOfWork.SaveAll()) return Ok();
            return BadRequest("Error deleting property");
            
        }
    }
}