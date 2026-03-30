using DiGi.GIS.Classes;
using DiGi.GIS.PostgreSQL.WebAPI.Classes;
using DiGi.WebAPI.Classes;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace DiGi.GIS.PostgreSQL.WebAPI
{
    public static partial class Modify
    {
        public static async Task<bool> UpdateItemsAsync(this GISPostgreSQLWebAPIManager? gISPostgreSQLWebAPIManager, IEnumerable<AdministrativeAreal2D>? administrativeAreal2Ds, PostOptions? postOptions = null)
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

            return await UpdateItemsAsync(httpClient, path, Core.Convert.ToSystem_String(administrativeAreal2Ds), postOptions);
        }

        public static async Task<bool> UpdateItemsAsync(this GISPostgreSQLWebAPIManager? gISPostgreSQLWebAPIManager, AdministrativeAreal2D? administrativeAreal2D, PostOptions? postOptions = null)
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

            return await UpdateItemsAsync(httpClient, path, Core.Convert.ToSystem_String(administrativeAreal2D), postOptions);
        }

        public static async Task<bool> UpdateItemsAsync(this GISPostgreSQLWebAPIManager? gISPostgreSQLWebAPIManager, IEnumerable<Building2D>? building2Ds, string? code = null, PostOptions? postOptions = null)
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

            return await UpdateItemsAsync(httpClient, urlBuilder, Core.Convert.ToSystem_String(building2Ds), postOptions);
        }

        public static async Task<bool> UpdateItemsAsync(this GISPostgreSQLWebAPIManager? gISPostgreSQLWebAPIManager, IEnumerable<OrtoDatas>? ortoDatas, string? code = null, PostOptions? postOptions = null)
        {
            if (gISPostgreSQLWebAPIManager is null || ortoDatas is null)
            {
                return false;
            }

            HttpClient? httpClient = gISPostgreSQLWebAPIManager.CreateHttpClient<OrtoDatasController>(nameof(OrtoDatasController.UpdateItemsByCodeAsync), out string? path);
            if (httpClient is null || string.IsNullOrWhiteSpace(path))
            {
                return false;
            }

            UrlBuilder urlBuilder = new(path);
            urlBuilder.AddParameter("code", code);

            return await UpdateItemsAsync(httpClient, urlBuilder, Core.Convert.ToSystem_String(ortoDatas), postOptions);
        }

        public static async Task<bool> UpdateItemsAsync(this GISPostgreSQLWebAPIManager? gISPostgreSQLWebAPIManager, IEnumerable<OrtoDatas>? ortoDatas, int countyId, PostOptions? postOptions = null)
        {
            if (gISPostgreSQLWebAPIManager is null || ortoDatas is null)
            {
                return false;
            }

            HttpClient? httpClient = gISPostgreSQLWebAPIManager.CreateHttpClient<OrtoDatasController>(nameof(OrtoDatasController.UpdateItemsByCodeAsync), out string? path);
            if (httpClient is null || string.IsNullOrWhiteSpace(path))
            {
                return false;
            }

            UrlBuilder urlBuilder = new(path);
            urlBuilder.AddParameter("countyid", countyId);

            return await UpdateItemsAsync(httpClient, urlBuilder, Core.Convert.ToSystem_String(ortoDatas), postOptions);
        }

        public static async Task<bool> UpdateItemsAsync(this GISPostgreSQLWebAPIManager? gISPostgreSQLWebAPIManager, Building2D? building2D, string? code = null, PostOptions? postOptions = null)
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

            return await UpdateItemsAsync(httpClient, urlBuilder, Core.Convert.ToSystem_String(building2D), postOptions);
        }

        public static async Task<bool> UpdateItemsAsync(this HttpClient httpClient, string? requestUri, string? json, PostOptions? postOptions = null)
        {
            if (httpClient is null || string.IsNullOrWhiteSpace(requestUri) || json is null)
            {
                return false;
            }

            postOptions ??= new PostOptions();

            using CancellationTokenSource cancellationTokenSource = new(postOptions.Delay);

            try
            {
                HttpContent? httpContent = await Create.HttpContent(json, cancellationTokenSource.Token);
                if (httpContent is null)
                {
                    Serilog.Modify.Log(Serilog.Enums.LogEventLevel.Error, "Content could not be created.");
                    return false;
                }

                using (httpContent)
                {
                    Serilog.Modify.Log("Executing request started");

                    PostResponse postResponse = await DiGi.WebAPI.Modify.PostAsync(httpClient, requestUri, httpContent, postOptions);

                    Serilog.Modify.Log("Executing request ended. Response result {result}", postResponse.Succeeded);

                    return postResponse.Succeeded;
                }
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