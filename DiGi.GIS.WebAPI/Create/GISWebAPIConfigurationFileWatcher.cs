using DiGi.GIS.WebAPI.Classes;
using System.Reflection;

namespace DiGi.GIS.WebAPI
{
    public static partial class Create
    {
        /// <summary>
        /// Creates a new instance of the GISWebAPIConfigurationFileWatcher class.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public static GISWebAPIConfigurationFileWatcher GISWebAPIConfigurationFileWatcher()
        {
            string path = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ?? string.Empty, Constants.FileName.GISWebAPIConfigurationFile);

            return new GISWebAPIConfigurationFileWatcher(path);
        }
    }
}
