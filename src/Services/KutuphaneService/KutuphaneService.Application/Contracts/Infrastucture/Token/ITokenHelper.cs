using KutuphaneService.Application.Models;
using KutuphaneService.Domain.Entities;

namespace KutuphaneService.Application.Contracts.Infrastucture.Token
{
    public interface ITokenHelper
    {
        AccessToken CreateToken(User user);
    }
}
