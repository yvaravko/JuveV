using System;
using DataAccess;
using DataAccess.Contracts;
using DataAccess.Domain;
using DataAccess.Repos;
using Infrustructure.Services.Account;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Data.Entity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
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

            services.AddLogging();

            services.AddEntityFramework()
                .AddSqlServer()
                .AddDbContext<JuveDbContext>(options =>
                      options.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=JuveV;Integrated Security=True"));


            services.AddIdentity<ApplicationUser, IdentityRole>(s =>
                    {
                        s.Password.RequireDigit = false;
                        s.Password.RequireUppercase = false;
                        s.Password.RequiredLength = 3;
                        s.Password.RequireNonLetterOrDigit = false;
                        s.Password.RequireLowercase = false;
                    })
                .AddEntityFrameworkStores<JuveDbContext>()
                .AddDefaultTokenProviders();

            RegisterClasses(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
        {
            app.UseIISPlatformHandler();
            app.UseStaticFiles();
            app.UseIdentity();

            loggerFactory.AddDebug(LogLevel.Warning);

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Admin}/{action=Index}/{id?}");
            });

            using (var ctx = new JuveDbContext())
            {
                ctx.EnsureSeedData();
            }
        }

        private void RegisterClasses(IServiceCollection services)
        {
            RegisterRepositories(services);
            RegisterServices(services);
        }

        private static void RegisterRepositories(IServiceCollection services)
        {
            services.AddScoped<ITeamRepository, TeamRepository>();
            services.AddScoped<IPlayerTypeRepository, PlayerTypeRepository>();
            services.AddScoped<ICountryRepository, CountryRepository>();
            services.AddScoped<IPlayerRepository, PlayerRepository>();
        }

        private static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IEmailSender, AuthMessageSender>();
            services.AddScoped<ISmsSender, AuthMessageSender>();
        }

        public static void Main(string[] args) => WebApplication.Run<Startup>(args);
    }
}