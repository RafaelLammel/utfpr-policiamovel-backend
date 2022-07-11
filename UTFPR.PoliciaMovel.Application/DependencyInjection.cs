using Microsoft.Extensions.DependencyInjection;

namespace UTFPR.PoliciaMovel.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            return services;
        }
    }
}