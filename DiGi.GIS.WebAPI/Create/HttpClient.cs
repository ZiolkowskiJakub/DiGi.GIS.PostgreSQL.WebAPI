using DiGi.GIS.WebAPI.Classes;
using System.Net.Http;
using System.Reflection;

namespace DiGi.GIS.WebAPI
{
    public static partial class Create
    {
        /// <summary>
        /// Creates and configures an <see cref="System.Net.Http.HttpClient"/> instance for the Geoportal service, including a custom User-Agent header based on the executing assembly's name and version.
        /// </summary>
        /// <param name="GISWebAPIManager">The manager used to create the HTTP client instance.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public static HttpClient? HttpClient_Geoportal(GISWebAPIManager GISWebAPIManager)
        {
            HttpClient? result = GISWebAPIManager?.CreateHttpClient("Geoportal");
            if (result is null)
            {
                return null;
            }

            AssemblyName assemblyName = Assembly.GetExecutingAssembly().GetName();

            string applicationInfo = string.Format("{0}/{1}", assemblyName.Name ?? "DiGi.GIS.WebAPI", assemblyName.Version?.ToString() ?? "1.0.0.0");

            result.DefaultRequestHeaders.Add("User-Agent", $"Mozilla/5.0 (Windows NT 10.0; Win64; x64) {applicationInfo}");

            return result;
        }
    }
}