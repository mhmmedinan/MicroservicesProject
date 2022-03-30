using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Services.Catalog.Settings;

namespace Services.Catalog.Extensions
{
    public static class AddDatabaseSettings
    {
        public static IServiceCollection AddMongoDbSettings(this IServiceCollection services,
            IConfiguration configuration)
        {
            return services.Configure<DatabaseSettings>(options =>
            {
                options.ConnectionString = configuration
                    .GetSection(nameof(DatabaseSettings) + ":" + DatabaseSettings.ConnectionStringValue).Value;
                options.Database = configuration
                    .GetSection(nameof(DatabaseSettings) + ":" + DatabaseSettings.DatabaseValue).Value;
            });
        }
    }
}
