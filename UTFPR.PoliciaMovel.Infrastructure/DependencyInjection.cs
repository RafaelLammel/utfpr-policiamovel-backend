using Microsoft.Extensions.DependencyInjection;
using UTFPR.PoliciaMovel.Application.Users;
using UTFPR.PoliciaMovel.Infrastructure.Data.Repositories;

namespace UTFPR.PoliciaMovel.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddTransient<IUserRepository, UserRepository>();

            return services;
        }
    }
}