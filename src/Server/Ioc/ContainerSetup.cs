using Microsoft.EntityFrameworkCore;
using Oma.Data.Queries.Common;
using Oma.Data.Queries.Vendor;
using Oma.Data.Repository.DAL;
using Oma.Server.Helper;
using Oma.Server.Maps;
using Serilog;

namespace Oma.Server.Ioc
{
    public static class ContainerSetup
    {
        internal static void Setup(IServiceCollection services, IConfiguration configuration)
        {
            ConfigureContext(services, configuration);
            ConfigureAutoMapper(services);
            ConfigureInject(services);
        }
        private static void ConfigureContext(IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration["Data:main"];
            var logDBConnection = configuration["Data:logDB"];
            
            var seriConfiguration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddUserSecrets<Program>(optional: true)
                .AddEnvironmentVariables()
                .Build();

            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(seriConfiguration)
                .WriteTo.MongoDB(logDBConnection)
                .CreateLogger();

            services.AddEntityFrameworkSqlServer();

            services.AddDbContext<MainDbContext>(options =>
                options.UseSqlServer(connectionString));

            services.AddScoped<IUnitOfWork>(ctx => new EFUnitOfWork(ctx.GetRequiredService<MainDbContext>()));
        }
        private static void ConfigureAutoMapper(IServiceCollection services)
        {
            var mapperConfig = AutoMapperConfigurator.Configure();
            var mapper = mapperConfig.CreateMapper();
            services.AddScoped(x => mapper);

            services.AddTransient<IAutoMapper, AutoMapperAdapter>();
            services.AddTransient<Microsoft.Extensions.Logging.ILogger>(svc => svc.GetRequiredService<ILogger<ActionTransactionHelper>>());
        }
        private static void ConfigureInject(IServiceCollection services)
        {
            services.AddScoped<ISupplierQueryProcessor,SupplierQueryProcessor>();
            services.AddScoped<IStateQueryProcessor, StateQueryProcessor>();
        }


    }
}
