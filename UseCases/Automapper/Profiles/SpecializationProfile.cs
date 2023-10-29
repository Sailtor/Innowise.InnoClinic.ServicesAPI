using AutoMapper;
using Core.Entities;
using UseCases.Dtos.SpecializationDto;

namespace UseCases.Automapper.Profiles
{
    public sealed class SpecializationProfile : Profile
    {
        public SpecializationProfile()
        {
            CreateMap<SpecializationForCreationDto, Specialization>();
            CreateMap<SpecializationForUpdateDto, Specialization>();
            CreateMap<Specialization, SpecializationForResponseDto>();
        }
    }
}
