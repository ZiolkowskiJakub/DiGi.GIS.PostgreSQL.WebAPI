using DiGi.GIS.PostgreSQL.Classes;
using DiGi.GIS.PostgreSQL.WebAPI.Classes;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DiGi.GIS.PostgreSQL.WebAPI
{
    public static partial class Modify
    {
        public static async Task InitializeAsync(this IServiceCollection serviceCollection)
        {
            if (serviceCollection is null)
            {
                return;
            }

            GISPostgreSQLWebAPIConfigurationFileWatcher gISPostgreSQLWebAPIConfigurationFileWatcher = Create.GISPostgreSQLWebAPIConfigurationFileWatcher();
            if (gISPostgreSQLWebAPIConfigurationFileWatcher is not null)
            {
                serviceCollection.AddSingleton(gISPostgreSQLWebAPIConfigurationFileWatcher);
            }

            GISPostgreSQLConverterManager? gISPostgreSQLConverterManager = PostgreSQL.Create.GISPostgreSQLConverterManager();
            if (gISPostgreSQLConverterManager is not null)
            {
                List<PostgreSQL.Interfaces.IGISPostgreSQLConverter> gISPostgreSQLConverters = gISPostgreSQLConverterManager.GetPostgreSQLConverters<PostgreSQL.Interfaces.IGISPostgreSQLConverter>();
                if(gISPostgreSQLConverters is not null)
                {
                    foreach(PostgreSQL.Interfaces.IGISPostgreSQLConverter gISPostgreSQLConverter in gISPostgreSQLConverters)
                    {
                        serviceCollection.AddSingleton(gISPostgreSQLConverter.GetType(), gISPostgreSQLConverter);
                    }
                }
            }
        }
    }
}