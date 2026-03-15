using Microsoft.Extensions.DependencyInjection;
using System;

namespace DiGi.GIS.PostgreSQL.WebAPI
{
    public static partial class Create
    {
        public static IServiceProvider ServiceProvider()
        {
            IServiceCollection serviceCollection = new ServiceCollection();

            // Rejestracja nazwanego klienta
            serviceCollection.AddHttpClient(Constants.Name.Client, httpClient =>
            {
                httpClient.BaseAddress = Constants.Uri.BaseAddress;
                httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
                httpClient.Timeout = TimeSpan.FromSeconds(5);
            });

            return serviceCollection.BuildServiceProvider();
        }
    }
}