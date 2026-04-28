using DiGi.GIS.Classes;
using DiGi.GIS.PostgreSQL.Enums;
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
        private readonly PostgreSQL.Classes.Building2DPostgreSQLConverter building2DPostgreSQLConverter;
        private readonly GISPostgreSQLWebAPIConfigurationFileWatcher gISPostgreSQLWebAPIConfigurationFileWatcher;
        private readonly PostgreSQL.Classes.OrtoDatasPostgreSQLConverter ortoDatasPostgreSQLConverter;

        public OrtoDatasController(GISPostgreSQLWebAPIConfigurationFileWatcher gISPostgreSQLWebAPIConfigurationFileWatcher, PostgreSQL.Classes.OrtoDatasPostgreSQLConverter ortoDatasPostgreSQLConverter, PostgreSQL.Classes.Building2DPostgreSQLConverter building2DPostgreSQLConverter, PostgreSQL.Classes.AdministrativeAreal2DPostgreSQLConverter administrativeAreal2DPostgreSQLConverter)
        {
            this.gISPostgreSQLWebAPIConfigurationFileWatcher = gISPostgreSQLWebAPIConfigurationFileWatcher;
            this.ortoDatasPostgreSQLConverter = ortoDatasPostgreSQLConverter;
            this.administrativeAreal2DPostgreSQLConverter = administrativeAreal2DPostgreSQLConverter;
            this.building2DPostgreSQLConverter = building2DPostgreSQLConverter;
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

        [HttpGet("estimatedcoveragefactor")]
        public async Task<IActionResult> GetEstimatedCoverageFactorAsync([FromQuery(Name = "administrativeareal2Did")] int administrativeAreal2DId)
        {
            Serilog.Modify.Log("{Type}:{Name} started", nameof(OrtoDatasController), nameof(GetEstimatedCoverageFactorAsync));
            Serilog.Modify.Log("AdministrativeAeral2D Id provided: {Id}", administrativeAreal2DId.ToString() ?? string.Empty);

            if (administrativeAreal2DPostgreSQLConverter is null)
            {
                Serilog.Modify.Log(Serilog.Enums.LogEventLevel.Error, "AdministrativeAreal2DPostgreSQLConverter cannot be null");
                return BadRequest();
            }

            if (ortoDatasPostgreSQLConverter is null)
            {
                Serilog.Modify.Log(Serilog.Enums.LogEventLevel.Error, "OrtoDatasPostgreSQLConverter cannot be null");
                return BadRequest();
            }

            if (building2DPostgreSQLConverter is null)
            {
                Serilog.Modify.Log(Serilog.Enums.LogEventLevel.Error, "Building2DPostgreSQLConverter cannot be null");
                return BadRequest();
            }

            PostgreSQL.Classes.AdministrativeAreal2DReference? administrativeAreal2DReference = await administrativeAreal2DPostgreSQLConverter.GetAdministrativeAreal2DReferenceByIdAsync(administrativeAreal2DId);
            if (administrativeAreal2DReference is null)
            {
                Serilog.Modify.Log(Serilog.Enums.LogEventLevel.Error, "Could not find given AdministrativeAreal2D");
                return BadRequest();
            }

            Serilog.Modify.Log("AdministrativeAeral2D found: {Name}, type: {AdministrativeArealType}", administrativeAreal2DReference.Name ?? "???", administrativeAreal2DReference.AdministrativeArealType.ToString());

            long count_Building2D = -1;
            long count_OrtoDatas = -1;

            switch (administrativeAreal2DReference.AdministrativeArealType)
            {
                case AdministrativeArealType.Subdivison:
                case AdministrativeArealType.Municipality:
                    Serilog.Modify.Log("Calculating estimated count for {Id}", administrativeAreal2DReference.CountyId?.ToString() ?? "???");
                    count_Building2D = await building2DPostgreSQLConverter.GetEstimatedCountAsync(administrativeAreal2DReference.CountyId);
                    count_OrtoDatas = await ortoDatasPostgreSQLConverter.GetEstimatedCountAsync(administrativeAreal2DReference.CountyId);
                    break;

                case AdministrativeArealType.County:
                    Serilog.Modify.Log("Calculating estimated count for {Id}", administrativeAreal2DReference.Id.ToString() ?? "???");
                    count_Building2D = await building2DPostgreSQLConverter.GetEstimatedCountAsync(administrativeAreal2DReference.Id);
                    count_OrtoDatas = await ortoDatasPostgreSQLConverter.GetEstimatedCountAsync(administrativeAreal2DReference.Id);
                    break;

                case AdministrativeArealType.Voivodeship:
                case AdministrativeArealType.Country:

                    if (administrativeAreal2DReference.Code is null)
                    {
                        Serilog.Modify.Log(Serilog.Enums.LogEventLevel.Error, "Could not get Code for given AdministrativeAreal2D");
                        return BadRequest();
                    }

                    Serilog.Modify.Log("Calculating estimated count for {Code}", administrativeAreal2DReference.Code);

                    List<int>? countyIds = (await administrativeAreal2DPostgreSQLConverter.GetAdministrativeAreal2DReferencesByCodeAsync(administrativeAreal2DReference.Code, AdministrativeArealType.County))?.ConvertAll(x => x.Id);
                    if (countyIds is null || countyIds.Count == 0)
                    {
                        Serilog.Modify.Log(Serilog.Enums.LogEventLevel.Error, "Could not find given County AdministrativeAreal2Ds for given Id");
                        return BadRequest();
                    }

                    Serilog.Modify.Log("Calculating estimated count for {Ids}", string.Join(",", countyIds));

                    count_Building2D = await building2DPostgreSQLConverter.GetEstimatedCountAsync(countyIds);
                    count_OrtoDatas = await ortoDatasPostgreSQLConverter.GetEstimatedCountAsync(countyIds);
                    break;
            }

            double result = 0;
            if (count_Building2D != -1 && count_OrtoDatas != -1)
            {
                result = Math.Clamp(count_OrtoDatas == 0 ? 0.0 : (double)count_OrtoDatas / (double)count_Building2D, 0.0, 1.0);
            }
            else
            {
                if (count_Building2D == -1)
                {
                    Serilog.Modify.Log(Serilog.Enums.LogEventLevel.Warning, "Building2D count could not be calculated");
                }

                if (count_OrtoDatas == -1)
                {
                    Serilog.Modify.Log(Serilog.Enums.LogEventLevel.Warning, "OrtoDatas count could not be calculated");
                }
            }

            return Ok(result);
        }

        [HttpPost("estimatedcoveragefactors")]
        public async Task<IActionResult> GetEstimatedCoverageFactorsAsync([FromBody] IEnumerable<int> administrativeAreal2DIds, bool? analyze)
        {
            Serilog.Modify.Log("{Type}:{Name} started", nameof(OrtoDatasController), nameof(GetEstimatedCoverageFactorsAsync));
            Serilog.Modify.Log("AdministrativeAeral2D Ids provided: {Ids}", string.Join(",", administrativeAreal2DIds ?? []));
            Serilog.Modify.Log("AdministrativeAeral2Ds data type:", administrativeAreal2DIds?.GetType()?.FullName ?? "???");

            if (administrativeAreal2DIds is null || !administrativeAreal2DIds.Any())
            {
                Serilog.Modify.Log(Serilog.Enums.LogEventLevel.Error, "administrativeAreal2DIds have not been provided");
                return BadRequest();
            }

            List<int> administrativeAreal2DIds_Temp = [.. administrativeAreal2DIds];

            if (ortoDatasPostgreSQLConverter is null)
            {
                Serilog.Modify.Log(Serilog.Enums.LogEventLevel.Error, "OrtoDatasPostgreSQLConverter cannot be null");
                return BadRequest();
            }

            if (administrativeAreal2DPostgreSQLConverter is null)
            {
                Serilog.Modify.Log(Serilog.Enums.LogEventLevel.Error, "AdministrativeAreal2DPostgreSQLConverter cannot be null");
                return BadRequest();
            }

            if (building2DPostgreSQLConverter is null)
            {
                Serilog.Modify.Log(Serilog.Enums.LogEventLevel.Error, "Building2DPostgreSQLConverter cannot be null");
                return BadRequest();
            }

            List<PostgreSQL.Classes.AdministrativeAreal2DReference>? administrativeAreal2DReferences = await administrativeAreal2DPostgreSQLConverter.GetAdministrativeAreal2DReferencesByIdsAsync(administrativeAreal2DIds_Temp);
            if (administrativeAreal2DReferences is null || administrativeAreal2DReferences.Count == 0)
            {
                Serilog.Modify.Log(Serilog.Enums.LogEventLevel.Error, "AdministrativeAreal2Ds could not be found in database");
                return BadRequest();
            }

            List<PostgreSQL.Classes.AdministrativeAreal2DReference> administrativeAreal2DReferences_SubdivisonMunicipality = [];
            List<PostgreSQL.Classes.AdministrativeAreal2DReference> administrativeAreal2DReferences_County = [];
            List<PostgreSQL.Classes.AdministrativeAreal2DReference> administrativeAreal2DReferences_VoivodeshipCountry = [];

            foreach (PostgreSQL.Classes.AdministrativeAreal2DReference administrativeAreal2DReference in administrativeAreal2DReferences)
            {
                if (administrativeAreal2DReference?.AdministrativeArealType is not AdministrativeArealType administrativeArealType || administrativeArealType == AdministrativeArealType.Undefined)
                {
                    Serilog.Modify.Log(Serilog.Enums.LogEventLevel.Warning, "AdministrativeAreal2D is null or has invalid AdministrativeArealType: {AdministrativeArealType}", administrativeAreal2DReference?.AdministrativeArealType.ToString() ?? "???");
                    continue;
                }

                switch (administrativeArealType)
                {
                    case AdministrativeArealType.Subdivison:
                    case AdministrativeArealType.Municipality:
                        administrativeAreal2DReferences_SubdivisonMunicipality.Add(administrativeAreal2DReference);
                        break;

                    case AdministrativeArealType.County:
                        administrativeAreal2DReferences_County.Add(administrativeAreal2DReference);
                        break;

                    case AdministrativeArealType.Voivodeship:
                    case AdministrativeArealType.Country:
                        administrativeAreal2DReferences_VoivodeshipCountry.Add(administrativeAreal2DReference);
                        break;
                }
            }

            Dictionary<int, (long Count_Building2D, long Count_OrtoDatas)> dictionary = [];

            foreach (PostgreSQL.Classes.AdministrativeAreal2DReference administrativeAreal2DReference in administrativeAreal2DReferences_County)
            {
                long count_Building2D = await building2DPostgreSQLConverter.GetEstimatedCountAsync(administrativeAreal2DReference.Id, analyze ?? false);
                long count_OrtoDatas = await ortoDatasPostgreSQLConverter.GetEstimatedCountAsync(administrativeAreal2DReference.Id, analyze ?? false);

                dictionary[administrativeAreal2DReference.Id] = (count_Building2D, count_OrtoDatas);
            }

            foreach (PostgreSQL.Classes.AdministrativeAreal2DReference administrativeAreal2DReference in administrativeAreal2DReferences_SubdivisonMunicipality)
            {
                if (administrativeAreal2DReference?.CountyId is not int countyId)
                {
                    continue;
                }

                if (!dictionary.TryGetValue(countyId, out (long, long) value))
                {
                    long count_Building2D = await building2DPostgreSQLConverter.GetEstimatedCountAsync(countyId, analyze ?? false);
                    long count_OrtoDatas = await ortoDatasPostgreSQLConverter.GetEstimatedCountAsync(countyId, analyze ?? false);

                    value = (count_Building2D, count_OrtoDatas);

                    dictionary[countyId] = value;
                }

                dictionary[administrativeAreal2DReference.Id] = value;
            }

            foreach (PostgreSQL.Classes.AdministrativeAreal2DReference administrativeAreal2DReference in administrativeAreal2DReferences_VoivodeshipCountry)
            {
                if (administrativeAreal2DReference.Code is not string code || string.IsNullOrWhiteSpace(code))
                {
                    continue;
                }

                List<int>? countyIds_AdministrativeAreal2DReference = (await administrativeAreal2DPostgreSQLConverter.GetAdministrativeAreal2DReferencesByCodeAsync(administrativeAreal2DReference.Code, AdministrativeArealType.County))?.ConvertAll(x => x.Id);
                if (countyIds_AdministrativeAreal2DReference is null || countyIds_AdministrativeAreal2DReference.Count == 0)
                {
                    dictionary[administrativeAreal2DReference.Id] = (-1, -1);
                    continue;
                }

                long count_Building2D = 0;
                long count_OrtoDatas = 0;

                foreach (int countyId_AdministrativeAreal2DReference in countyIds_AdministrativeAreal2DReference)
                {
                    if (!dictionary.TryGetValue(countyId_AdministrativeAreal2DReference, out (long Count_Building2D, long Count_OrtoDatas) value))
                    {
                        long count_Building2D_County = await building2DPostgreSQLConverter.GetEstimatedCountAsync(countyId_AdministrativeAreal2DReference, analyze ?? false);
                        long count_OrtoDatas_County = await ortoDatasPostgreSQLConverter.GetEstimatedCountAsync(countyId_AdministrativeAreal2DReference, analyze ?? false);

                        value = (count_Building2D_County, count_OrtoDatas_County);

                        dictionary[countyId_AdministrativeAreal2DReference] = value;
                    }

                    if (value.Count_Building2D > 0)
                    {
                        count_Building2D += value.Count_Building2D;
                    }

                    if (value.Count_OrtoDatas > 0)
                    {
                        count_OrtoDatas += value.Count_OrtoDatas;
                    }
                }

                dictionary[administrativeAreal2DReference.Id] = (count_Building2D, count_OrtoDatas);
            }

            Func<long, long, double> estimatedCoverageFactor = new((count_Building2D, count_OrtoDatas) =>
            {
                if (count_Building2D < 0 || count_OrtoDatas < 0)
                {
                    return double.NaN;
                }

                if (count_Building2D == 0 || count_OrtoDatas == 0)
                {
                    return 0;
                }

                return Math.Clamp(count_OrtoDatas == 0 ? 0.0 : (double)count_OrtoDatas / (double)count_Building2D, 0.0, 1.0);
            });

            Serilog.Modify.Log("Counts calculated: {Count}", dictionary.Count);

            List<double> result = [];
            foreach (int id in administrativeAreal2DIds_Temp)
            {
                Serilog.Modify.Log("AdministrativeAreal2D calculation started Id: {Id}", id);
                if (!dictionary.TryGetValue(id, out (long Count_Building2D, long Count_OrtoDatas) value))
                {
                    Serilog.Modify.Log(Serilog.Enums.LogEventLevel.Warning, "AdministrativeAreal2Ds has no data. Id: {Id}", id);
                    result.Add(0);
                    continue;
                }

                double factor = estimatedCoverageFactor(value.Count_Building2D, value.Count_OrtoDatas);
                Serilog.Modify.Log("Factor calculated: {Factor}", factor);

                result.Add(double.IsNaN(factor) ? 0 : factor);
            }

            return Ok(result);
        }

        [HttpGet("itembyreference")]
        public async Task<IActionResult> GetItemByReferenceAsync([FromQuery(Name = "reference")] string reference, [FromQuery(Name = "countyid")] int? countyId)
        {
            Serilog.Modify.Log("{Type}:{Name} started", nameof(OrtoDatasController), nameof(GetItemByReferenceAsync));
            Serilog.Modify.Log("Reference provided: {Reference}", reference ?? string.Empty);
            Serilog.Modify.Log("Countyid provided: {CountyId}", countyId?.ToString() ?? string.Empty);

            if (string.IsNullOrWhiteSpace(reference))
            {
                Serilog.Modify.Log(Serilog.Enums.LogEventLevel.Error, "Reference cannot be null or whitespace");
                return BadRequest("Reference cannot be null or whitespace.");
            }

            PostgreSQL.Classes.OrtoDatas? ortoDatas = await ortoDatasPostgreSQLConverter.GetOrtoDatasByReferenceAsync(reference, countyId);
            if (ortoDatas is null)
            {
                return NoContent();
            }

            OrtoDatas? ortoDatas_DiGi = ortoDatas.ToDiGi();
            if (ortoDatas_DiGi is null)
            {
                return NoContent();
            }

            return Content(Core.Convert.ToSystem_String((Core.Interfaces.ISerializableObject)ortoDatas_DiGi) ?? string.Empty, "application/json");
        }

        [HttpPost("nextbuilding2Dreferences")]
        public async Task<IActionResult> NextBuilding2DReferences([FromQuery(Name = "count")] int count = 100)
        {
            Serilog.Modify.Log("{Type}:{Name} started", nameof(OrtoDatasController), nameof(NextBuilding2DReferences));
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

            List<PostgreSQL.Classes.Building2DReference>? building2DReferences = await ortoDatasPostgreSQLConverter.GetNextBuilding2DReferencesAsync(count);

            Serilog.Modify.Log("Extracting data ended");

            if (building2DReferences is null || building2DReferences.Count == 0)
            {
                Serilog.Modify.Log("No content extracted");
                return NoContent();
            }

            Serilog.Modify.Log("{Count} items extracted", building2DReferences.Count);

            return Content(Core.Convert.ToSystem_String(building2DReferences) ?? string.Empty, "application/json");
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

            int? countyId = await administrativeAreal2DPostgreSQLConverter.GetIdByCodeAsync(code, AdministrativeArealType.County);
            if (countyId is null)
            {
                Serilog.Modify.Log("County with given code not found");
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