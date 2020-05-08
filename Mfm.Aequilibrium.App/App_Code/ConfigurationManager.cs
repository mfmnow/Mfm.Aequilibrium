using Mfm.Aequilibrium.Data.Contracts;
using Mfm.Aequilibrium.Data.Services;
using Mfm.Aequilibrium.Domain.Contracts;
using Mfm.Aequilibrium.Domain.Services;
using Mfm.Aequilibrium.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.IO;

namespace Mfm.Aequilibrium.App.App_Code
{
    public class ConfigurationManager
    {
        public static void RegisterServices(IServiceCollection services, IConfiguration configuration)
        {
            var _connectionString = configuration.GetConnectionString("DefaultConnection")
                .Replace("{AppDir}", Directory.GetCurrentDirectory());

            services.AddDbContext<TestDbContext>(options =>
            options.UseSqlServer(_connectionString));

            ConfigureSettings(services, configuration);
            ConfigureDataServices(services);
            ConfigureDomainServices(services);
        }

        private static void ConfigureSettings(IServiceCollection services, IConfiguration configuration)
        {
            var config = new AppSettings();
            configuration.Bind("AppSettings", config);
            services.AddSingleton(config);
        }

        private static void ConfigureDataServices(IServiceCollection services)
        {
            services.AddScoped<IDbInitializer, DbInitializer>();
            services.AddScoped<ITestDbContext, TestDbContext>();
            services.AddScoped<ITransformerEntityDataAccess, TransformerEntityDataAccess>();
            
        }

        private static void ConfigureDomainServices(IServiceCollection services)
        {
            services.AddScoped<ITransformerDomainService, TransformerDomainService>();
            services.AddScoped<ITransformerBattleDomainService, TransformerBattleDomainService>();
            services.AddScoped<ITransformerMapperDomainService, TransformerMapperDomainService>();
        }

    }
}
