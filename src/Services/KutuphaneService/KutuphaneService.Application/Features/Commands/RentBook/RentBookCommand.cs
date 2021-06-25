using MediatR;

namespace KutuphaneService.Application.Features.Commands.RentBook
{
    public class RentBookCommand
        : IRequest
    {
        public int BookId { get; set; }
        public int UserId { get; set; }
    }
}
