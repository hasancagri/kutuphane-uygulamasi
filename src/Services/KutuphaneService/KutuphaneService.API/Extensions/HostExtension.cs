using KutuphaneService.Persistance.EntityFramework;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Polly;
using System;

namespace KutuphaneService.API.Extensions
{
    public static class HostExtension
    {
        public static IHost MigrateDatabase(this IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var context = scope.ServiceProvider.GetService<KutuphaneContext>();
                var retry = Policy.Handle<SqlException>()
                    .WaitAndRetry(retryCount: 6, sleepDurationProvider: retryCount => TimeSpan.FromSeconds(Math.Pow(2, retryCount)), onRetry: (exception, context) =>
                    {
                        //Burada log işlemi olabilir
                    });
                retry.Execute(() => Migrate(context));
            }
            return host;
        }

        private static void Migrate(KutuphaneContext context)
        {
            context.Database.Migrate();
        }
    }
}
