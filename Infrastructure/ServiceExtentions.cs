
using Core_Application_Domain.Interfaces;
using Infrastructure.DatabaseContext;
using Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class ServiceExtentions
    {
        public static void AddInfrastructure(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<PlayersContext>(
               options => options
               //.UseLoggerFactory(MyLoggerFactory) // Warning: Do not create a new ILoggerFactory instance each time
               .UseSqlServer(
                    connectionString
                   )
               );
            // Geef aan welke repo er moet gebruikt worden
            // Bekijk verschil tussen transient, scoped en singleton voor services
            services.AddTransient<IPlayerRepository, PlayerRepository>();
            services.AddTransient<PlayerRepository, PlayerRepository>();
        }
    }
}
