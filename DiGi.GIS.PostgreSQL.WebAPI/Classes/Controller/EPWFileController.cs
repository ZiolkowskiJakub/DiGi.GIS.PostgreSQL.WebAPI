using DiGi.EPW.Classes;
using DiGi.GIS.PostgreSQL.Classes;
using DiGi.WebAPI.Classes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text.Json.Nodes;
using System.Threading;
using System.Threading.Tasks;

namespace DiGi.GIS.PostgreSQL.WebAPI.Classes
{
    /// <summary>
    /// Controller responsible for handling API requests related to EPW files retrieved from or updated in a PostgreSQL database.
    /// </summary>
    [ApiController]
    [Route("gis/[controller]")]
    public class EPWFileController : WebAPIController
    {
        private readonly EPWFilePostgreSQLConverter ePWFilePostgreSQLConverter;
        private readonly GISPostgreSQLWebAPIConfigurationFileWatcher gISPostgreSQLWebAPIConfigurationFileWatcher;

        /// <summary>
        /// Initializes a new instance of the <see cref="EPWFileController"/> class.
        /// </summary>
        /// <param name="gISPostgreSQLWebAPIConfigurationFileWatcher">The configuration file watcher used to monitor changes to the GIS PostgreSQL Web API settings.</param>
        /// <param name="ePWFilePostgreSQLConverter">The converter used for handling EPW file operations within the PostgreSQL database.</param>
        public EPWFileController(
            GISPostgreSQLWebAPIConfigurationFileWatcher gISPostgreSQLWebAPIConfigurationFileWatcher,
            EPWFilePostgreSQLConverter ePWFilePostgreSQLConverter)
        {
            this.gISPostgreSQLWebAPIConfigurationFileWatcher = gISPostgreSQLWebAPIConfigurationFileWatcher;
            this.ePWFilePostgreSQLConverter = ePWFilePostgreSQLConverter;
        }

        /// <summary>
        /// Asynchronously updates or inserts a collection of EPW files.
        /// </summary>
        /// <param name="jsonArray">The JSON array containing the EPW files to update or insert.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by the caller to cancel the asynchronous operation.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        [HttpPost("updateitems", Name = $"{nameof(EPWFileController)}_{nameof(UpdateItemsAsync)}")]
        [ProducesResponseType(typeof(List<int>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateItemsAsync([FromBody] JsonArray? jsonArray, CancellationToken cancellationToken = default)
        {
            Serilog.Modify.Log("{Type}:{Name} started", nameof(EPWFileController), nameof(UpdateItemsAsync));

            if (!gISPostgreSQLWebAPIConfigurationFileWatcher.AllowUpdateEPWFile)
            {
                Serilog.Modify.Log(Serilog.Enums.LogEventLevel.Warning, "EPWFile update not allowed");
                return Unauthorized();
            }

            if (jsonArray is null)
            {
                Serilog.Modify.Log(Serilog.Enums.LogEventLevel.Error, "EPWFiles cannot be null");
                return BadRequest();
            }

            List<EPWFile>? ePWFiles = Core.Create.SerializableObjects<EPWFile>(jsonArray);
            if (ePWFiles is null)
            {
                Serilog.Modify.Log(Serilog.Enums.LogEventLevel.Error, "EPWFiles could not be deserialized");
                return BadRequest();
            }

            int count_Before = ePWFiles.Count;
            if (count_Before == 0)
            {
                Serilog.Modify.Log("No EPWFiles to update");
                return NoContent();
            }

            Serilog.Modify.Log("Updating to database starting");

            List<int> ids = [];
            try
            {
                ids = await ePWFilePostgreSQLConverter.InsertAsync(ePWFiles, cancellationToken);
            }
            catch (Exception exception)
            {
                Serilog.Modify.Log(exception, "Database could not be updated");
                return StatusCode(500, "Internal server error during database update");
            }

            if (ids.Count == 0)
            {
                Serilog.Modify.Log(Serilog.Enums.LogEventLevel.Warning, "Updating to database ended but no EPWFiles have been updated");
            }
            else
            {
                Serilog.Modify.Log("Updating to database ended. Updated EPWFiles: {After}/{Before}", ids.Count, count_Before);
            }

            return Ok(ids);
        }

        /// <summary>
        /// Asynchronously retrieves the closest EPWFile to the given coordinate (x, y).
        /// </summary>
        /// <param name="x">The X coordinate (longitude).</param>
        /// <param name="y">The Y coordinate (latitude).</param>
        /// <param name="cancellationToken">A cancellation token that can be used by the caller to cancel the asynchronous operation.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        [HttpGet("item", Name = $"{nameof(EPWFileController)}_{nameof(GetEPWFileAsync)}")]
        [ApiExplorerSettings(IgnoreApi = false)]
        [ProducesResponseType(typeof(EPWFile), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetEPWFileAsync([FromQuery(Name = "x")] double x, [FromQuery(Name = "y")] double y, CancellationToken cancellationToken = default)
        {
            Serilog.Modify.Log("{Type}:{Name} started", nameof(EPWFileController), nameof(GetEPWFileAsync));
            Serilog.Modify.Log("Coordinates provided: X={X}, Y={Y}", x, y);

            if (ePWFilePostgreSQLConverter is null)
            {
                Serilog.Modify.Log(Serilog.Enums.LogEventLevel.Error, "EPWFilePostgreSQLConverter is null");
                return BadRequest();
            }

            try
            {
                EPWFile? ePWFile = await ePWFilePostgreSQLConverter.GetEPWFileAsync(x, y, cancellationToken);
                if (ePWFile is null)
                {
                    Serilog.Modify.Log("No EPWFile found for coordinates: X={X}, Y={Y}", x, y);
                    return NotFound();
                }

                string? json = ePWFile.ToJsonObject()?.ToJsonString();
                if (string.IsNullOrWhiteSpace(json))
                {
                    return NotFound();
                }

                return Content(json, "application/json");
            }
            catch (Exception exception)
            {
                Serilog.Modify.Log(exception, "Database could not be queried");
                return StatusCode(500, "Internal server error during database query");
            }
        }
    }
}