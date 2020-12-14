using AutoMapper;
using RealStateApp.DTOs;
using RealStateApp.Entities;

namespace RealStateApp.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<CharacteristicType, CharacteristicTypeDto>();
            CreateMap<Property, PropertyDto>();
            CreateMap<PropertyCharacteristic, PropertyCharacteristicDto>()
                .ForMember(
                    dest => dest.CharacteristicName,
                    opt => opt.MapFrom(
                        src => src.Characteristic.Name
                    )
                )
                .ForMember(
                    dest => dest.CharacteristicTypeName,
                    opt => opt.MapFrom(
                        src => src.CharacteristicType.Name
                    )
                );
            CreateMap<Characteristic, CharacteristicDto>();
            CreateMap<CharacteristicTypeDto, CharacteristicType>();
            CreateMap<CharacteristicDto, Characteristic>();
            CreateMap<PropertyCharacteristicDto, PropertyCharacteristic>();
            CreateMap<PropertyDto, Property>();
        }
    }
}