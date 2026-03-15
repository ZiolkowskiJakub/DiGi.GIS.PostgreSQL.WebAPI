using DiGi.GIS.PostgreSQL.WebAPI.Classes;
using System.Reflection;

namespace DiGi.GIS.PostgreSQL.WebAPI
{
    public static partial class Create
    {
        public static GISPostgreSQLWebAPIConfigurationFileWatcher GISPostgreSQLWebAPIConfigurationFileWatcher()
        {
            string path = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ?? string.Empty, Constants.FileName.GISPostgreSQLWebAPIConfigurationFile);

            return new GISPostgreSQLWebAPIConfigurationFileWatcher(path);
        }
    }
}