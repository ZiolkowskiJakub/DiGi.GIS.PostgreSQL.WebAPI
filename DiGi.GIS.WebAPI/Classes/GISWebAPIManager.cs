using Microsoft.AspNetCore.Mvc;
using System.Net.Http;

namespace DiGi.GIS.WebAPI.Classes
{
    /// <summary>
    /// Manages the creation and lifecycle of <see cref="HttpClient"/> instances used to interact with the GIS PostgreSQL Web API.
    /// </summary>
    public class GISWebAPIManager
    {
        private readonly IHttpClientFactory? httpClientFactory;

        /// <summary>
        /// Initializes a new instance of the GISWebAPIManager class.
        /// </summary>
        /// <param name="httpClientFactory">The HTTP client factory used to create and manage <see cref="HttpClient"/> instances.</param>
        public GISWebAPIManager(IHttpClientFactory? httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        /// <summary>
        /// Creates an HttpClient instance with the specified name.
        /// </summary>
        /// <param name="name">The unique identifier or name of the HTTP client to be created.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public HttpClient? CreateHttpClient(string name)
        {
            return httpClientFactory?.CreateClient(name);
        }

        /// <summary>
        /// Creates an <see cref="System.Net.Http.HttpClient"/> instance configured for the Web API, resolving the route associated with the specified controller type.
        /// </summary>
        /// <typeparam name="TControllerBase">The TControllerBase type parameter.</typeparam>
        /// <param name="route">The route.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public HttpClient? CreateHttpClient<TControllerBase>(out string? route) where TControllerBase : ControllerBase
        {
            route = DiGi.WebAPI.Query.Route<TControllerBase>();
            if (string.IsNullOrWhiteSpace(route))
            {
                return null;
            }

            return CreateHttpClient(Constants.Name.Client);
        }

        /// <summary>
        /// Creates an <see cref="System.Net.Http.HttpClient"/> instance configured for the specified controller's method and retrieves the corresponding API path.
        /// </summary>
        /// <typeparam name="TControllerBase">The type of the base controller used to resolve the endpoint path.</typeparam>
        /// <param name="methodName">The name of the method within the controller to resolve.</param>
        /// <param name="path">The path.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
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
