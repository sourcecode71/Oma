using Microsoft.EntityFrameworkCore;
using Oma.Data.Repository.DAL;
using Oma.Server.Ioc;

namespace Oma.Server
{
    internal class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            ContainerSetup.Setup(services, Configuration);
        }

        internal void InitDatabase(WebApplication application)
        {
            IApplicationBuilder app = application;
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<MainDbContext>();
                if (context != null)
                {
                    context.Database.Migrate();
                }
            }
        }

    }
}
