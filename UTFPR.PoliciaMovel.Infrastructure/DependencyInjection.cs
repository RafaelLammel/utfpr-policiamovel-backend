using Microsoft.Extensions.DependencyInjection;
using UTFPR.PoliciaMovel.Application.Locations;
using UTFPR.PoliciaMovel.Infrastructure.Data.Repositories;

namespace UTFPR.PoliciaMovel.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddTransient<ILocationRepository, LocationRepository>();
            return services;
        }
    }
}