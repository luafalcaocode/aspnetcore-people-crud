using luafalcao.api.Web.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Globalization;

namespace luafalcao.api.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.ConfigureCors();
            services.ConfigureDbContext(Configuration);
            services.ConfigureMapper();
        
            services.ConfigureCache();
         
            services.ConfigureFacades();
            services.ConfigureDomains();
            services.ConfigureRepositories();


            services.Configure<FormOptions>(option =>
            {
                option.ValueLengthLimit = int.MaxValue;
                option.MultipartBodyLengthLimit = int.MaxValue;
                option.MemoryBufferThreshold = int.MaxValue;
            });
          
            services.ConfigureSwagger();

            services.AddControllers()
                .AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            var cultures = new[] { new CultureInfo("pt-BR") };

            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture("pt-BR"),
                SupportedCultures = cultures,
                SupportedUICultures = cultures
            });

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseCors("CorsPolicy");
            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = Microsoft.AspNetCore.HttpOverrides.ForwardedHeaders.All
            });

            app.UseRouting();         
            app.UseAuthorization();

            app.UseSwagger();
            app.UseSwaggerUI(s =>
            {
                s.SwaggerEndpoint("/swagger/v1/swagger.json", "Default");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();              
            });
        }
    }
}
