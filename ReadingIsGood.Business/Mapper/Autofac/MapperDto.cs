using AutoMapper;
using ReadingIsGood.Core.Entities.Concrete;
using ReadingIsGood.Entities.DTOs;

namespace ReadingIsGood.Business.Mapper.Autofac
{
    public class MapperDto : Profile
    {
        public MapperDto()
        {
            CreateMap<Category, AddCategoryDto>().ReverseMap();
            CreateMap<Category, GetCategoryDto>().ReverseMap();
            CreateMap<Author, AddAuthorDto>().ReverseMap();
            CreateMap<Author, GetAuthorDto>();
            CreateMap<Address, GetAddressDto>().ReverseMap();
            CreateMap<Address, AddAddressDto>().ReverseMap();
            CreateMap<Book, AddBookDto>().ReverseMap();
            CreateMap<Book, GetBookDto>().ReverseMap();
            CreateMap<Book, UpdateBookDto>().ReverseMap();
        }
    }
}
