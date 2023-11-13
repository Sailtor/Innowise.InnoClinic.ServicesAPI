using AutoMapper;
using Core.Entities;
using UseCases.Dtos.CategoryDto;

namespace UseCases.Automapper.Profiles
{
    public sealed class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<CategoryForCreationDto, Category>();
            CreateMap<CategoryForUpdateDto, Category>();
            CreateMap<Category, CategoryForResponseDto>();
        }
    }

}
