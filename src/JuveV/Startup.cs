using DataAccess;
using DataAccess.Contracts;
using DataAccess.Domain;
using DataAccess.Repos;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Serialization;

namespace JuveV
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc()
                .AddJsonOptions(
                    opt => { opt.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver(); });
            
            RegisterClasses(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            app.UseIISPlatformHandler();
            app.UseStaticFiles();

            app.UseMvc(
                config =>
                {
                    config.MapRoute("Default", "{controller}/{action}/{id?}",
                        new {controller = "Home", action = "PlayerTypes"});
                });

            using (var ctx = new JuveDbContext())
            {
                ctx.EnsureSeedData();
            }
        }

        private void RegisterClasses(IServiceCollection services)
        {
            RegisterRepositories(services);
        }

        private static void RegisterRepositories(IServiceCollection services)
        {
            services.AddTransient<IPlayerTypeRepository<PlayerType>, PlayerTypeRepository>();
        }

        public static void Main(string[] args) => WebApplication.Run<Startup>(args);
    }
}