using AutoMapper;
using E_Commerce_Website.API.ViewModel;

namespace E_Commerce_Website.API.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CategoryViewModel, Category>().ReverseMap();
        }
    }
}
