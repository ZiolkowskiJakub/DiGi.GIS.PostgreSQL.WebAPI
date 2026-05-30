using DiGi.Geometry.Planar.Classes;
using DiGi.GIS.Classes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace DiGi.GIS.PostgreSQL.WebAPI.Classes
{
    /// <summary>
    /// Web API controller for building 2D operations, providing endpoints to retrieve, filter, and update building 2D data.
    /// </summary>
    [ApiController]
    [Route("gis/[controller]")]
    public class Building2DController : DiGi.WebAPI.Classes.WebAPIController
    {
        private readonly PostgreSQL.Classes.Building2DPostgreSQLConverter building2DPostgreSQLConverter;
        private readonly GISPostgreSQLWebAPIConfigurationFileWatcher gISPostgreSQLWebAPIConfigurationFileWatcher;

        /// <summary>
        /// Initializes a new instance of the <see cref="Building2DController"/> class.
        /// </summary>
        public Building2DController(GISPostgreSQLWebAPIConfigurationFileWatcher gISPostgreSQLWebAPIConfigurationFileWatcher, PostgreSQL.Classes.Building2DPostgreSQLConverter building2DPostgreSQLConverter)
        {
            this.gISPostgreSQLWebAPIConfigurationFileWatcher = gISPostgreSQLWebAPIConfigurationFileWatcher;
            this.building2DPostgreSQLConverter = building2DPostgreSQLConverter;
        }

        /// <summary>
        /// Retrieves a building 2D reference by its identifier.
        /// </summary>
        [HttpGet("building2Dreferencebyid", Name = $"{nameof(Building2DController)}_{nameof(GetBuilding2DReferenceByIdAsync)}")]
        [ApiExplorerSettings(IgnoreApi = false)]
        [ProducesResponseType(typeof(PostgreSQL.Classes.Building2DReference), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GetBuilding2DReferenceByIdAsync([FromQuery(Name = "id")] long id, [FromQuery(Name = "countyid")] int? countyId)
        {
            Serilog.Modify.Log("{Type}:{Name} started", nameof(Building2DController), nameof(GetBuilding2DReferenceByIdAsync));

            PostgreSQL.Classes.Building2DReference? building2DReference = await building2DPostgreSQLConverter.GetBuilding2DReferenceByIdAsync(id, countyId);
            if (building2DReference is null)
            {
                return NoContent();
            }

            string? json = Core.Convert.ToSystem_String(building2DReference);
            if (string.IsNullOrWhiteSpace(json))
            {
                return NoContent();
            }

            return Content(json, "application/json");
        }

        /// <summary>
        /// Retrieves a building 2D reference by its reference code.
        /// </summary>
        [HttpGet("building2Dreferencebyreference", Name = $"{nameof(Building2DController)}_{nameof(GetBuilding2DReferenceByReferenceAsync)}")]
        [ApiExplorerSettings(IgnoreApi = false)]
        [ProducesResponseType(typeof(PostgreSQL.Classes.Building2DReference), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GetBuilding2DReferenceByReferenceAsync([FromQuery(Name = "reference")] string reference, [FromQuery(Name = "countyid")] int? countyId)
        {
            Serilog.Modify.Log("{Type}:{Name} started", nameof(Building2DController), nameof(GetBuilding2DReferenceByReferenceAsync));

            PostgreSQL.Classes.Building2DReference? building2DReference = await building2DPostgreSQLConverter.GetBuilding2DReferenceByReferenceAsync(reference, countyId);
            if (building2DReference is null)
            {
                return NoContent();
            }

            string? json = Core.Convert.ToSystem_String(building2DReference);
            if (string.IsNullOrWhiteSpace(json))
            {
                return NoContent();
            }

            return Content(json, "application/json");
        }

        /// <summary>
        /// Retrieves building 2D references filtered by administrative area 2D identifier.
        /// </summary>
        [HttpGet("building2Dreferencesbyadministrativeareal2Did", Name = $"{nameof(Building2DController)}_{nameof(GetBuilding2DReferencesByAdministrativeAreal2DIdAsync)}")]
        [ApiExplorerSettings(IgnoreApi = false)]
        [ProducesResponseType(typeof(List<PostgreSQL.Classes.Building2DReference>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GetBuilding2DReferencesByAdministrativeAreal2DIdAsync([FromQuery(Name = "administrativeareal2Did")] int administrativeAreal2DId)
        {
            Serilog.Modify.Log("{Type}:{Name} started", nameof(Building2DController), nameof(GetBuilding2DReferencesByAdministrativeAreal2DIdAsync));

            List<PostgreSQL.Classes.Building2DReference>? building2DReferences = await building2DPostgreSQLConverter.GetBuilding2DReferencesByAdministrativeAreal2DIdsAsync([administrativeAreal2DId]);
            string? json = Core.Convert.ToSystem_String(building2DReferences);
            if (string.IsNullOrWhiteSpace(json))
            {
                return NoContent();
            }

            return Content(json, "application/json");
        }

        /// <summary>
        /// Retrieves a building 2D item by its identifier.
        /// </summary>
        [HttpGet("itembyid", Name = $"{nameof(Building2DController)}_{nameof(GetItemByIdAsync)}")]
        [ProducesResponseType(typeof(List<PostgreSQL.Classes.Building2D>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GetItemByIdAsync([FromQuery(Name = "id")] long id, [FromQuery(Name = "countyid")] int? countyId)
        {
            Serilog.Modify.Log("{Type}:{Name} started", nameof(Building2DController), nameof(GetItemByIdAsync));

            PostgreSQL.Classes.Building2D? building2D = await building2DPostgreSQLConverter.GetBuilding2DByIdAsync(id, countyId);
            if (building2D is null)
            {
                return NoContent();
            }

            Building2D? building2D_DiGi = building2D.ToDiGi();
            if (building2D_DiGi is null)
            {
                return NoContent();
            }

            string? json = Core.Convert.ToSystem_String(building2D_DiGi);
            if (string.IsNullOrWhiteSpace(json))
            {
                return NoContent();
            }

            return Content(json, "application/json");
        }

        /// <summary>
        /// Retrieves a building 2D item at or near a specified point.
        /// </summary>
        [HttpGet("itembypoint", Name = $"{nameof(Building2DController)}_{nameof(GetItemByPointAsync)}")]
        [ProducesResponseType(typeof(PostgreSQL.Classes.Building2D), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetItemByPointAsync([FromQuery(Name = "x")] double x, [FromQuery(Name = "y")] double y, [FromQuery(Name = "tolerance")] double? tolerance)
        {
            if (double.IsNaN(x) || double.IsNaN(y))
            {
                return BadRequest();
            }

            if (tolerance is null || double.IsNaN(tolerance.Value))
            {
                tolerance = Core.Constants.Tolerance.MacroDistance;
            }

            PostgreSQL.Classes.Building2D? building2D_PostgreSQL = await building2DPostgreSQLConverter.GetBuilding2DByPoint2DAsync(new Point2D(x, y), tolerance.Value);
            if (building2D_PostgreSQL is null)
            {
                return NoContent();
            }

            if (building2D_PostgreSQL.ToDiGi() is not Building2D building2D)
            {
                return NoContent();
            }

            string? json = Core.Convert.ToSystem_String(building2D);
            if (string.IsNullOrWhiteSpace(json))
            {
                return NoContent();
            }

            return Content(json, "application/json");
        }

        /// <summary>
        /// Retrieves a building 2D item by its reference code.
        /// </summary>
        [HttpGet("itembyreference", Name = $"{nameof(Building2DController)}_{nameof(GetItemByReferenceAsync)}")]
        [ProducesResponseType(typeof(PostgreSQL.Classes.Building2D), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GetItemByReferenceAsync([FromQuery(Name = "reference")] string reference, [FromQuery(Name = "countyid")] int? countyId)
        {
            Serilog.Modify.Log("{Type}:{Name} started", nameof(Building2DController), nameof(GetItemByReferenceAsync));

            PostgreSQL.Classes.Building2D? building2D = await building2DPostgreSQLConverter.GetBuilding2DByReferenceAsync(reference, countyId);
            if (building2D is null)
            {
                return NoContent();
            }

            string? json = Core.Convert.ToSystem_String(building2D.ToDiGi());
            if (string.IsNullOrWhiteSpace(json))
            {
                return NoContent();
            }

            return Content(json, "application/json");
        }

        /// <summary>
        /// Retrieves building 2D items within a specified bounding box.
        /// </summary>
        [HttpGet("itemsbyboundingbox", Name = $"{nameof(Building2DController)}_{nameof(GetItemsByBoundingBoxAsync)}")]
        [ProducesResponseType(typeof(List<PostgreSQL.Classes.Building2D>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetItemsByBoundingBoxAsync([FromQuery(Name = "x_1")] double x_1, [FromQuery(Name = "y_1")] double y_1, [FromQuery(Name = "x_2")] double x_2, [FromQuery(Name = "y_2")] double y_2, [FromQuery(Name = "tolerance")] double? tolerance)
        {
            if (double.IsNaN(x_1) || double.IsNaN(y_1) || double.IsNaN(x_2) || double.IsNaN(y_2))
            {
                return BadRequest();
            }

            if (tolerance is null || double.IsNaN(tolerance.Value))
            {
                tolerance = Core.Constants.Tolerance.MacroDistance;
            }

            List<PostgreSQL.Classes.Building2D>? building2Ds_PostgreSQL = await building2DPostgreSQLConverter.GetBuilding2DsByBoundingBox2DAsync(new BoundingBox2D(new Core.Classes.Range<double>(x_1, x_2), new Core.Classes.Range<double>(y_1, y_2)), tolerance.Value);
            if (building2Ds_PostgreSQL is null || building2Ds_PostgreSQL.Count == 0)
            {
                return NoContent();
            }

            List<Building2D> building2Ds = [];
            foreach (PostgreSQL.Classes.Building2D building2D_PostgreSQL in building2Ds_PostgreSQL)
            {
                Building2D? building2D = building2D_PostgreSQL.ToDiGi();
                if (building2D is null)
                {
                    continue;
                }

                building2Ds.Add(building2D);
            }

            if (building2Ds is null || building2Ds.Count == 0)
            {
                return NoContent();
            }

            string? json = Core.Convert.ToSystem_String(building2Ds);
            if (string.IsNullOrWhiteSpace(json))
            {
                return NoContent();
            }

            return Content(json, "application/json");
        }

        /// <summary>
        /// Retrieves building 2D items by their references.
        /// </summary>
        [HttpGet("itemsbybuilding2Dreferences", Name = $"{nameof(Building2DController)}_{nameof(GetItemsByBuilding2DReferencesAsync)}")]
        [ProducesResponseType(typeof(List<PostgreSQL.Classes.Building2D>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetItemsByBuilding2DReferencesAsync([FromBody] JsonArray? jsonArray)
        {
            Serilog.Modify.Log("{Type}:{Name} started", nameof(Building2DController), nameof(GetItemsByBuilding2DReferencesAsync));

            if (jsonArray is null || jsonArray.Count == 0)
            {
                return BadRequest("The provided JSON array is null or empty.");
            }

            // Explicit typing instead of 'var' as requested
            List<PostgreSQL.Classes.Building2DReference>? building2DReferences =
                Core.Create.SerializableObjects<PostgreSQL.Classes.Building2DReference>(jsonArray);

            if (building2DReferences is null)
            {
                Serilog.Modify.Log(Serilog.Enums.LogEventLevel.Error, "Building2DReferences could not be converted from json");
                return BadRequest("Building2DReferences could not be converted from JSON.");
            }

            List<PostgreSQL.Classes.Building2D>? building2Ds_PostgreSQL =
                await building2DPostgreSQLConverter.GetBuilding2DsByBuilding2DReferences(building2DReferences);

            if (building2Ds_PostgreSQL is null || building2Ds_PostgreSQL.Count == 0)
            {
                return NoContent();
            }

            List<Building2D> building2Ds = [];
            foreach (PostgreSQL.Classes.Building2D building2D_PostgreSQL in building2Ds_PostgreSQL)
            {
                Building2D? building2D = building2D_PostgreSQL.ToDiGi();
                if (building2D is null)
                {
                    continue;
                }

                building2Ds.Add(building2D);
            }

            if (building2Ds.Count == 0)
            {
                return NoContent();
            }

            // Returning OK (200) with the serialized string
            string? json = Core.Convert.ToSystem_String(building2Ds);
            if (string.IsNullOrWhiteSpace(json))
            {
                return NoContent();
            }

            return Content(json, "application/json");
        }

        /// <summary>
        /// Retrieves building 2D items within a specified circle.
        /// </summary>
        [HttpGet("itemsbycircle", Name = $"{nameof(Building2DController)}_{nameof(GetItemsByCircleAsync)}")]
        [ProducesResponseType(typeof(List<PostgreSQL.Classes.Building2D>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetItemsByCircleAsync([FromQuery(Name = "x")] double x, [FromQuery(Name = "y")] double y, [FromQuery(Name = "radius")] double? radius, [FromQuery(Name = "diameter")] double? diameter, [FromQuery(Name = "tolerance")] double? tolerance)
        {
            if (double.IsNaN(x) || double.IsNaN(y))
            {
                return BadRequest();
            }

            if ((radius is null || !radius.HasValue || double.IsNaN(radius.Value)) && (diameter is null || !diameter.HasValue || double.IsNaN(diameter.Value)))
            {
                return BadRequest();
            }

            double radius_Temp = double.NaN;
            if (radius is not null && !double.IsNaN(radius.Value))
            {
                radius_Temp = radius.Value;
            }

            if (double.IsNaN(radius_Temp))
            {
                if (diameter is not null && !double.IsNaN(diameter.Value))
                {
                    radius_Temp = diameter.Value / 2;
                }
            }

            if (double.IsNaN(radius_Temp))
            {
                return BadRequest();
            }

            if (tolerance is null || double.IsNaN(tolerance.Value))
            {
                tolerance = Core.Constants.Tolerance.MacroDistance;
            }

            List<PostgreSQL.Classes.Building2D>? building2Ds_PostgreSQL = await building2DPostgreSQLConverter.GetBuilding2DsByCircle2DAsync(new Circle2D(new Point2D(x, y), radius_Temp), tolerance.Value);
            if (building2Ds_PostgreSQL is null || building2Ds_PostgreSQL.Count == 0)
            {
                return NoContent();
            }

            List<Building2D> building2Ds = [];
            foreach (PostgreSQL.Classes.Building2D building2D_PostgreSQL in building2Ds_PostgreSQL)
            {
                Building2D? building2D = building2D_PostgreSQL.ToDiGi();
                if (building2D is null)
                {
                    continue;
                }

                building2Ds.Add(building2D);
            }

            if (building2Ds is null || building2Ds.Count == 0)
            {
                return NoContent();
            }

            string? json = Core.Convert.ToSystem_String(building2Ds);
            if (string.IsNullOrWhiteSpace(json))
            {
                return NoContent();
            }

            return Content(json, "application/json");
        }

        /// <summary>
        /// Retrieves Point2D coordinates by their references.
        /// </summary>
        [HttpGet("point2dsbyreferences", Name = $"{nameof(Building2DController)}_{nameof(GetPoint2DsByReferencesAsync)}")]
        [ProducesResponseType(typeof(List<Point2D>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GetPoint2DsByReferencesAsync([FromBody] IEnumerable<string> references, [FromQuery(Name = "countyid")] int? countyId)
        {
            Serilog.Modify.Log("{Type}:{Name} started", nameof(Building2DController), nameof(GetPoint2DsByReferencesAsync));

            List<Point2D>? point2Ds = await building2DPostgreSQLConverter.GetPoint2DsByReferences(references, countyId);
            if (point2Ds is null)
            {
                return NoContent();
            }

            string? json = Core.Convert.ToSystem_String(point2Ds);
            if (string.IsNullOrWhiteSpace(json))
            {
                return NoContent();
            }

            return Content(json, "application/json");
        }

        /// <summary>
        /// Updates a single building 2D item.
        /// </summary>
        [HttpPost("updateitem", Name = $"{nameof(Building2DController)}_{nameof(UpdateItemAsync)}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateItemAsync([FromBody] JsonObject? jsonObject, [FromQuery(Name = "code")] string? code)
        {
            if (!gISPostgreSQLWebAPIConfigurationFileWatcher.AllowUpdateBuilding2D)
            {
                return Unauthorized();
            }

            if (jsonObject is null)
            {
                return NoContent();
            }

            Building2D? building2D = Core.Create.SerializableObject<Building2D>(jsonObject);
            if (building2D is null)
            {
                return BadRequest();
            }

            PostgreSQL.Classes.Building2D? building2D_PostgreSQL = building2D.ToPostgreSQL(code);
            if (building2D_PostgreSQL is null)
            {
                return BadRequest();
            }

            await building2DPostgreSQLConverter.UpdateAsync([building2D_PostgreSQL]);

            return Ok();
        }

        /// <summary>
        /// Updates multiple building 2D items.
        /// </summary>
        [HttpPost("updateitems", Name = $"{nameof(Building2DController)}_{nameof(UpdateItemsAsync)}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateItemsAsync([FromBody] JsonArray? jsonArray, [FromQuery(Name = "code")] string? code)
        {
            Serilog.Modify.Log("{Type}:{Name} started", nameof(Building2DController), nameof(UpdateItemsAsync));
            Serilog.Modify.Log("Code provided: {Code}", code ?? string.Empty);

            if (!gISPostgreSQLWebAPIConfigurationFileWatcher.AllowUpdateBuilding2D)
            {
                Serilog.Modify.Log(Serilog.Enums.LogEventLevel.Warning, "Building2D update not allowed");
                return BadRequest();
            }

            if (jsonArray is null || jsonArray.Count == 0)
            {
                Serilog.Modify.Log("No Building2Ds to update");
                return NoContent();
            }

            List<Building2D>? building2Ds = Core.Create.SerializableObjects<Building2D>(jsonArray);
            if (building2Ds is null)
            {
                Serilog.Modify.Log(Serilog.Enums.LogEventLevel.Error, "Building2Ds could not be converted from json");
                return BadRequest();
            }

            Serilog.Modify.Log("Building2Ds conversion to PostgreSQL started. Building2Ds count: {Count}", building2Ds.Count);

            List<PostgreSQL.Classes.Building2D> building2Ds_PostgreSQL = [];
            foreach (Building2D building2D in building2Ds)
            {
                PostgreSQL.Classes.Building2D? building2D_PostgreSQL = building2D.ToPostgreSQL(code);
                if (building2D_PostgreSQL is null)
                {
                    continue;
                }

                building2Ds_PostgreSQL.Add(building2D_PostgreSQL);
            }

            if (building2Ds_PostgreSQL is null || building2Ds_PostgreSQL.Count == 0)
            {
                Serilog.Modify.Log("No Building2Ds PostgreSQL to update");
                return NoContent();
            }

            Serilog.Modify.Log("Building2Ds conversion to PostgreSQL ended. Building2Ds converted: {After}/{Before}", building2Ds_PostgreSQL.Count, building2Ds.Count);

            Serilog.Modify.Log("Updating to database starting");

            HashSet<long>? ids = null;
            try
            {
                ids = await building2DPostgreSQLConverter.UpdateAsync(building2Ds_PostgreSQL);
            }
            catch (Exception exception)
            {
                Serilog.Modify.Log(exception, "Database could not be updated");
            }

            if (ids is null || ids.Count == 0)
            {
                Serilog.Modify.Log(Serilog.Enums.LogEventLevel.Warning, "Updating to database ended but no Building2Ds have been updated");
            }
            else
            {
                Serilog.Modify.Log("Updating to database ended. Updated Building2Ds: {After}/{Before}", ids?.Count ?? 0, building2Ds_PostgreSQL.Count);
            }

            return Ok();
        }
    }
}