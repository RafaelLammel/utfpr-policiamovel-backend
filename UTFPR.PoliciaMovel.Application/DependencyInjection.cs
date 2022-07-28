using Microsoft.Extensions.DependencyInjection;
using UTFPR.PoliciaMovel.Application.Locations;

namespace UTFPR.PoliciaMovel.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddTransient<ILocationService, LocationService>();
            return services;
        }
    }
}