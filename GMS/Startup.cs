//using GMS.Repository.Contract;
using GMS.Models;
//using GMS.Repository.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace GMS
{
    public class Startup
    {
        public static IConfiguration StaticConfig { get; private set; }
        public static IWebHostEnvironment _webHostEnvironment { get; private set; }
        public IConfiguration Configuration { get; }
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        public Startup(IConfiguration configuration, IWebHostEnvironment webHostEnvironment)
        {
            Configuration = configuration;
            StaticConfig = configuration;
            _webHostEnvironment = webHostEnvironment;
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,GMSDbContext db)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
            if ((env.IsDevelopment()) || (env.IsProduction()))
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "GMS v1"));
            }
            db.Database.EnsureCreated();
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();
            app.UseCors(MyAllowSpecificOrigins);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
         //   services.AddScoped<IMembersService, MembersService>();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CrudCodeFirst", Version = "v1" });
            });
            services.AddDbContext<GMSDbContext>(item => item.UseSqlServer(Configuration.GetConnectionString("connectionstring")));
        }
    }
}
