using DiGi.GIS.PostgreSQL.WebAPI.Classes;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;

namespace DiGi.GIS.PostgreSQL.WebAPI
{
    public static partial class Create
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns>A task that represents the asynchronous operation.</returns>
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