using Api.Data.Interfaces;
using Api.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Api.Configs
{
    public static class ConfigureServices
    {
        public static IServiceCollection ConfigureDependenciesServices(this IServiceCollection service)
        {
            service.AddScoped<IRepositoryStudents, RepositoryStudents>();
            service.AddScoped<IRepositoryTeachers, RepositoryTeachers>();
            service.AddScoped<IRepositoryDisciplines, RepositoryDisciplines>();

            service.AddControllers().AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            service.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            return service;
        }
    }
}
