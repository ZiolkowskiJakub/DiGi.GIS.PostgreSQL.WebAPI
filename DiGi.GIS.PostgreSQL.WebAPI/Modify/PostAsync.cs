using DiGi.GIS.Classes;
using DiGi.GIS.PostgreSQL.WebAPI.Classes;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DiGi.GIS.PostgreSQL.WebAPI
{
    public static partial class Modify
    {
        public static async Task<bool> PostAsync(this GISPostgreSQLWebAPIManager? gISPostgreSQLWebAPIManager, IEnumerable<AdministrativeAreal2D>? administrativeAreal2Ds)
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

            return await PostAsync(httpClient, path, Core.Convert.ToSystem_String(administrativeAreal2Ds));
        }

        public static async Task<bool> PostAsync(this GISPostgreSQLWebAPIManager? gISPostgreSQLWebAPIManager, AdministrativeAreal2D? administrativeAreal2D)
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

            return await PostAsync(httpClient, path, Core.Convert.ToSystem_String(administrativeAreal2D));
        }

        public static async Task<bool> PostAsync(this GISPostgreSQLWebAPIManager? gISPostgreSQLWebAPIManager, IEnumerable<Building2D>? building2Ds)
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

            return await PostAsync(httpClient, path, Core.Convert.ToSystem_String(building2Ds));
        }

        public static async Task<bool> PostAsync(this GISPostgreSQLWebAPIManager? gISPostgreSQLWebAPIManager, Building2D? building2D)
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

            return await PostAsync(httpClient, path, Core.Convert.ToSystem_String(building2D));
        }

        public static async Task<bool> PostAsync(this HttpClient httpClient, string requestUri, string? json)
        {
            if (httpClient is null || string.IsNullOrWhiteSpace(requestUri) || json is null)
            {
                return false;
            }

            // Using a single, clean timeout management
            using CancellationTokenSource cancellationTokenSource = new(TimeSpan.FromSeconds(10));

            try
            {
                StringContent stringContent = new(json, Encoding.UTF8, "application/json");

                // PostAsync returns Task<HttpResponseMessage>
                HttpResponseMessage response = await httpClient.PostAsync(requestUri, stringContent, cancellationTokenSource.Token).ConfigureAwait(false);

                // Optional: If you want to know WHY it failed (e.g. 401 Unauthorized vs 500 Internal Error)
                // if (!response.IsSuccessStatusCode) { /* Log response.StatusCode */ }

                bool result = response.IsSuccessStatusCode;
                if(!result)
                {
                    throw new Exception(response.ReasonPhrase);
                }

                return result;
            }
            catch (OperationCanceledException)
            {
                // This catches both TaskCanceledException and manual cancellation via cts.Token
                // Log: "Request timed out or was cancelled."
                return false;
            }
        }
    }
}