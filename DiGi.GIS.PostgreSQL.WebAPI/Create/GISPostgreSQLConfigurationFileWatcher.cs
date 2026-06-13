using DiGi.GIS.PostgreSQL.WebAPI.Classes;
using System.Reflection;

namespace DiGi.GIS.PostgreSQL.WebAPI
{
    public static partial class Create
    {
        /// <summary>
        /// Creates a new instance of the GISPostgreSQLWebAPIConfigurationFileWatcher class.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public static GISPostgreSQLWebAPIConfigurationFileWatcher GISPostgreSQLWebAPIConfigurationFileWatcher()
        {
            string path = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ?? string.Empty, Constants.FileName.GISPostgreSQLWebAPIConfigurationFile);

            return new GISPostgreSQLWebAPIConfigurationFileWatcher(path);
        }
    }
}