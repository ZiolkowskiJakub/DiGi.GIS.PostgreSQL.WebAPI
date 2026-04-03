using DiGi.GIS.PostgreSQL.Classes;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace DiGi.GIS.PostgreSQL.WebAPI.Classes
{
    [ApiController]
    [Route("gis/[controller]")]
    public class YearBuiltController : DiGi.WebAPI.Classes.WebAPIController
    {
        private readonly AdministrativeAreal2DPostgreSQLConverter administrativeAreal2DPostgreSQLConverter;
        private readonly GISPostgreSQLWebAPIConfigurationFileWatcher gISPostgreSQLWebAPIConfigurationFileWatcher;
        private readonly YearBuiltPostgreSQLConverter yearBuiltPostgreSQLConverter;

        public YearBuiltController(GISPostgreSQLWebAPIConfigurationFileWatcher gISPostgreSQLWebAPIConfigurationFileWatcher, YearBuiltPostgreSQLConverter yearBuiltPostgreSQLConverter, AdministrativeAreal2DPostgreSQLConverter administrativeAreal2DPostgreSQLConverter)
        {
            this.gISPostgreSQLWebAPIConfigurationFileWatcher = gISPostgreSQLWebAPIConfigurationFileWatcher;
            this.yearBuiltPostgreSQLConverter = yearBuiltPostgreSQLConverter;
            this.administrativeAreal2DPostgreSQLConverter = administrativeAreal2DPostgreSQLConverter;
        }

        [HttpPost("updateitemsbyreference")]
        public async Task<IActionResult> UpdateItemsByReferenceAsync([FromBody] JsonArray? jsonArray, [FromQuery(Name = "code")] string code, [FromQuery(Name = "reference")] string reference)
        {
            Serilog.Modify.Log("{Type}:{Name} started", nameof(YearBuiltController), nameof(UpdateItemsByReferenceAsync));
            Serilog.Modify.Log("Code provided: {Code}", code ?? string.Empty);
            Serilog.Modify.Log("Reference provided: {reference}", reference ?? string.Empty);

            if (string.IsNullOrWhiteSpace(code))
            {
                Serilog.Modify.Log(Serilog.Enums.LogEventLevel.Error, "Code cannot be null or empty");
                return BadRequest();
            }

            if (string.IsNullOrWhiteSpace(reference))
            {
                Serilog.Modify.Log(Serilog.Enums.LogEventLevel.Error, "Reference cannot be null or empty");
                return BadRequest();
            }

            if (!gISPostgreSQLWebAPIConfigurationFileWatcher.AllowUpdateYearBuilt)
            {
                Serilog.Modify.Log(Serilog.Enums.LogEventLevel.Warning, "YearBuilt update not allowed");
                return BadRequest();
            }

            if (administrativeAreal2DPostgreSQLConverter is null)
            {
                Serilog.Modify.Log(Serilog.Enums.LogEventLevel.Error, "AdministrativeAreal2DPostgreSQLConverter is null");
                return BadRequest();
            }

            if (jsonArray is null || jsonArray.Count == 0)
            {
                Serilog.Modify.Log("No YearBuilts to update");
                return NoContent();
            }

            int? countyId = await administrativeAreal2DPostgreSQLConverter.GetIdByCodeAsync(code, Enums.AdministrativeArealType.County);
            if (countyId is null)
            {
                return BadRequest();
            }

            List<GIS.Interfaces.IYearBuilt>? yearBuilts_GIS = Core.Create.SerializableObjects<GIS.Interfaces.IYearBuilt>(jsonArray);
            if (yearBuilts_GIS is null)
            {
                Serilog.Modify.Log(Serilog.Enums.LogEventLevel.Error, "YearBuilts could not be converted from json");
                return BadRequest();
            }

            Serilog.Modify.Log("YearBuilts conversion to PostgreSQL started. YearBuilts count: {Count}", yearBuilts_GIS.Count);

            List<PostgreSQL.Classes.YearBuilt> yearBuilts_PostgreSQL = [];
            foreach (GIS.Interfaces.IYearBuilt yearBuilt_GIS in yearBuilts_GIS)
            {
                PostgreSQL.Classes.YearBuilt? yearBuilt_PostgreSQL = yearBuilt_GIS.ToPostgreSQL(countyId, reference);
                if (yearBuilt_PostgreSQL is null)
                {
                    continue;
                }

                yearBuilts_PostgreSQL.Add(yearBuilt_PostgreSQL);
            }

            if (yearBuilts_PostgreSQL is null || yearBuilts_PostgreSQL.Count == 0)
            {
                Serilog.Modify.Log("No YearBuilts PostgreSQL to update");
                return NoContent();
            }

            Serilog.Modify.Log("YearBuilts conversion to PostgreSQL ended. YearBuiltDatas converted: {After}/{Before}", yearBuilts_PostgreSQL.Count, yearBuilts_GIS.Count);

            Serilog.Modify.Log("Updating to database starting");

            HashSet<long>? ids = null;
            try
            {
                ids = await yearBuiltPostgreSQLConverter.UpdateAsync(yearBuilts_PostgreSQL);
            }
            catch (Exception exception)
            {
                Serilog.Modify.Log(exception, "Database could not be updated");
            }

            if (ids is null || ids.Count == 0)
            {
                Serilog.Modify.Log(Serilog.Enums.LogEventLevel.Warning, "Updating to database ended but no YearBuilts have been updated");
            }
            else
            {
                Serilog.Modify.Log("Updating to database ended. Updated YearBuilts: {After}/{Before}", ids?.Count ?? 0, yearBuilts_PostgreSQL.Count);
            }

            return Ok();
        }

        [HttpPost("updateitemsbyyearbuiltdatas")]
        public async Task<IActionResult> UpdateItemsByYearBuiltDatasAsync([FromBody] JsonArray? jsonArray, [FromQuery(Name = "code")] string code)
        {
            Serilog.Modify.Log("{Type}:{Name} started", nameof(YearBuiltController), nameof(UpdateItemsByReferenceAsync));
            Serilog.Modify.Log("Code provided: {Code}", code ?? string.Empty);

            if (string.IsNullOrWhiteSpace(code))
            {
                Serilog.Modify.Log(Serilog.Enums.LogEventLevel.Error, "Code cannot be null or empty");
                return BadRequest();
            }

            if (!gISPostgreSQLWebAPIConfigurationFileWatcher.AllowUpdateYearBuilt)
            {
                Serilog.Modify.Log(Serilog.Enums.LogEventLevel.Warning, "YearBuilt update not allowed");
                return BadRequest();
            }

            if (administrativeAreal2DPostgreSQLConverter is null)
            {
                Serilog.Modify.Log(Serilog.Enums.LogEventLevel.Error, "AdministrativeAreal2DPostgreSQLConverter is null");
                return BadRequest();
            }

            if (jsonArray is null || jsonArray.Count == 0)
            {
                Serilog.Modify.Log("No YearBuiltData to update");
                return NoContent();
            }

            int? countyId = await administrativeAreal2DPostgreSQLConverter.GetIdByCodeAsync(code, Enums.AdministrativeArealType.County);
            if (countyId is null)
            {
                return BadRequest();
            }

            List<GIS.Classes.YearBuiltData>? yearBuiltDatas_GIS = Core.Create.SerializableObjects<GIS.Classes.YearBuiltData>(jsonArray);
            if (yearBuiltDatas_GIS is null)
            {
                Serilog.Modify.Log(Serilog.Enums.LogEventLevel.Error, "YearBuiltDatas could not be converted from json");
                return BadRequest();
            }

            Serilog.Modify.Log("YearBuilts conversion to PostgreSQL started. YearBuiltDatas count: {Count}", yearBuiltDatas_GIS.Count);

            int count = 0;

            List<YearBuilt> yearBuilts_PostgreSQL = [];
            foreach (GIS.Classes.YearBuiltData yearBuiltData_GIS in yearBuiltDatas_GIS)
            {
                if (yearBuiltData_GIS.YearBuilts is IEnumerable<GIS.Interfaces.IYearBuilt> yearBuilts)
                {
                    foreach (GIS.Interfaces.IYearBuilt yearBuilt in yearBuilts)
                    {
                        count++;

                        YearBuilt? yearBuilt_PostgreSQL = yearBuilt.ToPostgreSQL(countyId, yearBuiltData_GIS.Reference);
                        if (yearBuilt_PostgreSQL is null)
                        {
                            continue;
                        }

                        yearBuilts_PostgreSQL.Add(yearBuilt_PostgreSQL);
                    }
                }
            }

            if (yearBuilts_PostgreSQL is null || yearBuilts_PostgreSQL.Count == 0)
            {
                Serilog.Modify.Log("No YearBuilts PostgreSQL to update");
                return NoContent();
            }

            Serilog.Modify.Log("YearBuilts conversion to PostgreSQL ended. YearBuiltDatas converted: {After}/{Before}", yearBuilts_PostgreSQL.Count, count);

            Serilog.Modify.Log("Updating to database starting");

            HashSet<long>? ids = null;
            try
            {
                ids = await yearBuiltPostgreSQLConverter.UpdateAsync(yearBuilts_PostgreSQL);
            }
            catch (Exception exception)
            {
                Serilog.Modify.Log(exception, "Database could not be updated");
            }

            if (ids is null || ids.Count == 0)
            {
                Serilog.Modify.Log(Serilog.Enums.LogEventLevel.Warning, "Updating to database ended but no YearBuilts have been updated");
            }
            else
            {
                Serilog.Modify.Log("Updating to database ended. Updated YearBuilts: {After}/{Before}", ids?.Count ?? 0, yearBuilts_PostgreSQL.Count);
            }

            return Ok();
        }

        [HttpPost("itemsbyreference")]
        public async Task<IActionResult> GetItemsByReferenceAsync([FromQuery(Name = "reference")] string reference, [FromQuery(Name = "code")] string code)
        {
            Serilog.Modify.Log("{Type}:{Name} started", nameof(YearBuiltController), nameof(GetItemsByReferenceAsync));
            Serilog.Modify.Log("Code provided: {Code}", code ?? string.Empty);
            Serilog.Modify.Log("Reference provided: {Reference}", reference ?? string.Empty);

            if (string.IsNullOrWhiteSpace(code))
            {
                Serilog.Modify.Log(Serilog.Enums.LogEventLevel.Error, "Code cannot be null or empty");
                return BadRequest();
            }

            if (string.IsNullOrWhiteSpace(reference))
            {
                Serilog.Modify.Log(Serilog.Enums.LogEventLevel.Error, "Reference cannot be null or empty");
                return BadRequest();
            }

            if (yearBuiltPostgreSQLConverter is null)
            {
                Serilog.Modify.Log(Serilog.Enums.LogEventLevel.Error, "YearBuiltDataPostgreSQLConverter is null");
                return BadRequest();
            }

            if (administrativeAreal2DPostgreSQLConverter is null)
            {
                Serilog.Modify.Log(Serilog.Enums.LogEventLevel.Error, "AdministrativeAreal2DPostgreSQLConverter is null");
                return BadRequest();
            }

            int? countyId = await administrativeAreal2DPostgreSQLConverter.GetIdByCodeAsync(code, Enums.AdministrativeArealType.County);
            if (countyId is null)
            {
                return BadRequest();
            }

            List<YearBuilt>? yearBuilts_PostgreSQL = await yearBuiltPostgreSQLConverter.GetYearBuiltsByBuilding2DReferencesAsync([new Building2DReference()
            {
                CountyId = countyId,
                Reference = reference
            }]);

            if (yearBuilts_PostgreSQL is null || yearBuilts_PostgreSQL.Count == 0)
            {
                Serilog.Modify.Log("No YearBuilts found for provided reference");
                return NoContent();
            }

            List<GIS.Interfaces.IYearBuilt> yearBuilts = [];
            foreach (YearBuilt yearBuilt_PostgreSQL in yearBuilts_PostgreSQL)
            {
                GIS.Interfaces.IYearBuilt? yearBuilt_GIS = yearBuilt_PostgreSQL.ToDiGi();
                if (yearBuilt_GIS is null)
                {
                    continue;
                }

                yearBuilts.Add(yearBuilt_GIS);
            }

            if (yearBuilts is null || yearBuilts.Count == 0)
            {
                return NoContent();
            }

            return Content(Core.Convert.ToSystem_String(yearBuilts) ?? string.Empty, "application/json");
        }
    }
}