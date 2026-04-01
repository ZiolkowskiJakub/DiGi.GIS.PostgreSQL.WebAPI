using DiGi.Core.Classes;
using DiGi.GIS.Classes;
using DiGi.GIS.PostgreSQL.Classes;
using DiGi.WebAPI.Classes;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace DiGi.GIS.PostgreSQL.WebAPI.Classes
{
    public class OrtoDatasFromDatabasePostTask : OrtoDatasPostTask
    {
        public OrtoDatasFromDatabasePostTask(GISPostgreSQLWebAPIManager gISPostgreSQLWebAPIManager)
            : base(gISPostgreSQLWebAPIManager)
        {
        }

        protected override async Task<bool> ExecuteAsync(IProgress<long> progress, CancellationToken cancellationToken)
        {
            HttpClient? httpClient_OrtoDatas = GISPostgreSQLWebAPIManager.CreateHttpClient<OrtoDatasController>(nameof(OrtoDatasController.NextLocationReferences), out string? path_OrtoDatas);
            if (httpClient_OrtoDatas is null || string.IsNullOrWhiteSpace(path_OrtoDatas))
            {
                return false;
            }

            string requestUri_OrtoDatas = new UrlBuilder(path_OrtoDatas).AddParameter("count", 100).ToString();

            HttpClient? httpClient_Building2D = GISPostgreSQLWebAPIManager.CreateHttpClient<Building2DController>(nameof(Building2DController.GetItemsByLocationReferences), out string? path_Building2D);
            if (httpClient_Building2D is null || string.IsNullOrWhiteSpace(path_Building2D))
            {
                return false;
            }

            string requestUri_Building2D = new UrlBuilder(path_Building2D).ToString();

            PostOptions postOptions = new() { RequestResult = true };

            using CancellationTokenSource cancellationTokenSource = new(postOptions.Delay);

            PostResponse<List<LocationReference>?> postResponse_LocationReferences = await DiGi.WebAPI.Modify.PostAsync<List<LocationReference>>(httpClient_OrtoDatas, requestUri_OrtoDatas, null, postOptions);
            if (postResponse_LocationReferences is null || !postResponse_LocationReferences.Succeeded)
            {
                return false;
            }

            LongProgressWrapper? longProgressWrapper = Core.Create.LongProgressWrapper(progress);

            while (postResponse_LocationReferences is not null && postResponse_LocationReferences.Succeeded && postResponse_LocationReferences.Result is List<LocationReference> locationReferences && locationReferences.Count > 0)
            {
                cancellationToken.ThrowIfCancellationRequested();

                while (locationReferences.Count > 0)
                {
                    cancellationToken.ThrowIfCancellationRequested();

                    int? countyId = locationReferences[0].CountyId;

                    Core.Query.Filter(locationReferences, x => x?.CountyId == countyId, out List<LocationReference>? locationReferences_In, out List<LocationReference>? locationReferences_Out);
                    locationReferences = locationReferences_Out ?? [];

                    if (locationReferences_In != null && locationReferences_In.Count != 0 && countyId is not null && countyId.HasValue)
                    {
                        HttpContent? httpContent = await Create.HttpContent(locationReferences_In, cancellationTokenSource.Token);
                        if (httpContent is null)
                        {
                            return false;
                        }

                        PostResponse<List<GIS.Classes.Building2D>?> postResponse_Building2Ds = await DiGi.WebAPI.Modify.PostAsync<List<GIS.Classes.Building2D>>(httpClient_Building2D, requestUri_Building2D, httpContent, postOptions);
                        if (postResponse_Building2Ds is null || !postResponse_Building2Ds.Succeeded || postResponse_Building2Ds.Result is not List<GIS.Classes.Building2D> building2Ds || building2Ds.Count == 0)
                        {
                            continue;
                        }

                        OrtoDatasBuilding2DOptions ortoDatasBuilding2DOptions = new();

                        List<GIS.Classes.OrtoDatas> ortoDatasList = [];
                        foreach (GIS.Classes.Building2D building2D in building2Ds)
                        {
                            cancellationToken.ThrowIfCancellationRequested();

                            GIS.Classes.OrtoDatas? ortoDatas = await GIS.Create.OrtoDatas(building2D, ortoDatasBuilding2DOptions.Years, ortoDatasBuilding2DOptions.Offset, ortoDatasBuilding2DOptions.Width, ortoDatasBuilding2DOptions.Reduce, squared: true);
                            if (ortoDatas is null)
                            {
                                continue;
                            }

                            ortoDatasList.Add(ortoDatas);
                        }

                        bool succeeded = await ExecuteAsync(ortoDatasList, countyId.Value, longProgressWrapper, cancellationToken); //await GISPostgreSQLWebAPIManager.UpdateItemsAsync(ortoDatasList, countyId.Value, postOptions);
                        if (!succeeded)
                        {
                            return false;
                        }
                    }
                }

                postResponse_LocationReferences = await DiGi.WebAPI.Modify.PostAsync<List<LocationReference>>(httpClient_OrtoDatas, requestUri_OrtoDatas, null, postOptions);
            }

            return true;
        }
    }
}