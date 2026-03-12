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

            PostgreSQL.Classes.GISPostgreSQLConverterManager? gISPostgreSQLConverterManager = Create.GISPostgreSQLConverterManager();
            if(gISPostgreSQLConverterManager is not null)
            {
                if(gISPostgreSQLConverterManager.GetPostgreSQLConverter<PostgreSQL.Classes.AdministrativeAreal2DPostgreSQLConverter>() is PostgreSQL.Classes.AdministrativeAreal2DPostgreSQLConverter administrativeAreal2DPostgreSQLConverter)
                {
                    serviceCollection.AddScoped(serviceProvider => administrativeAreal2DPostgreSQLConverter);
                }
            }
        }
    }
}