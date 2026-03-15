using DiGi.GIS.PostgreSQL.WebAPI.Classes;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;

namespace DiGi.GIS.PostgreSQL.WebAPI
{
    public static partial class Create
    {
        public static GISPostgreSQLWebAPIManager? GISPostgreSQLWebAPIManager()
        {
            IServiceProvider serviceProvider = ServiceProvider();
            if (serviceProvider is null)
            {
                return null;
            }

            return new GISPostgreSQLWebAPIManager(serviceProvider?.GetRequiredService<IHttpClientFactory>());
        }
    }
}