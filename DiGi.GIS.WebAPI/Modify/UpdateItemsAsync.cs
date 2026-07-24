using DiGi.Analytical.Building.Classes;
using DiGi.CityGML.Classes;
using DiGi.Core.Classes;
using DiGi.EPW.Classes;
using DiGi.GIS.Classes;
using DiGi.GIS.WebAPI.Classes;
using DiGi.WebAPI.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DiGi.GIS.WebAPI
{
    public static partial class Modify
    {
        /// <summary>
        /// Asynchronously updates a collection of administrative area items.
        /// </summary>
        /// <param name="GISWebAPIManager">The GIS PostgreSQL Web API manager instance.</param>
        /// <param name="administrativeAreal2Ds">A collection of administrative area items to update.</param>
        /// <param name="postOptions">Optional configuration options for the POST request.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public static async Task<bool> UpdateItemsAsync(this GISWebAPIManager? GISWebAPIManager, IEnumerable<AdministrativeAreal2D>? administrativeAreal2Ds, PostOptions? postOptions = null)
        {
            if (GISWebAPIManager is null || administrativeAreal2Ds is null)
            {
                return false;
            }

            HttpClient? httpClient = GISWebAPIManager.CreateHttpClient<AdministrativeAreal2DController>(nameof(AdministrativeAreal2DController.UpdateItemsAsync), out string? path);
            if (httpClient is null || string.IsNullOrWhiteSpace(path))
            {
                return false;
            }

            return await UpdateItemsAsync(httpClient, path, Core.Convert.ToSystem_String(administrativeAreal2Ds), postOptions);
        }

        /// <summary>
        /// Updates a single administrative area item asynchronously.
        /// </summary>
        /// <param name="GISWebAPIManager">The GIS PostgreSQL Web API manager instance.</param>
        /// <param name="administrativeAreal2D">The administrative area item to be updated.</param>
        /// <param name="postOptions">Optional configuration options for the HTTP POST request.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public static async Task<bool> UpdateItemsAsync(this GISWebAPIManager? GISWebAPIManager, AdministrativeAreal2D? administrativeAreal2D, PostOptions? postOptions = null)
        {
            if (GISWebAPIManager is null || administrativeAreal2D is null)
            {
                return false;
            }

            HttpClient? httpClient = GISWebAPIManager.CreateHttpClient<AdministrativeAreal2DController>(nameof(AdministrativeAreal2DController.UpdateItemAsync), out string? path);
            if (httpClient is null || string.IsNullOrWhiteSpace(path))
            {
                return false;
            }

            return await UpdateItemsAsync(httpClient, path, Core.Convert.ToSystem_String(administrativeAreal2D), postOptions);
        }

        /// <summary>
        /// Asynchronously updates a collection of EPW files.
        /// </summary>
        /// <param name="GISWebAPIManager">The GIS PostgreSQL Web API manager instance.</param>
        /// <param name="ePWFiles">A collection of EPW files to update.</param>
        /// <param name="postOptions">Optional configuration options for the POST request.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public static async Task<bool> UpdateItemsAsync(this GISWebAPIManager? GISWebAPIManager, IEnumerable<EPWFile>? ePWFiles, PostOptions? postOptions = null)
        {
            if (GISWebAPIManager is null || ePWFiles is null)
            {
                return false;
            }

            HttpClient? httpClient = GISWebAPIManager.CreateHttpClient<EPWFileController>(nameof(EPWFileController.UpdateItemsAsync), out string? path);
            if (httpClient is null || string.IsNullOrWhiteSpace(path))
            {
                return false;
            }

            return await UpdateItemsAsync(httpClient, path, Core.Convert.ToSystem_String(ePWFiles), postOptions);
        }

        /// <summary>
        /// Updates multiple 2D building items asynchronously.
        /// </summary>
        /// <param name="GISWebAPIManager">The GIS PostgreSQL Web API manager instance.</param>
        /// <param name="building2Ds">A collection of <see cref="Building2D"/> items to be updated.</param>
        /// <param name="code">An optional code used for the update operation.</param>
        /// <param name="postOptions">Optional configuration options for the POST request.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public static async Task<bool> UpdateItemsAsync(this GISWebAPIManager? GISWebAPIManager, IEnumerable<Building2D>? building2Ds, string? code = null, PostOptions? postOptions = null)
        {
            if (GISWebAPIManager is null || building2Ds is null)
            {
                return false;
            }

            HttpClient? httpClient = GISWebAPIManager.CreateHttpClient<Building2DController>(nameof(Building2DController.UpdateItemsAsync), out string? path);
            if (httpClient is null || string.IsNullOrWhiteSpace(path))
            {
                return false;
            }

            UrlBuilder urlBuilder = new(path);
            urlBuilder.AddParameter("code", code);

            return await UpdateItemsAsync(httpClient, urlBuilder, Core.Convert.ToSystem_String(building2Ds), postOptions);
        }

        /// <summary>
        /// Asynchronously updates multiple ortho data items via the PostgreSQL Web API.
        /// </summary>
        /// <param name="GISWebAPIManager">The <see cref="GISWebAPIManager"/> instance used to perform the update operation.</param>
        /// <param name="ortoDatas">A collection of <see cref="OrtoDatas"/> items to be updated.</param>
        /// <param name="code">An optional code used to identify or filter the items for updating.</param>
        /// <param name="postOptions">Optional configuration options for the update request.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public static async Task<bool> UpdateItemsAsync(this GISWebAPIManager? GISWebAPIManager, IEnumerable<OrtoDatas>? ortoDatas, string? code = null, PostOptions? postOptions = null)
        {
            if (GISWebAPIManager is null || ortoDatas is null)
            {
                return false;
            }

            HttpClient? httpClient = GISWebAPIManager.CreateHttpClient<OrtoDatasController>(nameof(OrtoDatasController.UpdateItemsByCodeAsync), out string? path);
            if (httpClient is null || string.IsNullOrWhiteSpace(path))
            {
                return false;
            }

            UrlBuilder urlBuilder = new(path);
            urlBuilder.AddParameter("code", code);

            return await UpdateItemsAsync(httpClient, urlBuilder, Core.Convert.ToSystem_String(ortoDatas), postOptions);
        }

        /// <summary>
        /// Asynchronously updates multiple year built data items via the PostgreSQL Web API.
        /// </summary>
        /// <param name="GISWebAPIManager">The manager instance used to facilitate the web API communication.</param>
        /// <param name="yearBuiltDatas">A collection of <see cref="T:DiGi.GIS.Classes.YearBuiltData"/> objects to be updated.</param>
        /// <param name="code">An optional code identifier for the update request.</param>
        /// <param name="postOptions">Optional configuration options for the POST request.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public static async Task<bool> UpdateItemsAsync(this GISWebAPIManager? GISWebAPIManager, IEnumerable<YearBuiltData>? yearBuiltDatas, string? code = null, PostOptions? postOptions = null)
        {
            if (GISWebAPIManager is null || yearBuiltDatas is null)
            {
                return false;
            }

            HttpClient? httpClient = GISWebAPIManager.CreateHttpClient<YearBuiltDataController>(nameof(YearBuiltDataController.UpdateItemsAsync), out string? path);
            if (httpClient is null || string.IsNullOrWhiteSpace(path))
            {
                return false;
            }

            UrlBuilder urlBuilder = new(path);
            urlBuilder.AddParameter("code", code);

            return await UpdateItemsAsync(httpClient, urlBuilder, Core.Convert.ToSystem_String(yearBuiltDatas), postOptions);
        }

        /// <summary>
        /// Asynchronously updates multiple occupancy data items via the Web API.
        /// </summary>
        /// <param name="GISWebAPIManager">The <see cref="GISWebAPIManager"/> instance used to create the HTTP client for the request.</param>
        /// <param name="occupancyDatas">A collection of <see cref="OccupancyData"/> items to be updated.</param>
        /// <param name="code">An optional code associated with the update operation.</param>
        /// <param name="postOptions">Optional configuration settings for the HTTP POST request.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public static async Task<bool> UpdateItemsAsync(this GISWebAPIManager? GISWebAPIManager, IEnumerable<OccupancyData>? occupancyDatas, string? code = null, PostOptions? postOptions = null)
        {
            if (GISWebAPIManager is null || occupancyDatas is null)
            {
                return false;
            }

            HttpClient? httpClient = GISWebAPIManager.CreateHttpClient<OccupancyDataController>(nameof(OccupancyDataController.Building2DUpdateItemsAsync), out string? path);
            if (httpClient is null || string.IsNullOrWhiteSpace(path))
            {
                return false;
            }

            UrlBuilder urlBuilder = new(path);
            urlBuilder.AddParameter("code", code);

            return await UpdateItemsAsync(httpClient, urlBuilder, Core.Convert.ToSystem_String(occupancyDatas), postOptions);
        }

        /// <summary>
        /// Asynchronously updates multiple occupancy data items via the PostgreSQL Web API.
        /// </summary>
        /// <param name="GISWebAPIManager">The manager instance used to facilitate the API communication.</param>
        /// <param name="occupancyDatas">The collection of <see cref="OccupancyData"/> items to be updated.</param>
        /// <param name="postOptions">Optional configuration options for the POST request.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public static async Task<bool> UpdateItemsAsync(this GISWebAPIManager? GISWebAPIManager, IEnumerable<OccupancyData>? occupancyDatas, PostOptions? postOptions = null)
        {
            if (GISWebAPIManager is null || occupancyDatas is null)
            {
                return false;
            }

            HttpClient? httpClient = GISWebAPIManager.CreateHttpClient<OccupancyDataController>(nameof(OccupancyDataController.AdministrativeAreal2DUpdateItemsAsync), out string? path);
            if (httpClient is null || string.IsNullOrWhiteSpace(path))
            {
                return false;
            }

            UrlBuilder urlBuilder = new(path);

            return await UpdateItemsAsync(httpClient, urlBuilder, Core.Convert.ToSystem_String(occupancyDatas), postOptions);
        }

        /// <summary>
        /// Updates multiple ortho data items for a specific county.
        /// </summary>
        /// <param name="GISWebAPIManager">The <see cref="GISWebAPIManager"/> instance used to perform the update operation.</param>
        /// <param name="ortoDatas">The collection of <see cref="OrtoDatas"/> items to be updated.</param>
        /// <param name="countyId">The unique identifier of the county for which the items are being updated.</param>
        /// <param name="postOptions">Optional configuration options for the HTTP POST request.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public static async Task<bool> UpdateItemsAsync(this GISWebAPIManager? GISWebAPIManager, IEnumerable<OrtoDatas>? ortoDatas, int countyId, PostOptions? postOptions = null)
        {
            if (GISWebAPIManager is null || ortoDatas is null)
            {
                return false;
            }

            HttpClient? httpClient = GISWebAPIManager.CreateHttpClient<OrtoDatasController>(nameof(OrtoDatasController.UpdateItemsByCountyIdAsync), out string? path);
            if (httpClient is null || string.IsNullOrWhiteSpace(path))
            {
                return false;
            }

            UrlBuilder urlBuilder = new(path);
            urlBuilder.AddParameter("countyid", countyId);

            return await UpdateItemsAsync(httpClient, urlBuilder, Core.Convert.ToSystem_String(ortoDatas), postOptions);
        }

        /// <summary>
        /// Asynchronously updates building items in the PostgreSQL GIS database via the web API.
        /// </summary>
        /// <param name="GISWebAPIManager">The manager instance used to handle communication with the PostgreSQL Web API.</param>
        /// <param name="building2D">The <see cref="Building2D"/> object containing the data to be updated.</param>
        /// <param name="code">An optional identification code associated with the update request.</param>
        /// <param name="postOptions">Optional configuration settings for the HTTP POST request.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public static async Task<bool> UpdateItemsAsync(this GISWebAPIManager? GISWebAPIManager, Building2D? building2D, string? code = null, PostOptions? postOptions = null)
        {
            if (GISWebAPIManager is null || building2D is null)
            {
                return false;
            }

            HttpClient? httpClient = GISWebAPIManager.CreateHttpClient<Building2DController>(nameof(Building2DController.UpdateItemAsync), out string? path);
            if (httpClient is null || string.IsNullOrWhiteSpace(path))
            {
                return false;
            }

            UrlBuilder urlBuilder = new(path);
            urlBuilder.AddParameter("code", code);

            return await UpdateItemsAsync(httpClient, urlBuilder, Core.Convert.ToSystem_String(building2D), postOptions);
        }

        /// <summary>
        /// Asynchronously updates items from the specified file system path.
        /// </summary>
        /// <param name="GISWebAPIManager">The GIS PostgreSQL Web API manager instance.</param>
        /// <param name="path">The file system path to the source data files.</param>
        /// <param name="oT_ADJA_A">Indicates whether items with the OT_ADJA_A suffix should be updated. Defaults to <c>true</c>.</param>
        /// <param name="oT_ADMS_A">Indicates whether items with the OT_ADMS_A suffix should be updated. Defaults to <c>true</c>.</param>
        /// <param name="oT_BUBD_A">Indicates whether items with the OT_BUBD_A suffix should be updated. Defaults to <c>true</c>.</param>
        /// <param name="serializableObjectsPostOptions">The options used for serializing objects during the POST request.</param>
        /// <param name="progress">The progress reporter for reporting progress updates.</param>
        /// <param name="cancellationToken">The cancellation token to observe.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public static async Task<bool> UpdateItemsAsync(this GISWebAPIManager? GISWebAPIManager, string? path, bool oT_ADJA_A = true, bool oT_ADMS_A = true, bool oT_BUBD_A = true, SerializableObjectsPostOptions? serializableObjectsPostOptions = null, IProgress<long>? progress = default, CancellationToken? cancellationToken = default)
        {
            // Use the provided cancellationToken or a default one to avoid null checks later
            CancellationToken cancellationToken_Temp = cancellationToken ?? CancellationToken.None;

            if (string.IsNullOrWhiteSpace(path) || !File.Exists(path))
            {
                return false;
            }

            List<string> sufixes = [];
            if (oT_ADJA_A)
            {
                sufixes.Add(GIS.Constants.FileNameSufix.OT_ADJA_A);
            }

            if (oT_ADMS_A)
            {
                sufixes.Add(GIS.Constants.FileNameSufix.OT_ADMS_A);
            }

            if (oT_BUBD_A)
            {
                sufixes.Add(GIS.Constants.FileNameSufix.OT_BUBD_A);
            }

            if (sufixes.Count == 0)
            {
                return false;
            }

            serializableObjectsPostOptions ??= new SerializableObjectsPostOptions();

            LongProgressWrapper longProgressWrapper = new(progress);

            // Using statement ensures ZipArchive and the underlying FileStream are closed
            // even if OperationCanceledException is thrown.
            using ZipArchive zipArchive = ZipFile.OpenRead(path);

            foreach (ZipArchiveEntry zipArchiveEntry in zipArchive.Entries)
            {
                // Check for cancellation at the start of each major iteration
                cancellationToken_Temp.ThrowIfCancellationRequested();

                using Stream entryStream = zipArchiveEntry.Open();

                if (entryStream is not DeflateStream deflateStream)
                {
                    continue;
                }

                using ZipArchive zipArchive_ZipArchieve = new(deflateStream);

                foreach (ZipArchiveEntry zipArchiveEntry_Zip in zipArchive_ZipArchieve.Entries)
                {
                    cancellationToken_Temp.ThrowIfCancellationRequested();

                    using Stream nestedEntryStream = zipArchiveEntry_Zip.Open();

                    if (nestedEntryStream is not DeflateStream deflateStream_Zip)
                    {
                        continue;
                    }

                    // Added 'using' here to ensure nested ZipArchive is disposed correctly
                    using ZipArchive zipArchive_Files = new(deflateStream_Zip);

                    GISModel gISModel = new(System.IO.Path.GetFileNameWithoutExtension(zipArchiveEntry_Zip.Name), new DirectorySource(zipArchiveEntry_Zip.FullName));

                    foreach (ZipArchiveEntry zipArchiveEntry_File in zipArchive_Files.Entries)
                    {
                        if (sufixes.FindIndex(zipArchiveEntry_File.Name.EndsWith) != -1)
                        {
                            // Ensure the stream from Open() is disposed or handled by AddRange
                            using Stream fileStream = zipArchiveEntry_File.Open();

                            GIS.Modify.AddRange(gISModel, fileStream);
                        }
                    }

                    List<AdministrativeAreal2D>? administrativeAreal2Ds = gISModel.GetObjects<AdministrativeAreal2D>();
                    if (administrativeAreal2Ds is not null && administrativeAreal2Ds.Count > 0)
                    {
                        cancellationToken_Temp.ThrowIfCancellationRequested();

                        // Passing the cancellationToken to the nested async call
                        if (await UpdateItemsAsync(GISWebAPIManager, administrativeAreal2Ds, serializableObjectsPostOptions))
                        {
                            longProgressWrapper.Increment(administrativeAreal2Ds.Count);
                        }
                    }

                    List<Building2D>? building2Ds = gISModel.GetObjects<Building2D>();
                    if (building2Ds is not null && building2Ds.Count > 0)
                    {
                        cancellationToken_Temp.ThrowIfCancellationRequested();

                        string? code = gISModel!.Reference;
                        if (!string.IsNullOrWhiteSpace(code))
                        {
                            code = code.ToUpper();
                            int index = code.IndexOf('_');
                            if (index != -1)
                            {
                                code = code[..index];
                            }
                        }

                        MemorySizeSplitter<Building2D> memorySizeSplitter = new(building2Ds);
                        while ((building2Ds = memorySizeSplitter.Next(serializableObjectsPostOptions.BatchMemorySize)) is not null)
                        {
                            // Passing the cancellationToken to the nested async call
                            if (await UpdateItemsAsync(GISWebAPIManager, building2Ds, code, serializableObjectsPostOptions))
                            {
                                longProgressWrapper.Increment(building2Ds.Count);
                            }
                        }
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// Asynchronously updates items by sending a JSON payload to the specified request URI.
        /// </summary>
        /// <param name="httpClient">The <see cref="System.Net.Http.HttpClient"/> used to perform the network request.</param>
        /// <param name="requestUri">The target URI where the update request is sent.</param>
        /// <param name="json">The JSON string containing the data to be updated.</param>
        /// <param name="postOptions">Optional <see cref="DiGi.WebAPI.Classes.PostOptions"/> used to configure the operation, such as specifying a delay.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public static async Task<bool> UpdateItemsAsync(this HttpClient httpClient, string? requestUri, string? json, PostOptions? postOptions = null)
        {
            if (json is null)
            {
                return false;
            }

            return await UpdateItemsAsync(httpClient, requestUri, Encoding.UTF8.GetBytes(json), postOptions);
        }

        /// <summary>
        /// Asynchronously updates items by sending an already-serialized UTF-8 JSON payload to the specified request URI.
        /// <para>Preferred over the string overload on bulk paths: the payload never has to be materialized as a UTF-16 string and re-encoded back to UTF-8.</para>
        /// </summary>
        /// <param name="httpClient">The <see cref="System.Net.Http.HttpClient"/> used to perform the network request.</param>
        /// <param name="requestUri">The target URI where the update request is sent.</param>
        /// <param name="utf8Json">The UTF-8 encoded JSON payload containing the data to be updated.</param>
        /// <param name="postOptions">Optional <see cref="DiGi.WebAPI.Classes.PostOptions"/> used to configure the operation, such as specifying a delay.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public static async Task<bool> UpdateItemsAsync(this HttpClient httpClient, string? requestUri, byte[]? utf8Json, PostOptions? postOptions = null)
        {
            if (httpClient is null || string.IsNullOrWhiteSpace(requestUri) || utf8Json is null)
            {
                return false;
            }

            postOptions ??= new PostOptions();

            try
            {
                Serilog.Modify.Log("Executing request started");

                // Passed as a factory, not an instance: sending consumes and disposes the content, so a
                // retry has to gzip the payload again rather than resend an already-drained stream.
                PostResponse postResponse = await DiGi.WebAPI.Modify.PostAsync(httpClient, requestUri, async () => await Create.HttpContent(utf8Json, CancellationToken.None), postOptions);

                Serilog.Modify.Log("Executing request ended. Response result {result}", postResponse.Succeeded);

                return postResponse.Succeeded;
            }
            catch (OperationCanceledException operationCanceledException)
            {
                Serilog.Modify.Log(operationCanceledException, string.Format("Timeout: {0}s limit reached, or the request was cancelled.", postOptions.Delay.TotalSeconds));
                throw;
            }
            catch (Exception exception)
            {
                Serilog.Modify.Log(exception, "Post request could not be completed.");
                throw;
            }
        }

        /// <summary>
        /// Asynchronously updates multiple building models via the PostgreSQL Web API.
        /// </summary>
        /// <param name="GISWebAPIManager">The <see cref="GISWebAPIManager"/> instance used to perform the update operation.</param>
        /// <param name="buildingModels">A collection of <see cref="DiGi.Analytical.Building.Classes.BuildingModel"/> items to be updated.</param>
        /// <param name="postOptions">Optional configuration options for the POST request.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public static async Task<bool> UpdateItemsAsync(this GISWebAPIManager? GISWebAPIManager, IEnumerable<BuildingModel>? buildingModels, PostOptions? postOptions = null)
        {
            if (GISWebAPIManager is null || buildingModels is null)
            {
                return false;
            }

            HttpClient? httpClient = GISWebAPIManager.CreateHttpClient<BuildingModelController>(nameof(BuildingModelController.UpdateItemsAsync), out string? path);
            if (httpClient is null || string.IsNullOrWhiteSpace(path))
            {
                return false;
            }

            return await UpdateItemsAsync(httpClient, path, Core.Convert.ToSystem_String(buildingModels), postOptions);
        }

        /// <summary>
        /// Asynchronously updates multiple building items via the PostgreSQL Web API.
        /// </summary>
        /// <param name="GISWebAPIManager">The <see cref="GISWebAPIManager"/> instance used to perform the update operation.</param>
        /// <param name="buildings">A collection of <see cref="DiGi.CityGML.Classes.Building"/> items to be updated.</param>
        /// <param name="code">An optional code used for the update operation.</param>
        /// <param name="postOptions">Optional configuration options for the POST request.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public static async Task<bool> UpdateItemsAsync(this GISWebAPIManager? GISWebAPIManager, IEnumerable<Building>? buildings, string? code = null, PostOptions? postOptions = null)
        {
            if (buildings is null)
            {
                return false;
            }

            return await UpdateItemsAsync(GISWebAPIManager, Core.Convert.ToSystem_Bytes(buildings), code, postOptions);
        }

        /// <summary>
        /// Asynchronously updates building items from an already-serialized UTF-8 JSON payload via the PostgreSQL Web API.
        /// <para>Used by <see cref="Classes.BuildingsPostTask"/>, where the batch was serialized once while being sized, so it must not be serialized again here.</para>
        /// </summary>
        /// <param name="GISWebAPIManager">The <see cref="GISWebAPIManager"/> instance used to perform the update operation.</param>
        /// <param name="utf8Json">The UTF-8 encoded JSON array of <see cref="DiGi.CityGML.Classes.Building"/> items to be updated.</param>
        /// <param name="code">An optional code used for the update operation.</param>
        /// <param name="postOptions">Optional configuration options for the POST request.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public static async Task<bool> UpdateItemsAsync(this GISWebAPIManager? GISWebAPIManager, byte[]? utf8Json, string? code = null, PostOptions? postOptions = null)
        {
            if (GISWebAPIManager is null || utf8Json is null)
            {
                return false;
            }

            HttpClient? httpClient = GISWebAPIManager.CreateHttpClient<BuildingController>(nameof(BuildingController.UpdateItemsAsync), out string? path);
            if (httpClient is null || string.IsNullOrWhiteSpace(path))
            {
                return false;
            }

            UrlBuilder urlBuilder = new(path);
            urlBuilder.AddParameter("code", code);

            return await UpdateItemsAsync(httpClient, urlBuilder, utf8Json, postOptions);
        }
    }
}