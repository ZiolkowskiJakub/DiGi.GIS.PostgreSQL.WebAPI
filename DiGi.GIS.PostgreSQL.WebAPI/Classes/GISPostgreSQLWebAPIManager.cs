using Microsoft.AspNetCore.Mvc;
using System.Net.Http;

namespace DiGi.GIS.PostgreSQL.WebAPI.Classes
{
    public class GISPostgreSQLWebAPIManager
    {
        private readonly IHttpClientFactory? httpClientFactory;

        public GISPostgreSQLWebAPIManager(IHttpClientFactory? httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        public HttpClient? CreateHttpClient(string name)
        {
            return httpClientFactory?.CreateClient(name);
        }

        public HttpClient? CreateHttpClient<TControllerBase>(out string? route) where TControllerBase : ControllerBase
        {
            route = DiGi.WebAPI.Query.Route<TControllerBase>();
            if (string.IsNullOrWhiteSpace(route))
            {
                return null;
            }

            return CreateHttpClient(Constants.Name.Client);
        }

        public HttpClient? CreateHttpClient<TControllerBase>(string methodName, out string? path) where TControllerBase : ControllerBase
        {
            path = DiGi.WebAPI.Query.Path<TControllerBase>(methodName);
            if (string.IsNullOrWhiteSpace(path))
            {
                return null;
            }

            return CreateHttpClient(Constants.Name.Client);
        }
    }
}