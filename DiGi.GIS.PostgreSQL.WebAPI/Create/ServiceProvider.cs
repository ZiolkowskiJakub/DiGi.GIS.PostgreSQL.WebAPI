using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;

namespace DiGi.GIS.PostgreSQL.WebAPI
{
    public static partial class Create
    {
        /// <summary>
        /// Creates and configures a service provider with the registered services.
        /// </summary>
        /// <returns>An <see cref="IServiceProvider"/> containing the registered services.</returns>
        public static IServiceProvider ServiceProvider()
        {
            IServiceCollection serviceCollection = new ServiceCollection();

            serviceCollection.AddHttpClient(Constants.Name.Client, httpClient =>
            {
                httpClient.BaseAddress = Constants.Uri.BaseAddress;
                httpClient.DefaultRequestHeaders.Add("Accept", "application/json");

                httpClient.Timeout = TimeSpan.FromSeconds(60);
            })
            .ConfigurePrimaryHttpMessageHandler(() => new SocketsHttpHandler
            {
                MaxConnectionsPerServer = 100,
                PooledConnectionLifetime = TimeSpan.FromMinutes(5)
            });

            return serviceCollection.BuildServiceProvider();
        }
    }
}