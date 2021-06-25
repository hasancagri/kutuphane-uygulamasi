using KutuphaneService.Application.Models;
using MediatR;

namespace KutuphaneService.Application.Features.Queries.LoginUser
{
    public class LoginUserQuery
        : IRequest<AccessToken>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
