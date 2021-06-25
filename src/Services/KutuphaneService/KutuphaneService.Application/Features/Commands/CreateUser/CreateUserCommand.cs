using MediatR;

namespace KutuphaneService.Application.Features.Commands.CreateUser
{
   public class CreateUserCommand
        : IRequest
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
