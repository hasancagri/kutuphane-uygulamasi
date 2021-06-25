using MediatR;

namespace KutuphaneService.Application.Features.Commands.CreateBook
{
    public class CreateBookCommand
        : IRequest
    {
        public string BookName { get; set; }
        public string ISBN { get; set; }
        public int GenreId { get; set; }
        public int PublisherId { get; set; }
        public int WriterId { get; set; }
    }
}
