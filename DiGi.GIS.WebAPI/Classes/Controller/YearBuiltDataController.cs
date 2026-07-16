using DiGi.GIS.PostgreSQL.Classes;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text.Json.Nodes;
using System.Threading;
using System.Threading.Tasks;

namespace DiGi.GIS.WebAPI.Classes
{
    /// <summary>
    /// Provides API endpoints for managing and updating year built data stored in a PostgreSQL database.
    /// </summary>
    [ApiController]
    [Route("gis/[controller]")]
    public class YearBuiltDataController : DiGi.WebAPI.Classes.WebAPIController
    {
        private readonly AdministrativeAreal2DPostgreSQLConverter administrativeAreal2DPostgreSQLConverter;
        private readonly GISWebAPIConfigurationFileWatcher GISWebAPIConfigurationFileWatcher;
        private readonly YearBuiltDataPostgreSQLConverter yearBuiltDataPostgreSQLConverter;

        /// <summary>
        /// Initializes a new instance of the YearBuiltDataController class.
        /// </summary>
        /// <param name="GISWebAPIConfigurationFileWatcher">The configuration file watcher used to monitor changes to the PostgreSQL Web API configuration.</param>
        /// <param name="yearBuiltDataPostgreSQLConverter">The converter for YearBuiltData objects when interacting with a PostgreSQL database.</param>
        /// <param name="administrativeAreal2DPostgreSQLConverter">The converter for administrative areal 2D data when interacting with a PostgreSQL database.</param>
        public YearBuiltDataController(GISWebAPIConfigurationFileWatcher GISWebAPIConfigurationFileWatcher, YearBuiltDataPostgreSQLConverter yearBuiltDataPostgreSQLConverter, AdministrativeAreal2DPostgreSQLConverter administrativeAreal2DPostgreSQLConverter)
        {
            this.GISWebAPIConfigurationFileWatcher = GISWebAPIConfigurationFileWatcher;
            this.yearBuiltDataPostgreSQLConverter = yearBuiltDataPostgreSQLConverter;
            this.administrativeAreal2DPostgreSQLConverter = administrativeAreal2DPostgreSQLConverter;
        }

        /// <summary>
        /// Updates multiple year built data items based on the provided JSON array and identification code.
        /// </summary>
        /// <param name="jsonArray">The JSON array containing the data items to be updated.</param>
        /// <param name="code">The identification code required for the update operation.</param>
        /// <returns>An <see cref="IActionResult"/> representing the result of the update operation.</returns>
        [HttpPost("updateitems")]
        public async Task<IActionResult> UpdateItemsAsync([FromBody] JsonArray? jsonArray, [FromQuery(Name = "code")] string code)
        {
            Serilog.Modify.Log("{Type}:{Name} started", nameof(YearBuiltDataController), nameof(UpdateItemsAsync));
            Serilog.Modify.Log("Code provided: {Code}", code ?? string.Empty);

            if (string.IsNullOrWhiteSpace(code))
            {
                Serilog.Modify.Log(Serilog.Enums.LogEventLevel.Error, "Code cannot be null or empty");
                return BadRequest();
            }

            if (!GISWebAPIConfigurationFileWatcher.AllowUpdateYearBuiltData)
            {
                Serilog.Modify.Log(Serilog.Enums.LogEventLevel.Warning, "YearBuiltData update not allowed");
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

            int? countyId = await administrativeAreal2DPostgreSQLConverter.GetIdByCodeAsync(code, PostgreSQL.Enums.AdministrativeArealType.County);
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

            Serilog.Modify.Log("YearBuiltDatas conversion to PostgreSQL started. YearBuiltDatas count: {Count}", yearBuiltDatas_GIS.Count);

            int count = 0;

            List<YearBuiltData> yearBuiltDatas_PostgreSQL = [];
            foreach (GIS.Classes.YearBuiltData yearBuiltData_GIS in yearBuiltDatas_GIS)
            {
                if (PostgreSQL.Convert.ToPostgreSQL(yearBuiltData_GIS, countyId) is YearBuiltData yearBuiltData_PostgreSQL)
                {
                    yearBuiltDatas_PostgreSQL.Add(yearBuiltData_PostgreSQL);
                }
            }

            if (yearBuiltDatas_PostgreSQL is null || yearBuiltDatas_PostgreSQL.Count == 0)
            {
                Serilog.Modify.Log("No YearBuiltDatas PostgreSQL to update");
                return NoContent();
            }

            Serilog.Modify.Log("YearBuiltDatas conversion to PostgreSQL ended. YearBuiltDatas converted: {After}/{Before}", yearBuiltDatas_PostgreSQL.Count, count);

            Serilog.Modify.Log("Updating to database starting");

            HashSet<long>? ids = null;
            try
            {
                ids = await yearBuiltDataPostgreSQLConverter.UpdateAsync(yearBuiltDatas_PostgreSQL);
            }
            catch (Exception exception)
            {
                Serilog.Modify.Log(exception, "Database could not be updated");
            }

            if (ids is null || ids.Count == 0)
            {
                Serilog.Modify.Log(Serilog.Enums.LogEventLevel.Warning, "Updating to database ended but no YearBuiltDatas have been updated");
            }
            else
            {
                Serilog.Modify.Log("Updating to database ended. Updated YearBuiltDatas: {After}/{Before}", ids?.Count ?? 0, yearBuiltDatas_PostgreSQL.Count);
            }

            return Ok();
        }

        /// <summary>
        /// Asynchronously retrieves items based on a provided reference and an optional county identifier.
        /// </summary>
        /// <param name="reference">The unique reference string used to identify the year built data items.</param>
        /// <param name="countyId">An optional integer representing the county ID to filter the results.</param>
        /// <param name="cancellationToken">The <see cref="T:System.Threading.CancellationToken" /> to observe for cancellation requests.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        [HttpGet("itemsbyreference")]
        public async Task<IActionResult> GetItemsByReferenceAsync([FromQuery(Name = "reference")] string reference, [FromQuery(Name = "countyid")] int? countyId, CancellationToken cancellationToken = default)
        {
            Serilog.Modify.Log("{Type}:{Name} started", nameof(YearBuiltDataController), nameof(GetItemsByReferenceAsync));

            Serilog.Modify.Log("Reference provided: {Reference}", reference ?? string.Empty);
            Serilog.Modify.Log("CountyId provided: {CountyId}", countyId?.ToString() ?? string.Empty);

            if (string.IsNullOrWhiteSpace(reference))
            {
                Serilog.Modify.Log(Serilog.Enums.LogEventLevel.Error, "Reference cannot be null or empty");
                return BadRequest();
            }

            if (yearBuiltDataPostgreSQLConverter is null)
            {
                Serilog.Modify.Log(Serilog.Enums.LogEventLevel.Error, "YearBuiltDataPostgreSQLConverter is null");
                return BadRequest();
            }

            List<YearBuiltData>? yearBuiltDatas_PostgreSQL = await yearBuiltDataPostgreSQLConverter.GetItemsByReferenceAsync(reference, countyId, null, cancellationToken);

            if (yearBuiltDatas_PostgreSQL is null || yearBuiltDatas_PostgreSQL.Count == 0)
            {
                Serilog.Modify.Log("No YearBuiltDatas found for provided reference");
                return NoContent();
            }

            List<GIS.Interfaces.IYearBuiltData> yearBuiltDatas = [];
            foreach (YearBuiltData yearBuilt_PostgreSQL in yearBuiltDatas_PostgreSQL)
            {
                GIS.Interfaces.IYearBuiltData? yearBuiltData_GIS = yearBuilt_PostgreSQL.ToDiGi();
                if (yearBuiltData_GIS is null)
                {
                    continue;
                }

                yearBuiltDatas.Add(yearBuiltData_GIS);
            }

            if (yearBuiltDatas is null || yearBuiltDatas.Count == 0)
            {
                return NoContent();
            }

            return Content(Core.Convert.ToSystem_String(yearBuiltDatas) ?? string.Empty, "application/json");
        }
    }
}