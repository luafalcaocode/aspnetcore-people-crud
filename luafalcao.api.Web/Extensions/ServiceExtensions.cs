using AutoMapper;
using luafalcao.api.Domain.Contracts.Services;
using luafalcao.api.Domain.Services;
using luafalcao.api.Facade.Contracts;
using luafalcao.api.Facade.Facades;
using luafalcao.api.Persistence.Contexts;
using luafalcao.api.Persistence.Contracts.Repositories;
using luafalcao.api.Persistence.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace luafalcao.api.Web.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureCors(this IServiceCollection services) =>
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                {
                    builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
                });
            });

        public static void ConfigureIISIntegration(this IServiceCollection services) =>
            services.Configure<IISOptions>(options =>
            {

            });

        public static void ConfigureMapper(this IServiceCollection services) =>
            services.AddAutoMapper(typeof(Startup));

        public static void ConfigureRazor(this IServiceCollection services) =>
           services.AddRazorPages(options =>
           {

           });

        public static void ConfigureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new OpenApiInfo { Title = "ASP .NET Core Template API", Version = "v1" });
            });
        }

        public static void ConfigureCache(this IServiceCollection services) =>
            services.AddMemoryCache();

        public static void ConfigureDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(configuration.GetConnectionString("SqlServerConnection"), options =>
                options.MigrationsAssembly("luafalcao.api.Web")
                .EnableRetryOnFailure()));
        }

        public static void ConfigureFacades(this IServiceCollection services)
        {
            services.AddScoped<ICityFacade, ICityFacade>();
            services.AddScoped<IPersonFacade, PersonFacade>();
        }

        public static void ConfigureDomains(this IServiceCollection services)
        {
            services.AddScoped<ICityService, CityService>();
            services.AddScoped<IPersonService, PersonService>();
        }

        public static void ConfigureRepositories(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryManager, RepositoryManager>();            
        }
    }
}
