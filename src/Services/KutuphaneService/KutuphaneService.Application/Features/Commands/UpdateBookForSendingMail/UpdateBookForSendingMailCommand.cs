using MediatR;

namespace KutuphaneService.Application.Features.Commands.UpdateBookForSendingMail
{
    public class UpdateBookForSendingMailCommand
        : IRequest
    {
        public int Id { get; set; }
    }
}
