using KutuphaneService.Application.Contracts.Infrastucture.Hashing;
using KutuphaneService.Application.Contracts.Infrastucture.Mail;
using KutuphaneService.Application.Contracts.Infrastucture.Token;
using KutuphaneService.Infrastructure.MailSender;
using KutuphaneService.Infrastructure.Utilities.Security.Hashing;
using KutuphaneService.Infrastructure.Utilities.Security.Jwt;
using Microsoft.Extensions.DependencyInjection;

namespace KutuphaneService.Infrastructure
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddInfrastructureRegistration(this IServiceCollection services)
        {
            services.AddScoped<ITokenHelper, JwtHelper>();
            services.AddSingleton<IEmailService, EmailService>();
            services.AddSingleton<IHashingHelper, HashingHelper>();
            return services;
        }
    }
}
