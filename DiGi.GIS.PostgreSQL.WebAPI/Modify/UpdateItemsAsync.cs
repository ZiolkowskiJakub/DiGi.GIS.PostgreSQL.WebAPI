using DiGi.Core.Classes;
using DiGi.GIS.Classes;
using DiGi.GIS.PostgreSQL.WebAPI.Classes;
using DiGi.WebAPI.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
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

        public static async Task<bool> UpdateItemsAsync(this GISPostgreSQLWebAPIManager? gISPostgreSQLWebAPIManager, IEnumerable<YearBuiltData>? yearBuiltData, string? code = null, PostOptions? postOptions = null)
        {
            if (gISPostgreSQLWebAPIManager is null || yearBuiltData is null)
            {
                return false;
            }

            HttpClient? httpClient = gISPostgreSQLWebAPIManager.CreateHttpClient<YearBuiltDataController>(nameof(YearBuiltDataController.UpdateItemsAsync), out string? path);
            if (httpClient is null || string.IsNullOrWhiteSpace(path))
            {
                return false;
            }

            UrlBuilder urlBuilder = new(path);
            urlBuilder.AddParameter("code", code);

            return await UpdateItemsAsync(httpClient, urlBuilder, Core.Convert.ToSystem_String(yearBuiltData), postOptions);
        }

        public static async Task<bool> UpdateItemsAsync(this GISPostgreSQLWebAPIManager? gISPostgreSQLWebAPIManager, IEnumerable<OrtoDatas>? ortoDatas, int countyId, PostOptions? postOptions = null)
        {
            if (gISPostgreSQLWebAPIManager is null || ortoDatas is null)
            {
                return false;
            }

            HttpClient? httpClient = gISPostgreSQLWebAPIManager.CreateHttpClient<OrtoDatasController>(nameof(OrtoDatasController.UpdateItemsByCountyIdAsync), out string? path);
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

        public static async Task<bool> UpdateItemsAsync(this GISPostgreSQLWebAPIManager? gISPostgreSQLWebAPIManager, string? path, bool oT_ADJA_A = true, bool oT_ADMS_A = true, bool oT_BUBD_A = true, SerializableObjectsPostOptions? serializableObjectsPostOptions = null, IProgress<long>? progress = default, CancellationToken? cancellationToken = default)
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

            LongProgressWrapper longProgressWrapper = new (progress);

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
                        if (await UpdateItemsAsync(gISPostgreSQLWebAPIManager, administrativeAreal2Ds, serializableObjectsPostOptions))
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
                            if (await UpdateItemsAsync(gISPostgreSQLWebAPIManager, building2Ds, code, serializableObjectsPostOptions))
                            {
                                longProgressWrapper.Increment(building2Ds.Count);
                            }
                        }
                    }
                }
            }

            return true;
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
                    Serilog.Modify.Log(operationCanceledException, string.Format("Timeout: Manual {0}s limit reached.", postOptions.Delay.TotalSeconds));
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