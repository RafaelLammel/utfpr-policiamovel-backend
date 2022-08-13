using Microsoft.Extensions.DependencyInjection;
using UTFPR.PoliciaMovel.Application.Authentication;
using UTFPR.PoliciaMovel.Application.Locations;
using UTFPR.PoliciaMovel.Application.Users;
using UTFPR.PoliciaMovel.Infrastructure.Authentication;
using UTFPR.PoliciaMovel.Infrastructure.Data;
using UTFPR.PoliciaMovel.Infrastructure.Data.Repositories;

namespace UTFPR.PoliciaMovel.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            /* Authentication */
            services.AddTransient<ITokenService, TokenService>();
            
            /* Data */
            services.AddSingleton<MongoDbContext>();
            services.AddTransient<ILocationRepository, LocationRepository>();
            services.AddTransient<IUserRepository, UserRepository>();

            return services;
        }
    }
}