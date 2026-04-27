using DiGi.GIS.PostgreSQL.Classes;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text.Json.Nodes;
using System.Threading;
using System.Threading.Tasks;

namespace DiGi.GIS.PostgreSQL.WebAPI.Classes
{
    [ApiController]
    [Route("gis/[controller]")]
    public class OccupancyDataController : DiGi.WebAPI.Classes.WebAPIController
    {
        private readonly AdministrativeAreal2DPostgreSQLConverter administrativeAreal2DPostgreSQLConverter;
        private readonly GISPostgreSQLWebAPIConfigurationFileWatcher gISPostgreSQLWebAPIConfigurationFileWatcher;
        
        private readonly Building2DOccupancyDataPostgreSQLConverter building2DOccupancyDataPostgreSQLConverter;
        private readonly AdministrativeAreal2DOccupancyDataPostgreSQLConverter administrativeAreal2DOccupancyDataPostgreSQLConverter;

        public OccupancyDataController(GISPostgreSQLWebAPIConfigurationFileWatcher gISPostgreSQLWebAPIConfigurationFileWatcher, Building2DOccupancyDataPostgreSQLConverter building2DOccupancyDataPostgreSQLConverter, AdministrativeAreal2DOccupancyDataPostgreSQLConverter administrativeAreal2DOccupancyDataPostgreSQLConverter, AdministrativeAreal2DPostgreSQLConverter administrativeAreal2DPostgreSQLConverter)
        {
            this.gISPostgreSQLWebAPIConfigurationFileWatcher = gISPostgreSQLWebAPIConfigurationFileWatcher;
            this.building2DOccupancyDataPostgreSQLConverter = building2DOccupancyDataPostgreSQLConverter;
            this.administrativeAreal2DPostgreSQLConverter = administrativeAreal2DPostgreSQLConverter;
            this.administrativeAreal2DOccupancyDataPostgreSQLConverter = administrativeAreal2DOccupancyDataPostgreSQLConverter;
        }

        [HttpPost("building2d/updateitems")]
        public async Task<IActionResult> UpdateItemsAsync([FromBody] JsonArray? jsonArray, [FromQuery(Name = "code")] string code)
        {
            Serilog.Modify.Log("{Type}:{Name} started", nameof(OccupancyDataController), nameof(UpdateItemsAsync));
            Serilog.Modify.Log("Code provided: {Code}", code ?? string.Empty);

            if (string.IsNullOrWhiteSpace(code))
            {
                Serilog.Modify.Log(Serilog.Enums.LogEventLevel.Error, "Code cannot be null or empty");
                return BadRequest();
            }

            if (!gISPostgreSQLWebAPIConfigurationFileWatcher.AllowUpdateYearBuiltData)
            {
                Serilog.Modify.Log(Serilog.Enums.LogEventLevel.Warning, "OccupancyData update not allowed");
                return BadRequest();
            }

            if (administrativeAreal2DPostgreSQLConverter is null)
            {
                Serilog.Modify.Log(Serilog.Enums.LogEventLevel.Error, "AdministrativeAreal2DPostgreSQLConverter is null");
                return BadRequest();
            }

            if (jsonArray is null || jsonArray.Count == 0)
            {
                Serilog.Modify.Log("No OccupancyData to update");
                return NoContent();
            }

            int? countyId = await administrativeAreal2DPostgreSQLConverter.GetIdByCodeAsync(code, Enums.AdministrativeArealType.County);
            if (countyId is null)
            {
                return BadRequest();
            }

            List<GIS.Classes.OccupancyData>? occupancyDatas_GIS = Core.Create.SerializableObjects<GIS.Classes.OccupancyData>(jsonArray);
            if (occupancyDatas_GIS is null)
            {
                Serilog.Modify.Log(Serilog.Enums.LogEventLevel.Error, "OccupancyDatas could not be converted from json");
                return BadRequest();
            }

            Serilog.Modify.Log("OccupancyDatas conversion to PostgreSQL started. OccupancyDatas count: {Count}", occupancyDatas_GIS.Count);

            int count = 0;

            List<Building2DOccupancyData> building2DOccupancyDatas_PostgreSQL = [];
            foreach (GIS.Classes.OccupancyData occupancyData_GIS in occupancyDatas_GIS)
            {
                if(Convert.ToPostgreSQL(occupancyData_GIS, countyId) is Building2DOccupancyData building2DOccupancyData_PostgreSQL)
                {
                    building2DOccupancyDatas_PostgreSQL.Add(building2DOccupancyData_PostgreSQL);
                }
            }

            if (building2DOccupancyDatas_PostgreSQL is null || building2DOccupancyDatas_PostgreSQL.Count == 0)
            {
                Serilog.Modify.Log("No Building2DOccupancyDatas PostgreSQL to update");
                return NoContent();
            }

            Serilog.Modify.Log("OccupancyDatas conversion to PostgreSQL ended. OccupancyDatas converted: {After}/{Before}", building2DOccupancyDatas_PostgreSQL.Count, count);

            Serilog.Modify.Log("Updating to database starting");

            HashSet<long>? ids = null;
            try
            {
                ids = await building2DOccupancyDataPostgreSQLConverter.UpdateAsync(building2DOccupancyDatas_PostgreSQL);
            }
            catch (Exception exception)
            {
                Serilog.Modify.Log(exception, "Database could not be updated");
            }

            if (ids is null || ids.Count == 0)
            {
                Serilog.Modify.Log(Serilog.Enums.LogEventLevel.Warning, "Updating to database ended but no Building2DOccupancyDatas have been updated");
            }
            else
            {
                Serilog.Modify.Log("Updating to database ended. Updated Building2DOccupancyDatas: {After}/{Before}", ids?.Count ?? 0, building2DOccupancyDatas_PostgreSQL.Count);
            }

            return Ok();
        }

        [HttpPost("administrativeareal2d/updateitems")]
        public async Task<IActionResult> UpdateItemsAsync([FromBody] JsonArray? jsonArray)
        {
            Serilog.Modify.Log("{Type}:{Name} started", nameof(OccupancyDataController), nameof(UpdateItemsAsync));

            if (!gISPostgreSQLWebAPIConfigurationFileWatcher.AllowUpdateYearBuiltData)
            {
                Serilog.Modify.Log(Serilog.Enums.LogEventLevel.Warning, "OccupancyData update not allowed");
                return BadRequest();
            }

            if (jsonArray is null || jsonArray.Count == 0)
            {
                Serilog.Modify.Log("No OccupancyData to update");
                return NoContent();
            }

            List<GIS.Classes.OccupancyData>? occupancyDatas_GIS = Core.Create.SerializableObjects<GIS.Classes.OccupancyData>(jsonArray);
            if (occupancyDatas_GIS is null)
            {
                Serilog.Modify.Log(Serilog.Enums.LogEventLevel.Error, "OccupancyDatas could not be converted from json");
                return BadRequest();
            }

            Serilog.Modify.Log("OccupancyDatas conversion to PostgreSQL started. OccupancyDatas count: {Count}", occupancyDatas_GIS.Count);

            int count = 0;

            List<AdministrativeAreal2DOccupancyData> administrativeAreal2DBuilding2DOccupancyDatas_PostgreSQL = [];
            foreach (GIS.Classes.OccupancyData occupancyData_GIS in occupancyDatas_GIS)
            {
                if (Convert.ToPostgreSQL(occupancyData_GIS) is AdministrativeAreal2DOccupancyData administrativeAreal2DOccupancyData_PostgreSQL)
                {
                    administrativeAreal2DBuilding2DOccupancyDatas_PostgreSQL.Add(administrativeAreal2DOccupancyData_PostgreSQL);
                }
            }

            if (administrativeAreal2DBuilding2DOccupancyDatas_PostgreSQL is null || administrativeAreal2DBuilding2DOccupancyDatas_PostgreSQL.Count == 0)
            {
                Serilog.Modify.Log("No AdministrativeAreal2DOccupancyData PostgreSQL to update");
                return NoContent();
            }

            Serilog.Modify.Log("OccupancyDatas conversion to PostgreSQL ended. OccupancyDatas converted: {After}/{Before}", administrativeAreal2DBuilding2DOccupancyDatas_PostgreSQL.Count, count);

            Serilog.Modify.Log("Updating to database starting");

            HashSet<int>? ids = null;
            try
            {
                ids = await administrativeAreal2DOccupancyDataPostgreSQLConverter.UpdateAsync(administrativeAreal2DBuilding2DOccupancyDatas_PostgreSQL);
            }
            catch (Exception exception)
            {
                Serilog.Modify.Log(exception, "Database could not be updated");
            }

            if (ids is null || ids.Count == 0)
            {
                Serilog.Modify.Log(Serilog.Enums.LogEventLevel.Warning, "Updating to database ended but no Building2DOccupancyDatas have been updated");
            }
            else
            {
                Serilog.Modify.Log("Updating to database ended. Updated AdministrativeAreal2DOccupancyDatas: {After}/{Before}", ids?.Count ?? 0, administrativeAreal2DBuilding2DOccupancyDatas_PostgreSQL.Count);
            }

            return Ok();
        }

        [HttpGet("building2d/itemsbyreference")]
        public async Task<IActionResult> GetItemsByReferenceAsync([FromQuery(Name = "reference")] string reference, [FromQuery(Name = "countyid")] int? countyId, CancellationToken cancellationToken = default)
        {
            Serilog.Modify.Log("{Type}:{Name} started", nameof(OccupancyDataController), nameof(GetItemsByReferenceAsync));

            Serilog.Modify.Log("Reference provided: {Reference}", reference ?? string.Empty);
            Serilog.Modify.Log("CountyId provided: {CountyId}", countyId?.ToString() ?? string.Empty);

            if (string.IsNullOrWhiteSpace(reference))
            {
                Serilog.Modify.Log(Serilog.Enums.LogEventLevel.Error, "Reference cannot be null or empty");
                return BadRequest();
            }

            if (building2DOccupancyDataPostgreSQLConverter is null)
            {
                Serilog.Modify.Log(Serilog.Enums.LogEventLevel.Error, "OccupancyDataPostgreSQLConverter is null");
                return BadRequest();
            }

            List<Building2DOccupancyData>? building2DOccupancyDatas_PostgreSQL = await building2DOccupancyDataPostgreSQLConverter.GetItemsByReferenceAsync(reference, countyId, null, cancellationToken);

            if (building2DOccupancyDatas_PostgreSQL is null || building2DOccupancyDatas_PostgreSQL.Count == 0)
            {
                Serilog.Modify.Log("No Building2DOccupancyDatas found for provided reference");
                return NoContent();
            }

            List<GIS.Interfaces.IOccupancyData> occupancyDatas = [];
            foreach (Building2DOccupancyData building2DOccupancyData_PostgreSQL in building2DOccupancyDatas_PostgreSQL)
            {
                GIS.Interfaces.IOccupancyData? occupancyData_GIS = building2DOccupancyData_PostgreSQL.ToDiGi();
                if (occupancyData_GIS is null)
                {
                    continue;
                }

                occupancyDatas.Add(occupancyData_GIS);
            }

            if (occupancyDatas is null || occupancyDatas.Count == 0)
            {
                return NoContent();
            }

            return Content(Core.Convert.ToSystem_String(occupancyDatas) ?? string.Empty, "application/json");
        }

        [HttpGet("administrativeareal2d/itemsbyreference")]
        public async Task<IActionResult> GetItemsByReferenceAsync([FromQuery(Name = "reference")] string reference, CancellationToken cancellationToken = default)
        {
            Serilog.Modify.Log("{Type}:{Name} started", nameof(OccupancyDataController), nameof(GetItemsByReferenceAsync));

            Serilog.Modify.Log("Reference provided: {Reference}", reference ?? string.Empty);

            if (string.IsNullOrWhiteSpace(reference))
            {
                Serilog.Modify.Log(Serilog.Enums.LogEventLevel.Error, "Reference cannot be null or empty");
                return BadRequest();
            }

            if (building2DOccupancyDataPostgreSQLConverter is null)
            {
                Serilog.Modify.Log(Serilog.Enums.LogEventLevel.Error, "OccupancyDataPostgreSQLConverter is null");
                return BadRequest();
            }

            List<AdministrativeAreal2DOccupancyData>? administrativeAreal2DOccupancyDatas_PostgreSQL = await administrativeAreal2DOccupancyDataPostgreSQLConverter.GetItemsByReferenceAsync(reference, null, cancellationToken);

            if (administrativeAreal2DOccupancyDatas_PostgreSQL is null || administrativeAreal2DOccupancyDatas_PostgreSQL.Count == 0)
            {
                Serilog.Modify.Log("No AdministrativeAreal2DOccupancyDatas found for provided reference");
                return NoContent();
            }

            List<GIS.Interfaces.IOccupancyData> occupancyDatas = [];
            foreach (AdministrativeAreal2DOccupancyData administrativeAreal2DOccupancyData_PostgreSQL in administrativeAreal2DOccupancyDatas_PostgreSQL)
            {
                GIS.Interfaces.IOccupancyData? occupancyData_GIS = administrativeAreal2DOccupancyData_PostgreSQL.ToDiGi();
                if (occupancyData_GIS is null)
                {
                    continue;
                }

                occupancyDatas.Add(occupancyData_GIS);
            }

            if (occupancyDatas is null || occupancyDatas.Count == 0)
            {
                return NoContent();
            }

            return Content(Core.Convert.ToSystem_String(occupancyDatas) ?? string.Empty, "application/json");
        }
    }
}