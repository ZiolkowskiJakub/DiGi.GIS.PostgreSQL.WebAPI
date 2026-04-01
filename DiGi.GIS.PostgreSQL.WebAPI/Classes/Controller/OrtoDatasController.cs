using DiGi.GIS.Classes;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace DiGi.GIS.PostgreSQL.WebAPI.Classes
{
    [ApiController]
    [Route("gis/[controller]")]
    public class OrtoDatasController : DiGi.WebAPI.Classes.WebAPIController
    {
        private readonly PostgreSQL.Classes.AdministrativeAreal2DPostgreSQLConverter administrativeAreal2DPostgreSQLConverter;
        private readonly GISPostgreSQLWebAPIConfigurationFileWatcher gISPostgreSQLWebAPIConfigurationFileWatcher;
        private readonly PostgreSQL.Classes.OrtoDatasPostgreSQLConverter ortoDatasPostgreSQLConverter;

        public OrtoDatasController(GISPostgreSQLWebAPIConfigurationFileWatcher gISPostgreSQLWebAPIConfigurationFileWatcher, PostgreSQL.Classes.OrtoDatasPostgreSQLConverter ortoDatasPostgreSQLConverter, PostgreSQL.Classes.AdministrativeAreal2DPostgreSQLConverter administrativeAreal2DPostgreSQLConverter)
        {
            this.gISPostgreSQLWebAPIConfigurationFileWatcher = gISPostgreSQLWebAPIConfigurationFileWatcher;
            this.ortoDatasPostgreSQLConverter = ortoDatasPostgreSQLConverter;
            this.administrativeAreal2DPostgreSQLConverter = administrativeAreal2DPostgreSQLConverter;
        }

        [HttpPost("containsbyreferences")]
        public async Task<IActionResult> ContainsByReferencesAsync([FromBody] List<string>? references, [FromQuery(Name = "countyId")] int? countyId, [FromQuery(Name = "inverted")] bool? inverted)
        {
            Serilog.Modify.Log("{Type}:{Name} started", nameof(OrtoDatasController), nameof(ContainsByReferencesAsync));
            Serilog.Modify.Log("CountyId provided: {CountyId}", countyId?.ToString() ?? "None");
            Serilog.Modify.Log("Inverted: {Inverted}", (inverted ?? false).ToString());

            if (references is null || references.Count == 0)
            {
                Serilog.Modify.Log("No references to check");
                return BadRequest("The references list cannot be empty.");
            }

            HashSet<string> uniqueReferences = [.. references.Where(r => !string.IsNullOrWhiteSpace(r))];

            if (uniqueReferences.Count == 0)
            {
                Serilog.Modify.Log(Serilog.Enums.LogEventLevel.Error, "References could not be converted or are empty");
                return BadRequest("Provided list contains only empty values.");
            }

            Serilog.Modify.Log("References count: {Count}", uniqueReferences.Count);

            Serilog.Modify.Log("Query database starting");

            try
            {
                HashSet<string>? referencesExisting = await ortoDatasPostgreSQLConverter.ContainsByReferencesAsync(uniqueReferences, countyId, inverted ?? false);

                referencesExisting ??= [];

                return Ok(referencesExisting);
            }
            catch (Exception exception)
            {
                Serilog.Modify.Log(exception, "Database could not be queried");
                return StatusCode(500, "Internal server error during database query");
            }
        }

        [HttpPost("nextlocationreferences")]
        public async Task<IActionResult> NextLocationReferences([FromQuery(Name = "count")] int count = 100)
        {
            Serilog.Modify.Log("{Type}:{Name} started", nameof(OrtoDatasController), nameof(NextLocationReferences));
            Serilog.Modify.Log("Count provided: {Count}", count);

            if (count <= 0)
            {
                Serilog.Modify.Log(Serilog.Enums.LogEventLevel.Error, "Count must be greater than 0");
                return BadRequest("Count must be greater than 0.");
            }

            if (ortoDatasPostgreSQLConverter is null)
            {
                Serilog.Modify.Log(Serilog.Enums.LogEventLevel.Error, "OrtoDatasPostgreSQLConverter is null");
                return BadRequest();
            }

            Serilog.Modify.Log("Extracting data starting");

            List<PostgreSQL.Classes.LocationReference>? locationReferences = await ortoDatasPostgreSQLConverter.GetNextLocationReferencesAsync(count);

            Serilog.Modify.Log("Extracting data ended");

            if (locationReferences is null || locationReferences.Count == 0)
            {
                Serilog.Modify.Log("No content extracted");
                return NoContent();
            }

            Serilog.Modify.Log("{Count} items extracted", locationReferences.Count);

            return Content(Core.Convert.ToSystem_String(locationReferences) ?? string.Empty, "application/json");
        }

        [HttpPost("updateitemsbycode")]
        public async Task<IActionResult> UpdateItemsByCodeAsync([FromBody] JsonArray? jsonArray, [FromQuery(Name = "code")] string code)
        {
            Serilog.Modify.Log("{Type}:{Name} started", nameof(OrtoDatasController), nameof(UpdateItemsByCodeAsync));
            Serilog.Modify.Log("Code provided: {Code}", code ?? string.Empty);

            if (code is null)
            {
                Serilog.Modify.Log(Serilog.Enums.LogEventLevel.Error, "code cannot be null");
                return BadRequest();
            }

            if (!gISPostgreSQLWebAPIConfigurationFileWatcher.AllowUpdateOrtoDatas)
            {
                Serilog.Modify.Log(Serilog.Enums.LogEventLevel.Warning, "OrtoDatas update not allowed");
                return BadRequest();
            }

            if (administrativeAreal2DPostgreSQLConverter is null)
            {
                Serilog.Modify.Log(Serilog.Enums.LogEventLevel.Error, "AdministrativeAreal2DPostgreSQLConverter is null");
                return BadRequest();
            }

            if (jsonArray is null || jsonArray.Count == 0)
            {
                Serilog.Modify.Log("No OrtoDatas to update");
                return NoContent();
            }

            int? countyId = await administrativeAreal2DPostgreSQLConverter.GetIdByCodeAsync(code, Enums.AdministrativeArealType.County);
            if (countyId is null)
            {
                return BadRequest();
            }

            List<OrtoDatas>? ortoDatas = Core.Create.SerializableObjects<OrtoDatas>(jsonArray);
            if (ortoDatas is null)
            {
                Serilog.Modify.Log(Serilog.Enums.LogEventLevel.Error, "OrtoDatas could not be converted from json");
                return BadRequest();
            }

            Serilog.Modify.Log("OrtoDatas conversion to PostgreSQL started. OrtoDatas count: {Count}", ortoDatas.Count);

            List<PostgreSQL.Classes.OrtoDatas> ortoDatas_PostgreSQL = [];
            foreach (OrtoDatas ortoDatas_Temp in ortoDatas)
            {
                PostgreSQL.Classes.OrtoDatas? ortoDatas_PostgreSQL_Temp = ortoDatas_Temp.ToPostgreSQL(countyId);
                if (ortoDatas_PostgreSQL_Temp is null)
                {
                    continue;
                }

                ortoDatas_PostgreSQL.Add(ortoDatas_PostgreSQL_Temp);
            }

            if (ortoDatas_PostgreSQL is null || ortoDatas_PostgreSQL.Count == 0)
            {
                Serilog.Modify.Log("No OrtoDatas PostgreSQL to update");
                return NoContent();
            }

            Serilog.Modify.Log("OrtoDatas conversion to PostgreSQL ended. OrtoDatas converted: {After}/{Before}", ortoDatas_PostgreSQL.Count, ortoDatas.Count);

            Serilog.Modify.Log("Updating to database starting");

            HashSet<long>? ids = null;
            try
            {
                ids = await ortoDatasPostgreSQLConverter.UpdateAsync(ortoDatas_PostgreSQL);
            }
            catch (Exception exception)
            {
                Serilog.Modify.Log(exception, "Database could not be updated");
            }

            if (ids is null || ids.Count == 0)
            {
                Serilog.Modify.Log(Serilog.Enums.LogEventLevel.Warning, "Updating to database ended but no OrtoDatas have been updated");
            }
            else
            {
                Serilog.Modify.Log("Updating to database ended. Updated OrtoDatas: {After}/{Before}", ids?.Count ?? 0, ortoDatas_PostgreSQL.Count);
            }

            return Ok();
        }

        [HttpPost("updateitemsbycountyid")]
        public async Task<IActionResult> UpdateItemsByCountyIdAsync([FromBody] JsonArray? jsonArray, [FromQuery(Name = "countyId")] int countyId)
        {
            Serilog.Modify.Log("{Type}:{Name} started", nameof(OrtoDatasController), nameof(UpdateItemsByCountyIdAsync));
            Serilog.Modify.Log("CountyId provided: {CountyId}", countyId.ToString());

            if (!gISPostgreSQLWebAPIConfigurationFileWatcher.AllowUpdateOrtoDatas)
            {
                Serilog.Modify.Log(Serilog.Enums.LogEventLevel.Warning, "OrtoDatas update not allowed");
                return BadRequest();
            }

            if (jsonArray is null || jsonArray.Count == 0)
            {
                Serilog.Modify.Log("No OrtoDatas to update");
                return NoContent();
            }

            List<OrtoDatas>? ortoDatas = Core.Create.SerializableObjects<OrtoDatas>(jsonArray);
            if (ortoDatas is null)
            {
                Serilog.Modify.Log(Serilog.Enums.LogEventLevel.Error, "OrtoDatas could not be converted from json");
                return BadRequest();
            }

            Serilog.Modify.Log("OrtoDatas conversion to PostgreSQL started. OrtoDatas count: {Count}", ortoDatas.Count);

            List<PostgreSQL.Classes.OrtoDatas> ortoDatas_PostgreSQL = [];
            foreach (OrtoDatas ortoDatas_Temp in ortoDatas)
            {
                PostgreSQL.Classes.OrtoDatas? ortoDatas_PostgreSQL_Temp = ortoDatas_Temp.ToPostgreSQL(countyId);
                if (ortoDatas_PostgreSQL_Temp is null)
                {
                    continue;
                }

                ortoDatas_PostgreSQL.Add(ortoDatas_PostgreSQL_Temp);
            }

            if (ortoDatas_PostgreSQL is null || ortoDatas_PostgreSQL.Count == 0)
            {
                Serilog.Modify.Log("No OrtoDatas PostgreSQL to update");
                return NoContent();
            }

            Serilog.Modify.Log("OrtoDatas conversion to PostgreSQL ended. OrtoDatas converted: {After}/{Before}", ortoDatas_PostgreSQL.Count, ortoDatas.Count);

            Serilog.Modify.Log("Updating to database starting");

            HashSet<long>? ids = null;
            try
            {
                ids = await ortoDatasPostgreSQLConverter.UpdateAsync(ortoDatas_PostgreSQL);
            }
            catch (Exception exception)
            {
                Serilog.Modify.Log(exception, "Database could not be updated");
            }

            if (ids is null || ids.Count == 0)
            {
                Serilog.Modify.Log(Serilog.Enums.LogEventLevel.Warning, "Updating to database ended but no OrtoDatas have been updated");
            }
            else
            {
                Serilog.Modify.Log("Updating to database ended. Updated OrtoDatasOrtoDatas: {After}/{Before}", ids?.Count ?? 0, ortoDatas_PostgreSQL.Count);
            }

            return Ok();
        }
    }
}