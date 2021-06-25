using KutuphaneService.Application.Contracts.Persistance;
using KutuphaneService.Persistance.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace KutuphaneService.Persistance
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddPersistanceRegistration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IBookDal, EfBookDal>();
            services.AddScoped<IWriterDal, EfWriterDal>();
            services.AddScoped<IPublisherDal, EfPublisherDal>();
            services.AddScoped<IGenreDal, EfGenreDal>();
            services.AddScoped<IUserDal, EfUserDal>();
            services.AddDbContext<KutuphaneContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("KutuphaneContext")));
            return services;
        }
    }
}
