using AutoMapper;
using Core.Entities.Model;
using Shared.DTO;

namespace Task4
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<Author, AuthorDto>();
            CreateMap<Book, BookDto>();
            CreateMap<AuthorDtoWithoutId, Author>();
            CreateMap<BookDtoWithoutId, Book>();
            CreateMap<Author, AuthorWithBookCountDto>();
        }
    }
}