using KutuphaneService.Application.Models;
using System.Threading.Tasks;

namespace KutuphaneService.Application.Contracts.Infrastucture.Mail
{
    public interface IEmailService
    {
        Task<bool> SendMail(Email email);
    }
}
