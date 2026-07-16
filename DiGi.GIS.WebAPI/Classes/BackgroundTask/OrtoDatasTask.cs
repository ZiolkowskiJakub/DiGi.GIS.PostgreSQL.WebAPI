using DiGi.Core.Classes;
using DiGi.GIS.Classes;
using DiGi.GIS.PostgreSQL;
using DiGi.GIS.PostgreSQL.Classes;
using DiGi.GIS.PostgreSQL.Interfaces;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace DiGi.GIS.WebAPI.Classes
{
    /// <summary>
    /// Handles the background processing of orthophoto data within the GIS PostgreSQL context.
    /// </summary>
    public class OrtoDatasTask : ReportableBackgroundTask<long>, IGISPostgreSQLObject
    {
        private readonly GISPostgreSQLConverterManager? gISPostgreSQLConverterManager;
        private readonly GISWebAPIManager? GISWebAPIManager;

        /// <summary>
        /// Initializes a new instance of the OrtoDatasTask class.
        /// </summary>
        /// <param name="GISWebAPIManager">The manager responsible for handling GIS PostgreSQL Web API operations.</param>
        /// <param name="gISPostgreSQLConverterManager">The manager that handles conversion processes for GIS data within a PostgreSQL database context.</param>
        public OrtoDatasTask(GISWebAPIManager? GISWebAPIManager, GISPostgreSQLConverterManager? gISPostgreSQLConverterManager)
        {
            this.GISWebAPIManager = GISWebAPIManager ?? throw new ArgumentNullException(nameof(GISWebAPIManager));
            this.gISPostgreSQLConverterManager = gISPostgreSQLConverterManager ?? throw new ArgumentNullException(nameof(gISPostgreSQLConverterManager));
        }

        protected override async Task<bool> ExecuteAsync(IProgress<long> progress, CancellationToken cancellationToken)
        {
            Serilog.Modify.Log("{Type}:{Name} started", nameof(OrtoDatasTask), nameof(ExecuteAsync));

            if (GISWebAPIManager is null)
            {
                Serilog.Modify.Log(Serilog.Enums.LogEventLevel.Error, "GISWebAPIManager cannot be null");
                return false;
            }

            OrtoDatasPostgreSQLConverter? ortoDatasPostgreSQLConverter = gISPostgreSQLConverterManager?.GetPostgreSQLConverter<OrtoDatasPostgreSQLConverter>();
            if (ortoDatasPostgreSQLConverter is null)
            {
                Serilog.Modify.Log(Serilog.Enums.LogEventLevel.Error, "OrtoDatasPostgreSQLConverter cannot be null");
                return false;
            }

            Building2DPostgreSQLConverter? building2DPostgreSQLConverter = gISPostgreSQLConverterManager?.GetPostgreSQLConverter<Building2DPostgreSQLConverter>();
            if (building2DPostgreSQLConverter is null)
            {
                Serilog.Modify.Log(Serilog.Enums.LogEventLevel.Error, "Building2DPostgreSQLConverter cannot be null");
                return false;
            }

            HttpClient? httpClient_Geoportal = Create.HttpClient_Geoportal(GISWebAPIManager);
            if (httpClient_Geoportal is null)
            {
                Serilog.Modify.Log(Serilog.Enums.LogEventLevel.Error, "Geoportal HttpClient cannot be null");
                return false;
            }

            cancellationToken.ThrowIfCancellationRequested();

            int count = 5;
            Serilog.Modify.Log("Items count: {Count}", count);

            List<Building2DReference>? building2DReferences = await ortoDatasPostgreSQLConverter.GetNextBuilding2DReferencesAsync(count);
            if (building2DReferences is null)
            {
                Serilog.Modify.Log(Serilog.Enums.LogEventLevel.Warning, "No Building2DReferences found in database");
                return false;
            }

            LongProgressWrapper? longProgressWrapper = Core.Create.LongProgressWrapper(progress);

            OrtoDatasBuilding2DOptions ortoDatasBuilding2DOptions = new();

            while (building2DReferences is not null && building2DReferences.Count > 0)
            {
                int? countyId = building2DReferences[0].CountyId;

                Core.Query.Filter(building2DReferences, x => x?.CountyId == countyId, out List<Building2DReference>? building2DReferences_In, out List<Building2DReference>? building2DReferences_Out);
                building2DReferences = building2DReferences_Out ?? [];

                List<GIS.Classes.OrtoDatas> ortoDatasList = [];

                if (building2DReferences_In != null && building2DReferences_In.Count != 0 && countyId is not null && countyId.HasValue)
                {
                    try
                    {
                        Serilog.Modify.Log("PostgreSQL Building2Ds extraction starting");

                        List<PostgreSQL.Classes.Building2D>? building2Ds_PostgreSQL = await building2DPostgreSQLConverter.GetBuilding2DsByBuilding2DReferences(building2DReferences_In);
                        if (building2Ds_PostgreSQL is null || building2Ds_PostgreSQL.Count == 0)
                        {
                            Serilog.Modify.Log(Serilog.Enums.LogEventLevel.Warning, "No PostgreSQL Building2Ds found");
                            continue;
                        }

                        Serilog.Modify.Log("PostgreSQL Building2Ds extraction ended");

                        foreach (PostgreSQL.Classes.Building2D building2D_PostgreSQL in building2Ds_PostgreSQL)
                        {
                            GIS.Classes.Building2D? building2D = building2D_PostgreSQL.ToDiGi();
                            if (building2D is null)
                            {
                                continue;
                            }

                            GIS.Classes.OrtoDatas? ortoDatas = await GIS.Create.OrtoDatas(httpClient_Geoportal, building2D, ortoDatasBuilding2DOptions.Years, ortoDatasBuilding2DOptions.Offset, ortoDatasBuilding2DOptions.Width, ortoDatasBuilding2DOptions.Reduce, squared: true);
                            if (ortoDatas is null)
                            {
                                continue;
                            }

                            ortoDatasList.Add(ortoDatas);
                        }

                        Serilog.Modify.Log("OrtoDatas extracted {Count}", ortoDatasList.Count);
                    }
                    catch (OperationCanceledException)
                    {
                        return false;
                    }
                    catch (HttpRequestException)
                    {
                        continue;
                    }
                    catch (Exception)
                    {
                        return false;
                    }
                }

                Serilog.Modify.Log("OrtoDatas updating starting");

                List<PostgreSQL.Classes.OrtoDatas> ortoDatasList_PostgreSQL = [];
                foreach (GIS.Classes.OrtoDatas ortoDatas in ortoDatasList)
                {
                    if (ortoDatas?.ToPostgreSQL(countyId) is PostgreSQL.Classes.OrtoDatas ortoDatas_PostgreSQL)
                    {
                        ortoDatasList_PostgreSQL.Add(ortoDatas_PostgreSQL);
                    }
                }

                await ortoDatasPostgreSQLConverter.UpdateAsync(ortoDatasList_PostgreSQL);

                longProgressWrapper?.Increment(ortoDatasList_PostgreSQL.Count);

                Serilog.Modify.Log("OrtoDatas updating ended");

                cancellationToken.ThrowIfCancellationRequested();

                Serilog.Modify.Log("Getting new Building2DReferences");

                building2DReferences = await ortoDatasPostgreSQLConverter.GetNextBuilding2DReferencesAsync(count);

                Serilog.Modify.Log("Getting new Building2DReferences ended. Count: {Count}", building2DReferences?.Count ?? 0);
            }

            return true;
        }
    }
}