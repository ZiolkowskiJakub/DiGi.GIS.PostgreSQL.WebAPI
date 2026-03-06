using DiGi.PostgreSQL.Classes;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
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

            string? directory = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            if (!string.IsNullOrWhiteSpace(directory))
            {
                string path;

                path = System.IO.Path.Combine(directory!, "DiGi.GIS.PostgreSQL.WebAPI_Main.conf");

                if (System.IO.File.Exists(path))
                {
                    PostgreSQLConfigurationFile? postgreSQLConfigurationFile = DiGi.PostgreSQL.Create.PostgreSQLConfigurationFile(path);
                    if (postgreSQLConfigurationFile is not null)
                    {
                        await DiGi.PostgreSQL.Create.DatabaseAsync(postgreSQLConfigurationFile);

                        ConnectionData? connectionData = DiGi.PostgreSQL.Create.ConnectionData(postgreSQLConfigurationFile);

                        if (connectionData is not null)
                        {
                            serviceCollection.AddScoped(serviceProvider => new PostgreSQL.Classes.AdministrativeAreal2DPostgreSQLConverter(connectionData));
                        }
                    }
                }

                //path = System.IO.Path.Combine(directory!, "DiGi.GIS.PostgreSQL.WebAPI_OrtoDatas.conf");

                //if (System.IO.File.Exists(path))
                //{
                //    PostgreSQLConfigurationFile? postgreSQLConfigurationFile = DiGi.PostgreSQL.Create.PostgreSQLConfigurationFile(path);
                //    if (postgreSQLConfigurationFile is not null)
                //    {
                //        await DiGi.PostgreSQL.Create.DatabaseAsync(postgreSQLConfigurationFile);

                //        ConnectionData? connectionData = DiGi.PostgreSQL.Create.ConnectionData(postgreSQLConfigurationFile);

                //        if (connectionData is not null)
                //        {
                //            serviceCollection.AddScoped(serviceProvider => new PostgreSQL.Classes.OrtoDatasPostgreSQLConverter(connectionData));
                //        }
                //    }
                //}
            }
        }
    }
}