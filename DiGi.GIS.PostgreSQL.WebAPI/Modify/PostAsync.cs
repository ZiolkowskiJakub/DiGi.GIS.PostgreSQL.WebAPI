using DiGi.GIS.Classes;
using DiGi.GIS.PostgreSQL.WebAPI.Classes;
using DiGi.WebAPI.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DiGi.GIS.PostgreSQL.WebAPI
{
    public static partial class Modify
    {
        public static async Task<bool> PostAsync(this GISPostgreSQLWebAPIManager? gISPostgreSQLWebAPIManager, IEnumerable<AdministrativeAreal2D>? administrativeAreal2Ds, PostOptions? postOptions = null)
        {
            if (gISPostgreSQLWebAPIManager is null || administrativeAreal2Ds is null)
            {
                return false;
            }

            HttpClient? httpClient = gISPostgreSQLWebAPIManager.CreateHttpClient<AdministrativeAreal2DController>(nameof(AdministrativeAreal2DController.UpdateItemsAsync), out string? path);
            if (httpClient is null || string.IsNullOrWhiteSpace(path))
            {
                return false;
            }

            return await PostAsync(httpClient, path, Core.Convert.ToSystem_String(administrativeAreal2Ds), postOptions);
        }

        public static async Task<bool> PostAsync(this GISPostgreSQLWebAPIManager? gISPostgreSQLWebAPIManager, AdministrativeAreal2D? administrativeAreal2D, PostOptions? postOptions = null)
        {
            if (gISPostgreSQLWebAPIManager is null || administrativeAreal2D is null)
            {
                return false;
            }

            HttpClient? httpClient = gISPostgreSQLWebAPIManager.CreateHttpClient<AdministrativeAreal2DController>(nameof(AdministrativeAreal2DController.UpdateItemAsync), out string? path);
            if (httpClient is null || string.IsNullOrWhiteSpace(path))
            {
                return false;
            }

            return await PostAsync(httpClient, path, Core.Convert.ToSystem_String(administrativeAreal2D), postOptions);
        }

        public static async Task<bool> PostAsync(this GISPostgreSQLWebAPIManager? gISPostgreSQLWebAPIManager, IEnumerable<Building2D>? building2Ds, string? code = null, PostOptions? postOptions = null)
        {
            if (gISPostgreSQLWebAPIManager is null || building2Ds is null)
            {
                return false;
            }

            HttpClient? httpClient = gISPostgreSQLWebAPIManager.CreateHttpClient<Building2DController>(nameof(Building2DController.UpdateItemsAsync), out string? path);
            if (httpClient is null || string.IsNullOrWhiteSpace(path))
            {
                return false;
            }

            UrlBuilder urlBuilder = new(path);
            urlBuilder.AddParameter("code", code);

            return await PostAsync(httpClient, urlBuilder, Core.Convert.ToSystem_String(building2Ds), postOptions);
        }

        public static async Task<bool> PostAsync(this GISPostgreSQLWebAPIManager? gISPostgreSQLWebAPIManager, Building2D? building2D, string? code = null, PostOptions? postOptions = null)
        {
            if (gISPostgreSQLWebAPIManager is null || building2D is null)
            {
                return false;
            }

            HttpClient? httpClient = gISPostgreSQLWebAPIManager.CreateHttpClient<AdministrativeAreal2DController>(nameof(Building2DController.UpdateItemAsync), out string? path);
            if (httpClient is null || string.IsNullOrWhiteSpace(path))
            {
                return false;
            }

            UrlBuilder urlBuilder = new(path);
            urlBuilder.AddParameter("code", code);

            return await PostAsync(httpClient, urlBuilder, Core.Convert.ToSystem_String(building2D), postOptions);
        }

        public static async Task<bool> PostAsync(this HttpClient httpClient, string? requestUri, string? json, PostOptions? postOptions = null)
        {
            if (httpClient is null || string.IsNullOrWhiteSpace(requestUri) || json is null)
            {
                return false;
            }

            if (postOptions is null)
            {
                postOptions = new PostOptions();
            }

            using CancellationTokenSource cancellationTokenSource = new(postOptions.Delay);

            try
            {
                HttpContent? httpContent = await Create.HttpContent(json, cancellationTokenSource.Token);
                if(httpContent is null)
                {
                    Serilog.Modify.Log(Serilog.Enums.LogEventLevel.Error, "Content could not be created.");
                    return false;
                }

                // Execute request
                using (httpContent)
                {
                    HttpResponseMessage httpResponseMessage = await httpClient.PostAsync(requestUri, httpContent, cancellationTokenSource.Token).ConfigureAwait(false);

                    if (!httpResponseMessage.IsSuccessStatusCode)
                    {
                        string errorContent = await httpResponseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);
                        Exception exception = new($"Server returned {httpResponseMessage.StatusCode}: {httpResponseMessage.ReasonPhrase}. Details: {errorContent}");

                        Serilog.Modify.Log(exception, "Post request completed, but server could not process it.");
                        throw exception;
                    }
                }

                return true;
            }
            catch (OperationCanceledException operationCanceledException)
            {
                if (cancellationTokenSource.IsCancellationRequested)
                {
                    Serilog.Modify.Log(operationCanceledException, "Timeout: Manual {Delay}s limit reached.", postOptions.Delay.TotalSeconds);
                }
                else
                {
                    Serilog.Modify.Log(operationCanceledException, "Request cancelled by HttpClient (potential internal timeout or connection reset)");
                }
                throw;
            }
            catch (Exception exception)
            {
                Serilog.Modify.Log(exception, "Post request could not be completed.");
                throw;
            }
        }
    }
}