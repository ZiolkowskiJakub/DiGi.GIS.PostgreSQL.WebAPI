using DiGi.GIS.PostgreSQL.WebAPI.Classes;
using System.Net.Http;
using System.Reflection;

namespace DiGi.GIS.PostgreSQL.WebAPI
{
    public static partial class Create
    {
        public static HttpClient? HttpClient_Geoportal(GISPostgreSQLWebAPIManager gISPostgreSQLWebAPIManager)
        {
            HttpClient? result = gISPostgreSQLWebAPIManager?.CreateHttpClient("Geoportal");
            if (result is null)
            {
                return null;
            }

            AssemblyName assemblyName = Assembly.GetExecutingAssembly().GetName();

            string applicationInfo = string.Format("{0}/{1}", assemblyName.Name ?? "DiGi.GIS.PostgreSQL.WebAPI", assemblyName.Version?.ToString() ?? "1.0.0.0");

            result.DefaultRequestHeaders.Add("User-Agent", $"Mozilla/5.0 (Windows NT 10.0; Win64; x64) {applicationInfo}");

            return result;
        }
    }
}