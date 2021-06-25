using KutuphaneService.Application.Contracts.Infrastucture.Mail;
using KutuphaneService.Application.Models;
using Microsoft.Extensions.Configuration;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace KutuphaneService.Infrastructure.MailSender
{
    public class EmailService
        : IEmailService
    {
        private EmailSettings _emailSettings;

        public EmailService(IConfiguration configuration)
        {
            _emailSettings = configuration.GetSection("EmailSettings").Get<EmailSettings>();
        }

        public async Task<bool> SendMail(Email email)
        {
            SmtpClient client = new(_emailSettings.Smtp, _emailSettings.Port);
            client.EnableSsl = _emailSettings.EnableSsl;
            client.Timeout = _emailSettings.Timeout;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = _emailSettings.UseDefaultCredentials;
            client.Credentials = new NetworkCredential(_emailSettings.Credentials, _emailSettings.Password);
            MailMessage msg = new();
            msg.To.Add(email.To);
            msg.From = new MailAddress(_emailSettings.From);
            msg.Subject = email.Subject;
            msg.Body = email.Body;
            client.Send(msg);
            return true;
        }
    }
}
