using Microsoft.Extensions.DependencyInjection;
using UTFPR.PoliciaMovel.Application.Locations;
using UTFPR.PoliciaMovel.Application.Users;
using UTFPR.PoliciaMovel.Infrastructure.Authentication;
using UTFPR.PoliciaMovel.Infrastructure.Data.Repositories;

namespace UTFPR.PoliciaMovel.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddTransient<ILocationRepository, LocationRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<TokenService>();
            return services;
        }
    }
}