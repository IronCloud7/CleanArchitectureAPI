using CA.API.Middleware;
using CA.Core.Interfaces;
using CA.Infrastructure.Data;
using CA.Infrastructure.Mappings;
using CA.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CA.API.Startup
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            /* Añadimos "AutoMapper" antes de configurar los controllers y se cargan todas las configuraciones de
             * AutoMapper en las referencias de este ensamblado. */
            /* services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies()); */
            /* Otra forma */
            services.AddAutoMapper(typeof(Startup).Assembly, typeof(AutoMapperProfile).Assembly);

            /* Añadir controllers y configurando JSON para evitar referencias circulares, ignorando atributos nulos y
             * formateando los atributos en notación "CamelCase", así como ajustando la zona horaria a meridiano local. */

            services.AddControllers()
                    .AddNewtonsoftJson(options =>
                    {
                        options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                        options.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
                        options.SerializerSettings.DateTimeZoneHandling = Newtonsoft.Json.DateTimeZoneHandling.Local;
                        options.UseCamelCasing(false);
                    });

            /* Cadena de conexión al contexto de Base de datos. */
            services.AddDbContext<PatosaDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("PatosaDbContext"));
            });

            /* Contenedor de inversión de control (IoC). */
            services.AddDependecy();
        }

        public void Configure(IApplicationBuilder applicationBuilder, IWebHostEnvironment webHostEnvironment)
        {
            if (webHostEnvironment.IsDevelopment())
            {
                applicationBuilder.UseDeveloperExceptionPage();
            }

            applicationBuilder.UseHttpsRedirection();
            applicationBuilder.UseRouting();
            applicationBuilder.UseAuthorization();
            applicationBuilder.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}
