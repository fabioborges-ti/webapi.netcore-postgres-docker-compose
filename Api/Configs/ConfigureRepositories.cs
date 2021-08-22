using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Api.Data;

namespace Api.Configs
{
    public static class ConfigureRepositories
    {
        public static IServiceCollection ConfigureDependenciesRepository(this IServiceCollection service, string connectionString)
        {
            service.AddDbContext<DataContext>(options => options.UseNpgsql(connectionString));

            return service;
        }
    }
}
