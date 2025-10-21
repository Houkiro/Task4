using AutoMapper;
using BLL.DTO;
using DAL.Entities.Model;

namespace BLL.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Author, AuthorResponseDto>();
            CreateMap<Author, AuthorWithBookCountDto>()
                .ForMember(dest => dest.BookCount,
                           opt => opt.MapFrom(src => src.Books.Count));

            CreateMap<CreateAuthorModelDto, Author>();
            CreateMap<UpdateAuthorModelDto, Author>();

            CreateMap<Book, BookResponseDto>();
            CreateMap<CreateBookModelDto, Book>();
            CreateMap<UpdateBookModelDto, Book>();
        }
    }
}