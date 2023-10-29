using AutoMapper;
using Core.Entities;
using UseCases.Dtos.ServiceDto;

namespace UseCases.Automapper.Profiles
{
    public sealed class ServiceProfile : Profile
    {
        public ServiceProfile()
        {
            CreateMap<ServiceForCreationDto, Service>();
            CreateMap<ServiceForUpdateDto, Service>();
            CreateMap<Service, ServiceForResponseDto>();
        }
    }

}
