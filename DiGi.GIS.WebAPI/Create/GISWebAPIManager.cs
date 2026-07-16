using DiGi.GIS.WebAPI.Classes;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;

namespace DiGi.GIS.WebAPI
{
    public static partial class Create
    {
        /// <summary>
        /// Creates a new instance of the GISWebAPIManager class.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public static GISWebAPIManager? GISWebAPIManager()
        {
            IServiceProvider serviceProvider = ServiceProvider();
            if (serviceProvider is null)
            {
                return null;
            }

            return new GISWebAPIManager(serviceProvider?.GetRequiredService<IHttpClientFactory>());
        }
    }
}