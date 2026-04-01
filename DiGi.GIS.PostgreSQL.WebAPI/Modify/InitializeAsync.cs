using DiGi.GIS.PostgreSQL.Classes;
using DiGi.GIS.PostgreSQL.WebAPI.Classes;
using Microsoft.Extensions.DependencyInjection;
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
                if (gISPostgreSQLConverterManager.GetPostgreSQLConverter<AdministrativeAreal2DPostgreSQLConverter>() is AdministrativeAreal2DPostgreSQLConverter administrativeAreal2DPostgreSQLConverter)
                {
                    serviceCollection.AddSingleton(administrativeAreal2DPostgreSQLConverter);

                    //serviceCollection.AddScoped(serviceProvider => administrativeAreal2DPostgreSQLConverter);
                }

                if (gISPostgreSQLConverterManager.GetPostgreSQLConverter<Building2DPostgreSQLConverter>() is Building2DPostgreSQLConverter building2DPostgreSQLConverter)
                {
                    serviceCollection.AddSingleton(building2DPostgreSQLConverter);

                    //serviceCollection.AddScoped(serviceProvider => building2DPostgreSQLConverter);
                }

                if (gISPostgreSQLConverterManager.GetPostgreSQLConverter<OrtoDatasPostgreSQLConverter>() is OrtoDatasPostgreSQLConverter ortoDatasPostgreSQLConverter)
                {
                    serviceCollection.AddSingleton(ortoDatasPostgreSQLConverter);

                    //serviceCollection.AddScoped(serviceProvider => building2DPostgreSQLConverter);
                }

                if (gISPostgreSQLConverterManager.GetPostgreSQLConverter<YearBuiltPostgreSQLConverter>() is YearBuiltPostgreSQLConverter yearBuiltPostgreSQLConverter)
                {
                    serviceCollection.AddSingleton(yearBuiltPostgreSQLConverter);

                    //serviceCollection.AddScoped(serviceProvider => yearBuiltDataPostgreSQLConverter);
                }
            }
        }
    }
}