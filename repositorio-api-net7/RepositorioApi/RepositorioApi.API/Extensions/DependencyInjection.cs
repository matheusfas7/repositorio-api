using RepositorioApi.Application.Interfaces;
using RepositorioApi.Application.Services;
using RepositorioApi.Domain.Interfaces;
using RepositorioApi.Infrastructure.ExternalServices;

namespace RepositorioApi.API.Configurations
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddCustomServices(this IServiceCollection services)
        {
            services.AddScoped<IRepositorioService, RepositorioService>();
            services.AddHttpClient<IGitHubService, GitHubService>();

            return services;
        }
    }
}