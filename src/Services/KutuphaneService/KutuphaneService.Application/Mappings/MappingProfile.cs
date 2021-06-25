using AutoMapper;
using KutuphaneService.Application.Features.Commands.CreateBook;
using KutuphaneService.Application.Features.Commands.CreateUser;
using KutuphaneService.Application.Models;
using KutuphaneService.Domain.Entities;

namespace KutuphaneService.Application.Mappings
{
    public class MappingProfile
         : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateUserCommand, User>();
            CreateMap<Genre, GenreListViewModel>();
            CreateMap<CreateBookCommand, Book>();
            CreateMap<Book, BookListViewModel>()
                .ForMember(x => x.GenreName, y => y.MapFrom(z => z.Genre.GenreName))
                .ForMember(x => x.PublisherName, y => y.MapFrom(z => z.Publisher.PublisherName))
                .ForMember(x => x.WriterName, y => y.MapFrom(z => z.Writer.WriterName))
                .ForMember(x => x.IsReserved, y => y.MapFrom(z => z.UserId != null));
        }
    }
}
