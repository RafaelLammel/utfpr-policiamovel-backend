using Microsoft.Extensions.DependencyInjection;
using UTFPR.PoliciaMovel.Application.Locations;
using UTFPR.PoliciaMovel.Application.Users;

namespace UTFPR.PoliciaMovel.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddTransient<ILocationService, LocationService>();
            services.AddTransient<IUserService, UserService>();

            return services;
        }
    }
}