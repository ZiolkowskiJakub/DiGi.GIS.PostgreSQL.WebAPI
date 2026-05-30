using DiGi.Geometry.Planar.Classes;
using DiGi.GIS.PostgreSQL.Classes;
using DiGi.GIS.PostgreSQL.Enums;
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
    /// Web API controller for administrative area 2D operations, providing endpoints to retrieve, filter, and update administrative area data.
    /// </summary>
    [ApiController]
    [Route("gis/[controller]")]
    public class AdministrativeAreal2DController : WebAPIController
    {
        private readonly AdministrativeAreal2DPostgreSQLConverter administrativeAreal2DPostgreSQLConverter;
        private readonly GISPostgreSQLWebAPIConfigurationFileWatcher gISPostgreSQLWebAPIConfigurationFileWatcher;

        /// <summary>
        /// Initializes a new instance of the <see cref="AdministrativeAreal2DController"/> class.
        /// </summary>
        public AdministrativeAreal2DController(GISPostgreSQLWebAPIConfigurationFileWatcher gISPostgreSQLWebAPIConfigurationFileWatcher, AdministrativeAreal2DPostgreSQLConverter administrativeAreal2DPostgreSQLConverter)
        {
            this.gISPostgreSQLWebAPIConfigurationFileWatcher = gISPostgreSQLWebAPIConfigurationFileWatcher;
            this.administrativeAreal2DPostgreSQLConverter = administrativeAreal2DPostgreSQLConverter;
        }

        /// <summary>
        /// Gets an administrative area reference by its code and type.
        /// </summary>
        [HttpGet("administrativeareal2Dreferencebycode", Name = $"{nameof(AdministrativeAreal2DController)}_{nameof(GetAdministrativeAreal2DReferenceByCodeAsync)}")]
        [ApiExplorerSettings(IgnoreApi = false)]
        [ProducesResponseType(typeof(AdministrativeAreal2DReference), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAdministrativeAreal2DReferenceByCodeAsync([FromQuery(Name = "code")] string? code, [FromQuery(Name = "administrativearealtype")] AdministrativeArealType? administrativeArealType)
        {
            Serilog.Modify.Log("{Type}:{Name} started", nameof(AdministrativeAreal2DController), nameof(GetAdministrativeAreal2DReferenceByCodeAsync));
            Serilog.Modify.Log("Code provided: {Code}", code ?? string.Empty);
            Serilog.Modify.Log("AdministrativeArealType provided: {AdministrativeArealType}", administrativeArealType?.ToString() ?? string.Empty);

            if (string.IsNullOrWhiteSpace(code))
            {
                Serilog.Modify.Log(Serilog.Enums.LogEventLevel.Warning, "Invalid code provided");
                return BadRequest();
            }

            AdministrativeAreal2DReference? administrativeAreal2DReference = await administrativeAreal2DPostgreSQLConverter.GetAdministrativeAreal2DReferenceByCodeAsync(code, administrativeArealType);
            string? json = Core.Convert.ToSystem_String(administrativeAreal2DReference);
            if (string.IsNullOrWhiteSpace(json))
            {
                return NoContent();
            }

            return Content(json, "application/json");
        }

        /// <summary>
        /// Retrieves an administrative area reference by its identifier.
        /// </summary>
        [HttpGet("administrativeareal2Dreferencebyid", Name = $"{nameof(AdministrativeAreal2DController)}_{nameof(GetAdministrativeAreal2DReferenceByIdAsync)}")]
        [ApiExplorerSettings(IgnoreApi = false)]
        [ProducesResponseType(typeof(AdministrativeAreal2DReference), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GetAdministrativeAreal2DReferenceByIdAsync([FromQuery(Name = "id")] int id)
        {
            Serilog.Modify.Log("{Type}:{Name} started", nameof(AdministrativeAreal2DController), nameof(GetAdministrativeAreal2DReferenceByCodeAsync));
            Serilog.Modify.Log("Id provided: {Id}", id);

            AdministrativeAreal2DReference? administrativeAreal2DReference = await administrativeAreal2DPostgreSQLConverter.GetAdministrativeAreal2DReferenceByIdAsync(id);

            string? json = Core.Convert.ToSystem_String(administrativeAreal2DReference);
            if (string.IsNullOrWhiteSpace(json))
            {
                return NoContent();
            }

            return Content(json, "application/json");
        }

        /// <summary>
        /// Retrieves the administrative area reference path by its identifier.
        /// </summary>
        [HttpGet("administrativeareal2Dreferencepathbyid", Name = $"{nameof(AdministrativeAreal2DController)}_{nameof(GetAdministrativeAreal2DReferencePathByIdAsync)}")]
        [ApiExplorerSettings(IgnoreApi = false)]
        [ProducesResponseType(typeof(AdministrativeAreal2DReferencePath), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GetAdministrativeAreal2DReferencePathByIdAsync([FromQuery(Name = "id")] int id)
        {
            AdministrativeAreal2DReferencePath? administrativeAreal2DReferencePath = await administrativeAreal2DPostgreSQLConverter.GetAdministrativeAreal2DReferencePathAsync(id);
            string? json = Core.Convert.ToSystem_String(administrativeAreal2DReferencePath);
            if (string.IsNullOrWhiteSpace(json))
            {
                return NoContent();
            }

            return Content(json, "application/json");
        }

        /// <summary>
        /// Retrieves administrative area reference paths by name.
        /// </summary>
        [HttpPost("administrativeareal2Dreferencepathsbyname", Name = $"{nameof(AdministrativeAreal2DController)}_{nameof(GetAdministrativeAreal2DReferencePathsByNameAsync)}")]
        [ApiExplorerSettings(IgnoreApi = false)]
        [ProducesResponseType(typeof(List<AdministrativeAreal2DReferencePath>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GetAdministrativeAreal2DReferencePathsByNameAsync([FromBody] string text, CancellationToken cancellationToken = default)
        {
            try
            {
                // Explicit typing as requested. Passing CancellationToken to the DLL logic.
                List<AdministrativeAreal2DReferencePath>? administrativeAreal2DReferencePaths = await administrativeAreal2DPostgreSQLConverter.GetAdministrativeAreal2DReferencePathsByNameAsync(text, cancellationToken);

                if (administrativeAreal2DReferencePaths is null)
                {
                    return NoContent();
                }

                // Converting the list to a JSON string using your specialized DLL converter.
                string? json = Core.Convert.ToSystem_String(administrativeAreal2DReferencePaths);
                if (string.IsNullOrWhiteSpace(json))
                {
                    return NoContent();
                }

                // Returning the string directly as application/json avoids double serialization.
                return Content(json, "application/json");
            }
            catch (Exception)
            {
                // Log the exception details here using a logging provider (e.g., Serilog)
                return StatusCode(500, "An error occurred while processing the geospatial data.");
            }
        }

        /// <summary>
        /// Retrieves all administrative area references filtered by administrative area type.
        /// </summary>
        [HttpGet("administrativeareal2Dreferencesbyadministrativearealtype", Name = $"{nameof(AdministrativeAreal2DController)}_{nameof(GetAdministrativeAreal2DReferencesByAdministrativeArealTypeAsync)}")]
        [ApiExplorerSettings(IgnoreApi = false)]
        [ProducesResponseType(typeof(List<AdministrativeAreal2DReference>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GetAdministrativeAreal2DReferencesByAdministrativeArealTypeAsync([FromQuery(Name = "administrativearealtype")] AdministrativeArealType administrativeArealType, [FromQuery(Name = "parentId")] int? parentId, [FromQuery(Name = "uniquecode")] bool? uniqueCode)
        {
            List<AdministrativeAreal2DReference>? administrativeAreal2DReferences = await administrativeAreal2DPostgreSQLConverter.GetAdministrativeAreal2DReferencesByAdministrativeArealTypeAsync(administrativeArealType, parentId, uniqueCode ?? false);
            string? json = Core.Convert.ToSystem_String(administrativeAreal2DReferences);
            if (string.IsNullOrWhiteSpace(json))
            {
                return NoContent();
            }

            return Content(json, "application/json");
        }

        /// <summary>
        /// Retrieves administrative area references by their code.
        /// </summary>
        [HttpGet("administrativeareal2Dreferencesbycode", Name = $"{nameof(AdministrativeAreal2DController)}_{nameof(GetAdministrativeAreal2DReferencesByCodeAsync)}")]
        [ApiExplorerSettings(IgnoreApi = false)]
        [ProducesResponseType(typeof(List<AdministrativeAreal2DReference>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAdministrativeAreal2DReferencesByCodeAsync([FromQuery(Name = "code")] string code, [FromQuery(Name = "administrativearealtype")] AdministrativeArealType? administrativeArealType)
        {
            Serilog.Modify.Log("{Type}:{Name} started", nameof(AdministrativeAreal2DController), nameof(GetAdministrativeAreal2DReferencesByCodeAsync));
            Serilog.Modify.Log("Code provided: {Code}", code ?? string.Empty);
            Serilog.Modify.Log("AdministrativeArealType provided: {AdministrativeArealType}", administrativeArealType?.ToString() ?? string.Empty);

            if (string.IsNullOrWhiteSpace(code))
            {
                Serilog.Modify.Log(Serilog.Enums.LogEventLevel.Warning, "Invalid code provided");
                return BadRequest();
            }

            List<AdministrativeAreal2DReference>? administrativeAreal2DReferences = null;

            if (administrativeArealType != null)
            {
                administrativeAreal2DReferences = await administrativeAreal2DPostgreSQLConverter.GetAdministrativeAreal2DReferencesByCodeAsync(code, administrativeArealType.Value);
            }
            else
            {
                administrativeAreal2DReferences = await administrativeAreal2DPostgreSQLConverter.GetAdministrativeAreal2DReferencesByCodeAsync(code);
            }

            string? json = Core.Convert.ToSystem_String(administrativeAreal2DReferences);
            if (string.IsNullOrWhiteSpace(json))
            {
                return NoContent();
            }

            Serilog.Modify.Log("Number of AdministrativeAreal2DReferences to be returned: {Count}", administrativeAreal2DReferences!.Count);
            return Content(json, "application/json");
        }

        /// <summary>
        /// Retrieves all available codes.
        /// </summary>
        [HttpGet("codes", Name = $"{nameof(AdministrativeAreal2DController)}_{nameof(GetCodesAsync)}")]
        [ApiExplorerSettings(IgnoreApi = false)]
        [ProducesResponseType(typeof(List<string>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GetCodesAsync()
        {
            HashSet<string>? codes = await administrativeAreal2DPostgreSQLConverter.GetCodesAsync();
            if (codes is null || codes.Count == 0)
            {
                return NoContent();
            }

            JsonArray jsonArray = [.. codes];

            string? json = jsonArray.ToJsonString();
            if (string.IsNullOrWhiteSpace(json))
            {
                return NoContent();
            }

            return Content(json, "application/json");
        }

        /// <summary>
        /// Retrieves the identifier for a given code.
        /// </summary>
        [HttpGet("idbycode", Name = $"{nameof(AdministrativeAreal2DController)}_{nameof(GetIdByCodeAsync)}")]
        [ApiExplorerSettings(IgnoreApi = false)]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetIdByCodeAsync([FromQuery(Name = "code")] string code, [FromQuery(Name = "administrativearealtype")] AdministrativeArealType? administrativeArealType)
        {
            if (string.IsNullOrWhiteSpace(code))
            {
                return BadRequest();
            }

            int? id = await administrativeAreal2DPostgreSQLConverter.GetIdByCodeAsync(code, administrativeArealType);
            if (id is null || !id.HasValue)
            {
                return NotFound();
            }

            return Ok(id.Value);
        }

        /// <summary>
        /// Retrieves an administrative area item by its code.
        /// </summary>
        [HttpGet("itembycode", Name = $"{nameof(AdministrativeAreal2DController)}_{nameof(GetItemByCodeAsync)}")]
        [ProducesResponseType(typeof(GIS.Classes.AdministrativeAreal2D), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetItemByCodeAsync([FromQuery(Name = "code")] string code)
        {
            if (string.IsNullOrWhiteSpace(code))
            {
                return BadRequest();
            }

            AdministrativeAreal2D? administrativeAreal2D_PostgreSQL = await administrativeAreal2DPostgreSQLConverter.GetAdministrativeAreal2DByCodeAsync(code);
            if (administrativeAreal2D_PostgreSQL is null)
            {
                return NoContent();
            }

            GIS.Classes.AdministrativeAreal2D? administrativeAreal2D = administrativeAreal2D_PostgreSQL.ToDiGi();
            string? json = Core.Convert.ToSystem_String(administrativeAreal2D);
            if (string.IsNullOrWhiteSpace(json))
            {
                return NoContent();
            }

            return Content(json, "application/json");
        }

        /// <summary>
        /// Retrieves an administrative area item by its identifier.
        /// </summary>
        [HttpGet("itembyid", Name = $"{nameof(AdministrativeAreal2DController)}_{nameof(GetItemByIdAsync)}")]
        [ProducesResponseType(typeof(GIS.Classes.AdministrativeAreal2D), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetItemByIdAsync([FromQuery(Name = "id")] int id)
        {
            AdministrativeAreal2D? administrativeAreal2D_PostgreSQL = await administrativeAreal2DPostgreSQLConverter.GetAdministrativeAreal2DByIdAsync(id);
            if (administrativeAreal2D_PostgreSQL is null)
            {
                return NoContent();
            }

            GIS.Classes.AdministrativeAreal2D? administrativeAreal2D = administrativeAreal2D_PostgreSQL.ToDiGi();
            string? json = Core.Convert.ToSystem_String(administrativeAreal2D);
            if (string.IsNullOrWhiteSpace(json))
            {
                return NoContent();
            }

            return Content(json, "application/json");
        }

        /// <summary>
        /// Retrieves all administrative area items filtered by administrative area type.
        /// </summary>
        [HttpGet("itemsbyadministrativearealtype", Name = $"{nameof(AdministrativeAreal2DController)}_{nameof(GetItemsByAdministrativeArealTypeAsync)}")]
        [ProducesResponseType(typeof(List<GIS.Classes.AdministrativeAreal2D>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetItemsByAdministrativeArealTypeAsync([FromQuery(Name = "administrativearealtype")] AdministrativeArealType administrativeArealType)
        {
            Serilog.Modify.Log("{Type}:{Name} started", nameof(AdministrativeAreal2DController), nameof(GetAdministrativeAreal2DReferenceByCodeAsync));
            Serilog.Modify.Log("AdministrativeArealType provided: {AdministrativeArealType}", administrativeArealType.ToString() ?? string.Empty);

            if (administrativeArealType == AdministrativeArealType.Undefined)
            {
                Serilog.Modify.Log(Serilog.Enums.LogEventLevel.Warning, "Invalid AdministrativeArealType provided");
                return BadRequest();
            }

            List<AdministrativeAreal2D>? administrativeAreal2Ds_PostgreSQL = await administrativeAreal2DPostgreSQLConverter.GetAdministrativeAreal2DsByAdministrativeArealTypeAsync(administrativeArealType);
            if (administrativeAreal2Ds_PostgreSQL is null)
            {
                Serilog.Modify.Log("No content found");
                return NoContent();
            }

            Serilog.Modify.Log("content found: {Count} items", administrativeAreal2Ds_PostgreSQL.Count);

            List<GIS.Classes.AdministrativeAreal2D> administrativeAreal2Ds = [];
            foreach (AdministrativeAreal2D administrativeAreal2D_PostgreSQL in administrativeAreal2Ds_PostgreSQL)
            {
                GIS.Classes.AdministrativeAreal2D? administrativeAreal2D = administrativeAreal2D_PostgreSQL.ToDiGi();
                if (administrativeAreal2D is null)
                {
                    continue;
                }

                administrativeAreal2Ds.Add(administrativeAreal2D);
            }

            if (administrativeAreal2Ds is null || administrativeAreal2Ds.Count == 0)
            {
                Serilog.Modify.Log("No content found");
                return NoContent();
            }

            Serilog.Modify.Log("{Count} items converted to GIS", administrativeAreal2Ds.Count);

            string? json = Core.Convert.ToSystem_String(administrativeAreal2Ds);
            if (string.IsNullOrWhiteSpace(json))
            {
                return NoContent();
            }

            return Content(json, "application/json");
        }

        /// <summary>
        /// Retrieves administrative area items within a specified bounding box.
        /// </summary>
        [HttpGet("itemsbyboundingbox", Name = $"{nameof(AdministrativeAreal2DController)}_{nameof(GetItemsByBoundingBoxAsync)}")]
        [ProducesResponseType(typeof(List<GIS.Classes.AdministrativeAreal2D>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetItemsByBoundingBoxAsync([FromQuery(Name = "x_1")] double x_1, [FromQuery(Name = "y_1")] double y_1, [FromQuery(Name = "x_2")] double x_2, [FromQuery(Name = "y_2")] double y_2, [FromQuery(Name = "tolerance")] double? tolerance, [FromQuery(Name = "administrativearealtype")] AdministrativeArealType? administrativeArealType)
        {
            if (double.IsNaN(x_1) || double.IsNaN(y_1) || double.IsNaN(x_2) || double.IsNaN(y_2))
            {
                return BadRequest();
            }

            if (tolerance is null || double.IsNaN(tolerance.Value))
            {
                tolerance = Core.Constants.Tolerance.MacroDistance;
            }

            List<AdministrativeArealType>? administrativeArealTypes = null;
            if (administrativeArealType != null)
            {
                administrativeArealTypes = [administrativeArealType.Value];
            }

            List<AdministrativeAreal2D>? administrativeAreal2Ds_PostgreSQL = await administrativeAreal2DPostgreSQLConverter.GetAdministrativeAreal2DsByBoundingBox2DAsync(new BoundingBox2D(new Core.Classes.Range<double>(x_1, x_2), new Core.Classes.Range<double>(y_1, y_2)), administrativeArealTypes, tolerance.Value);
            if (administrativeAreal2Ds_PostgreSQL is null || administrativeAreal2Ds_PostgreSQL.Count == 0)
            {
                return NoContent();
            }

            List<GIS.Classes.AdministrativeAreal2D> administrativeAreal2Ds = [];
            foreach (AdministrativeAreal2D administrativeAreal2D_PostgreSQL in administrativeAreal2Ds_PostgreSQL)
            {
                GIS.Classes.AdministrativeAreal2D? administrativeAreal2D = administrativeAreal2D_PostgreSQL.ToDiGi();
                if (administrativeAreal2D is null)
                {
                    continue;
                }

                administrativeAreal2Ds.Add(administrativeAreal2D);
            }

            if (administrativeAreal2Ds is null || administrativeAreal2Ds.Count == 0)
            {
                return NoContent();
            }

            string? json = Core.Convert.ToSystem_String(administrativeAreal2Ds);
            if (string.IsNullOrWhiteSpace(json))
            {
                return NoContent();
            }

            return Content(json, "application/json");
        }

        /// <summary>
        /// Retrieves administrative area items within a specified circle.
        /// </summary>
        [HttpGet("itemsbycircle", Name = $"{nameof(AdministrativeAreal2DController)}_{nameof(GetItemsByCircleAsync)}")]
        [ProducesResponseType(typeof(List<GIS.Classes.AdministrativeAreal2D>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetItemsByCircleAsync([FromQuery(Name = "x")] double x, [FromQuery(Name = "y")] double y, [FromQuery(Name = "radius")] double? radius, [FromQuery(Name = "diameter")] double? diameter, [FromQuery(Name = "tolerance")] double? tolerance, [FromQuery(Name = "administrativearealtype")] AdministrativeArealType? administrativeArealType)
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

            List<AdministrativeArealType>? administrativeArealTypes = null;
            if (administrativeArealType != null)
            {
                administrativeArealTypes = [administrativeArealType.Value];
            }

            List<AdministrativeAreal2D>? administrativeAreal2Ds_PostgreSQL = await administrativeAreal2DPostgreSQLConverter.GetAdministrativeAreal2DsByCircle2DAsync(new Circle2D(new Point2D(x, y), radius_Temp), administrativeArealTypes, tolerance.Value);
            if (administrativeAreal2Ds_PostgreSQL is null || administrativeAreal2Ds_PostgreSQL.Count == 0)
            {
                return NoContent();
            }

            List<GIS.Classes.AdministrativeAreal2D> administrativeAreal2Ds = [];
            foreach (AdministrativeAreal2D administrativeAreal2D_PostgreSQL in administrativeAreal2Ds_PostgreSQL)
            {
                GIS.Classes.AdministrativeAreal2D? administrativeAreal2D = administrativeAreal2D_PostgreSQL.ToDiGi();
                if (administrativeAreal2D is null)
                {
                    continue;
                }

                administrativeAreal2Ds.Add(administrativeAreal2D);
            }

            if (administrativeAreal2Ds is null || administrativeAreal2Ds.Count == 0)
            {
                return NoContent();
            }

            string? json = Core.Convert.ToSystem_String(administrativeAreal2Ds);
            if (string.IsNullOrWhiteSpace(json))
            {
                return NoContent();
            }

            return Content(json, "application/json");
        }

        /// <summary>
        /// Retrieves administrative area items filtered by code.
        /// </summary>
        [HttpGet("itemsbycode", Name = $"{nameof(AdministrativeAreal2DController)}_{nameof(GetItemsByCodeAsync)}")]
        [ProducesResponseType(typeof(List<GIS.Classes.AdministrativeAreal2D>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetItemsByCodeAsync([FromQuery(Name = "code")] string code, [FromQuery(Name = "administrativearealtype")] AdministrativeArealType? administrativeArealType)
        {
            if (string.IsNullOrWhiteSpace(code))
            {
                return BadRequest();
            }

            List<AdministrativeAreal2D>? administrativeAreal2Ds_PostgreSQL = await administrativeAreal2DPostgreSQLConverter.GetAdministrativeAreal2DsByCodeAsync(code, administrativeArealType);
            if (administrativeAreal2Ds_PostgreSQL is null || administrativeAreal2Ds_PostgreSQL.Count == 0)
            {
                return NoContent();
            }

            List<GIS.Classes.AdministrativeAreal2D> administrativeAreal2Ds = [];
            foreach (AdministrativeAreal2D administrativeAreal2D_PostgreSQL in administrativeAreal2Ds_PostgreSQL)
            {
                GIS.Classes.AdministrativeAreal2D? administrativeAreal2D = administrativeAreal2D_PostgreSQL.ToDiGi();
                if (administrativeAreal2D is null)
                {
                    continue;
                }

                administrativeAreal2Ds.Add(administrativeAreal2D);
            }

            if (administrativeAreal2Ds is null || administrativeAreal2Ds.Count == 0)
            {
                return NoContent();
            }

            string? json = Core.Convert.ToSystem_String(administrativeAreal2Ds);
            if (string.IsNullOrWhiteSpace(json))
            {
                return NoContent();
            }

            return Content(json, "application/json");
        }

        /// <summary>
        /// Retrieves administrative area items filtered by multiple codes.
        /// </summary>
        [HttpGet("itemsbycodes", Name = $"{nameof(AdministrativeAreal2DController)}_{nameof(GetItemsByCodesAsync)}")]
        [ProducesResponseType(typeof(List<GIS.Classes.AdministrativeAreal2D>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetItemsByCodesAsync([FromBody] List<string> codes)
        {
            if (codes == null || codes.Count == 0)
            {
                return BadRequest();
            }

            List<AdministrativeAreal2D>? administrativeAreal2Ds_PostgreSQL = await administrativeAreal2DPostgreSQLConverter.GetAdministrativeAreal2DsByCodesAsync(codes);
            if (administrativeAreal2Ds_PostgreSQL is null || administrativeAreal2Ds_PostgreSQL.Count == 0)
            {
                return NoContent();
            }

            List<GIS.Classes.AdministrativeAreal2D> administrativeAreal2Ds = [];
            foreach (AdministrativeAreal2D administrativeAreal2D_PostgreSQL in administrativeAreal2Ds_PostgreSQL)
            {
                GIS.Classes.AdministrativeAreal2D? administrativeAreal2D = administrativeAreal2D_PostgreSQL.ToDiGi();
                if (administrativeAreal2D is null)
                {
                    continue;
                }

                administrativeAreal2Ds.Add(administrativeAreal2D);
            }

            if (administrativeAreal2Ds is null || administrativeAreal2Ds.Count == 0)
            {
                return NoContent();
            }

            string? json = Core.Convert.ToSystem_String(administrativeAreal2Ds);
            if (string.IsNullOrWhiteSpace(json))
            {
                return NoContent();
            }

            return Content(json, "application/json");
        }

        /// <summary>
        /// Retrieves administrative area items at or near a specified point.
        /// </summary>
        [HttpGet("itemsbypoint", Name = $"{nameof(AdministrativeAreal2DController)}_{nameof(GetItemsByPointAsync)}")]
        [ProducesResponseType(typeof(List<GIS.Classes.AdministrativeAreal2D>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetItemsByPointAsync([FromQuery(Name = "x")] double x, [FromQuery(Name = "y")] double y, [FromQuery(Name = "tolerance")] double? tolerance, [FromQuery(Name = "type")] AdministrativeArealType? administrativeArealType)
        {
            if (double.IsNaN(x) || double.IsNaN(y))
            {
                return BadRequest();
            }

            if (tolerance is null || double.IsNaN(tolerance.Value))
            {
                tolerance = Core.Constants.Tolerance.MacroDistance;
            }

            List<AdministrativeArealType>? administrativeArealTypes = null;
            if (administrativeArealType != null)
            {
                administrativeArealTypes = [administrativeArealType.Value];
            }

            List<AdministrativeAreal2D>? administrativeAreal2Ds_PostgreSQL = await administrativeAreal2DPostgreSQLConverter.GetAdministrativeAreal2DsByPoint2DAsync(new Point2D(x, y), administrativeArealTypes, tolerance.Value);
            if (administrativeAreal2Ds_PostgreSQL is null || administrativeAreal2Ds_PostgreSQL.Count == 0)
            {
                return NoContent();
            }

            List<GIS.Classes.AdministrativeAreal2D> administrativeAreal2Ds = [];
            foreach (AdministrativeAreal2D administrativeAreal2D_PostgreSQL in administrativeAreal2Ds_PostgreSQL)
            {
                GIS.Classes.AdministrativeAreal2D? administrativeAreal2D = administrativeAreal2D_PostgreSQL.ToDiGi();
                if (administrativeAreal2D is null)
                {
                    continue;
                }

                administrativeAreal2Ds.Add(administrativeAreal2D);
            }

            if (administrativeAreal2Ds is null || administrativeAreal2Ds.Count == 0)
            {
                return NoContent();
            }

            string? json = Core.Convert.ToSystem_String(administrativeAreal2Ds);
            if (string.IsNullOrWhiteSpace(json))
            {
                return NoContent();
            }

            return Content(json, "application/json");
        }

        /// <summary>
        /// Retrieves subcodes for a given code.
        /// </summary>
        [HttpGet("subcodes", Name = $"{nameof(AdministrativeAreal2DController)}_{nameof(GetSubCodesAsync)}")]
        [ApiExplorerSettings(IgnoreApi = false)]
        [ProducesResponseType(typeof(List<string>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetSubCodesAsync([FromQuery(Name = "code")] string code)
        {
            if (string.IsNullOrWhiteSpace(code))
            {
                return BadRequest();
            }

            HashSet<string>? subcodes = await administrativeAreal2DPostgreSQLConverter.GetSubCodesAsync(code);
            if (subcodes is null || subcodes.Count == 0)
            {
                return NoContent();
            }

            JsonArray jsonArray = [.. subcodes];

            string? json = jsonArray.ToJsonString();
            if (string.IsNullOrWhiteSpace(json))
            {
                return NoContent();
            }

            return Content(json, "application/json");
        }

        /// <summary>
        /// Updates a single administrative area item.
        /// </summary>
        [HttpPost("updateitem", Name = $"{nameof(AdministrativeAreal2DController)}_{nameof(UpdateItemAsync)}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> UpdateItemAsync([FromBody] JsonObject? jsonObject)
        {
            if (!gISPostgreSQLWebAPIConfigurationFileWatcher.AllowUpdateAdministrativeAreal2D)
            {
                return ValidationProblem();
            }

            if (jsonObject is null)
            {
                return NoContent();
            }

            GIS.Classes.AdministrativeAreal2D? administrativeAreal2D = Core.Create.SerializableObject<GIS.Classes.AdministrativeAreal2D>(jsonObject);
            if (administrativeAreal2D is null)
            {
                return BadRequest();
            }

            AdministrativeAreal2D? administrativeAreal2D_PostgreSQL = administrativeAreal2D.ToPostgreSQL();
            if (administrativeAreal2D_PostgreSQL is null)
            {
                return BadRequest();
            }

            HashSet<int>? ids = await administrativeAreal2DPostgreSQLConverter.UpdateAsync([administrativeAreal2D_PostgreSQL]);
            if (ids is null || ids.Count == 0)
            {
                return BadRequest();
            }

            return Ok();
        }

        /// <summary>
        /// Updates multiple administrative area items.
        /// </summary>
        [HttpPost("updateitems", Name = $"{nameof(AdministrativeAreal2DController)}_{nameof(UpdateItemsAsync)}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateItemsAsync([FromBody] JsonArray? jsonArray)
        {
            if (!gISPostgreSQLWebAPIConfigurationFileWatcher.AllowUpdateAdministrativeAreal2D)
            {
                return Unauthorized();
            }

            if (jsonArray is null || jsonArray.Count == 0)
            {
                return NoContent();
            }

            List<GIS.Classes.AdministrativeAreal2D>? administrativeAreal2Ds = Core.Create.SerializableObjects<GIS.Classes.AdministrativeAreal2D>(jsonArray);
            if (administrativeAreal2Ds is null)
            {
                return BadRequest();
            }

            List<AdministrativeAreal2D> administrativeAreal2Ds_PostgreSQL = [];
            foreach (GIS.Classes.AdministrativeAreal2D administrativeAreal2D in administrativeAreal2Ds)
            {
                AdministrativeAreal2D? administrativeAreal2D_PostgreSQL = administrativeAreal2D.ToPostgreSQL();
                if (administrativeAreal2D_PostgreSQL is null)
                {
                    continue;
                }

                administrativeAreal2Ds_PostgreSQL.Add(administrativeAreal2D_PostgreSQL);
            }

            if (administrativeAreal2Ds_PostgreSQL is null || administrativeAreal2Ds_PostgreSQL.Count == 0)
            {
                return NoContent();
            }

            HashSet<int>? ids = await administrativeAreal2DPostgreSQLConverter.UpdateAsync(administrativeAreal2Ds_PostgreSQL);
            if (ids is null || ids.Count == 0)
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}