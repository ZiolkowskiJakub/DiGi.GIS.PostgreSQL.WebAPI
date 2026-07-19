using DiGi.Geometry.Planar.Classes;
using DiGi.GIS.Classes;
using DiGi.GIS.PostgreSQL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace DiGi.GIS.WebAPI.Classes
{
    /// <summary>
    /// Web API controller for building 2D operations, providing endpoints to retrieve, filter, and update building 2D data.
    /// </summary>
    [ApiController]
    [Route("gis/[controller]")]
    public class Building2DController : DiGi.WebAPI.Classes.WebAPIController
    {
        private readonly PostgreSQL.Classes.Building2DPostgreSQLConverter building2DPostgreSQLConverter;
        private readonly GISWebAPIConfigurationFileWatcher GISWebAPIConfigurationFileWatcher;

        /// <summary></summary>
        /// <param name="GISWebAPIConfigurationFileWatcher">The configuration file watcher for the GIS PostgreSQL Web API.</param>
        /// <param name="building2DPostgreSQLConverter">The converter used for Building 2D data operations in PostgreSQL.</param>
        public Building2DController(GISWebAPIConfigurationFileWatcher GISWebAPIConfigurationFileWatcher, PostgreSQL.Classes.Building2DPostgreSQLConverter building2DPostgreSQLConverter)
        {
            this.GISWebAPIConfigurationFileWatcher = GISWebAPIConfigurationFileWatcher;
            this.building2DPostgreSQLConverter = building2DPostgreSQLConverter;
        }

        /// <summary> Asynchronously counts the number of buildings based on the administrative areal 2D identifiers. </summary>
        /// <param name="countByAdministrativeAreal2DIdsParameter">The parameter object containing the collection of administrative areal 2D identifiers.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        [HttpPost("count", Name = $"{nameof(Building2DController)}_{nameof(CountAsync)}")]
        [ProducesResponseType(typeof(long), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CountAsync([FromBody] CountByAdministrativeAreal2DIdsParameter countByAdministrativeAreal2DIdsParameter)
        {
            Serilog.Modify.Log("{Type}:{Name} started", nameof(Building2DController), nameof(CountAsync));

            if (countByAdministrativeAreal2DIdsParameter is null || countByAdministrativeAreal2DIdsParameter.AdministrativeAreal2DIds is null)
            {
                return BadRequest();
            }

            long count = await building2DPostgreSQLConverter.CountAsync(countByAdministrativeAreal2DIdsParameter.AdministrativeAreal2DIds);
            if (count < 0)
            {
                return NotFound();
            }

            return Ok(count);
        }

        /// <summary> Asynchronously retrieves a building 2D reference by its unique identifier and an optional county identifier. </summary>
        /// <param name="id">The unique identifier of the building.</param>
        /// <param name="countyId">An optional integer representing the county identifier used to filter the search.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        [HttpGet("building2Dreferencebyid", Name = $"{nameof(Building2DController)}_{nameof(GetBuilding2DReferenceByIdAsync)}")]
        [ApiExplorerSettings(IgnoreApi = false)]
        [ProducesResponseType(typeof(PostgreSQL.Classes.Building2DReference), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetBuilding2DReferenceByIdAsync([FromQuery(Name = "id")] long id, [FromQuery(Name = "countyid")] int? countyId)
        {
            Serilog.Modify.Log("{Type}:{Name} started", nameof(Building2DController), nameof(GetBuilding2DReferenceByIdAsync));

            PostgreSQL.Classes.Building2DReference? building2DReference = await building2DPostgreSQLConverter.GetBuilding2DReferenceByIdAsync(id, countyId);
            if (building2DReference is null)
            {
                return NotFound();
            }

            string? json = Core.Convert.ToSystem_String(building2DReference);
            if (string.IsNullOrWhiteSpace(json))
            {
                return NotFound();
            }

            return Content(json, "application/json");
        }

        /// <summary> Retrieves a building 2D reference by its unique reference code and an optional county identifier. </summary>
        /// <param name="reference">The unique reference string of the building to retrieve.</param>
        /// <param name="countyId">The optional integer identifier of the county used to filter the search.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        [HttpGet("building2Dreferencebyreference", Name = $"{nameof(Building2DController)}_{nameof(GetBuilding2DReferenceByReferenceAsync)}")]
        [ApiExplorerSettings(IgnoreApi = false)]
        [ProducesResponseType(typeof(PostgreSQL.Classes.Building2DReference), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetBuilding2DReferenceByReferenceAsync([FromQuery(Name = "reference")] string reference, [FromQuery(Name = "countyid")] int? countyId)
        {
            Serilog.Modify.Log("{Type}:{Name} started", nameof(Building2DController), nameof(GetBuilding2DReferenceByReferenceAsync));

            PostgreSQL.Classes.Building2DReference? building2DReference = await building2DPostgreSQLConverter.GetBuilding2DReferenceByReferenceAsync(reference, countyId);
            if (building2DReference is null)
            {
                return NotFound();
            }

            string? json = Core.Convert.ToSystem_String(building2DReference);
            if (string.IsNullOrWhiteSpace(json))
            {
                return NotFound();
            }

            return Content(json, "application/json");
        }

        /// <summary> Retrieves building 2D references filtered by administrative area 2D identifier. Can be used for relatively small number of buildings</summary>
        /// <param name="administrativeAreal2DId">The unique identifier of the administrative area 2D used to filter the building references.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        [HttpGet("building2Dreferencesbyadministrativeareal2Did", Name = $"{nameof(Building2DController)}_{nameof(GetBuilding2DReferencesByAdministrativeAreal2DIdAsync)}")]
        [ApiExplorerSettings(IgnoreApi = false)]
        [ProducesResponseType(typeof(List<PostgreSQL.Classes.Building2DReference>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetBuilding2DReferencesByAdministrativeAreal2DIdAsync([FromQuery(Name = "administrativeareal2Did")] int administrativeAreal2DId)
        {
            Serilog.Modify.Log("{Type}:{Name} started", nameof(Building2DController), nameof(GetBuilding2DReferencesByAdministrativeAreal2DIdAsync));

            List<PostgreSQL.Classes.Building2DReference>? building2DReferences = await building2DPostgreSQLConverter.GetBuilding2DReferencesByAdministrativeAreal2DIdsAsync([administrativeAreal2DId]);
            string? json = Core.Convert.ToSystem_String(building2DReferences);
            if (string.IsNullOrWhiteSpace(json))
            {
                return NotFound();
            }

            return Content(json, "application/json");
        }

        /// <summary>
        /// Retrieves a paginated list of building 2D references.
        /// </summary>
        /// <param name="building2DReferencesByPagingParameter">The parameter containing paging options, including county identifier, cursor, and page size.</param>
        /// <returns>A task representing the asynchronous operation, returning a list of building 2D references.</returns>
        [HttpPost("building2Dreferencesbypagingparameter", Name = $"{nameof(Building2DController)}_{nameof(GetBuilding2DReferencesByPagingParameterAsync)}")]
        [ApiExplorerSettings(IgnoreApi = false)]
        [ProducesResponseType(typeof(List<PostgreSQL.Classes.Building2DReference>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetBuilding2DReferencesByPagingParameterAsync([FromBody] Building2DReferencesByPagingParameter building2DReferencesByPagingParameter)
        {
            Serilog.Modify.Log("{Type}:{Name} started", nameof(Building2DController), nameof(GetBuilding2DReferencesByPagingParameterAsync));

            List<PostgreSQL.Classes.Building2DReference>? building2DReferences = await building2DPostgreSQLConverter.GetBuilding2DReferencesByCountyIdAsync(
                building2DReferencesByPagingParameter.CountyId,
                building2DReferencesByPagingParameter.SubdivisionId,
                building2DReferencesByPagingParameter.Cursor,
                building2DReferencesByPagingParameter.PageSize);

            if (building2DReferences is null || building2DReferences.Count == 0)
            {
                return NotFound();
            }

            string? json = Core.Convert.ToSystem_String(building2DReferences);
            if (string.IsNullOrWhiteSpace(json))
            {
                return NotFound();
            }

            return Content(json, "application/json");
        }

        /// <summary> Retrieves a building 2D item by its identifier. </summary>
        /// <param name="id">The unique identifier of the building 2D item to retrieve.</param>
        /// <param name="countyId">The optional county identifier associated with the building.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        [HttpGet("itembyid", Name = $"{nameof(Building2DController)}_{nameof(GetItemByIdAsync)}")]
        [ProducesResponseType(typeof(List<PostgreSQL.Classes.Building2D>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetItemByIdAsync([FromQuery(Name = "id")] long id, [FromQuery(Name = "countyid")] int? countyId)
        {
            Serilog.Modify.Log("{Type}:{Name} started", nameof(Building2DController), nameof(GetItemByIdAsync));

            PostgreSQL.Classes.Building2D? building2D = await building2DPostgreSQLConverter.GetBuilding2DByIdAsync(id, countyId);
            if (building2D is null)
            {
                return NotFound();
            }

            Building2D? building2D_DiGi = building2D.ToDiGi();
            if (building2D_DiGi is null)
            {
                return NotFound();
            }

            string? json = Core.Convert.ToSystem_String(building2D_DiGi);
            if (string.IsNullOrWhiteSpace(json))
            {
                return NotFound();
            }

            return Content(json, "application/json");
        }

        /// <summary> Retrieves a building 2D item at or near a specified point. </summary>
        /// <param name="x">The X coordinate of the search point.</param>
        /// <param name="y">The Y coordinate of the search point.</param>
        /// <param name="tolerance">The optional tolerance distance to use when searching for the item near the specified point.</param>
        /// <returns>An <see cref="IActionResult" /> containing the building 2D item if found, or an error response.</returns>
        [HttpGet("itembypoint", Name = $"{nameof(Building2DController)}_{nameof(GetItemByPointAsync)}")]
        [ProducesResponseType(typeof(PostgreSQL.Classes.Building2D), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
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
                return NotFound();
            }

            if (building2D_PostgreSQL.ToDiGi() is not Building2D building2D)
            {
                return NotFound();
            }

            string? json = Core.Convert.ToSystem_String(building2D);
            if (string.IsNullOrWhiteSpace(json))
            {
                return NotFound();
            }

            return Content(json, "application/json");
        }

        /// <summary> Asynchronously retrieves a building 2D item by its reference code and an optional county identifier. </summary>
        /// <param name="reference">The unique reference string used to locate the building 2D item.</param>
        /// <param name="countyId">The optional identifier of the county associated with the building.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        [HttpGet("itembyreference", Name = $"{nameof(Building2DController)}_{nameof(GetItemByReferenceAsync)}")]
        [ProducesResponseType(typeof(PostgreSQL.Classes.Building2D), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetItemByReferenceAsync([FromQuery(Name = "reference")] string reference, [FromQuery(Name = "countyid")] int? countyId)
        {
            Serilog.Modify.Log("{Type}:{Name} started", nameof(Building2DController), nameof(GetItemByReferenceAsync));

            PostgreSQL.Classes.Building2D? building2D = await building2DPostgreSQLConverter.GetBuilding2DByReferenceAsync(reference, countyId);
            if (building2D is null)
            {
                return NotFound();
            }

            string? json = Core.Convert.ToSystem_String(building2D.ToDiGi());
            if (string.IsNullOrWhiteSpace(json))
            {
                return NotFound();
            }

            return Content(json, "application/json");
        }

        /// <summary> Retrieves building 2D items within a specified bounding box. </summary>
        /// <param name="x_1">The X-coordinate of the first corner of the bounding box.</param>
        /// <param name="y_1">The Y-coordinate of the first corner of the bounding box.</param>
        /// <param name="x_2">The X-coordinate of the second corner of the bounding box.</param>
        /// <param name="y_2">The Y-coordinate of the second corner of the bounding box.</param>
        /// <param name="tolerance">An optional tolerance value for the spatial query. If not provided or NaN, a default macro distance is used.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        [HttpGet("itemsbyboundingbox", Name = $"{nameof(Building2DController)}_{nameof(GetItemsByBoundingBoxAsync)}")]
        [ProducesResponseType(typeof(List<PostgreSQL.Classes.Building2D>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
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
                return NotFound();
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
                return NotFound();
            }

            string? json = Core.Convert.ToSystem_String(building2Ds);
            if (string.IsNullOrWhiteSpace(json))
            {
                return NotFound();
            }

            return Content(json, "application/json");
        }

        /// <summary> Retrieves building 2D items by their references. </summary>
        /// <param name="jsonArray">The JSON array containing the building 2D references to retrieve.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        [HttpPost("itemsbybuilding2Dreferences", Name = $"{nameof(Building2DController)}_{nameof(GetItemsByBuilding2DReferencesAsync)}")]
        [ProducesResponseType(typeof(List<PostgreSQL.Classes.Building2D>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
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
                return NotFound();
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
                return NotFound();
            }

            // Returning OK (200) with the serialized string
            string? json = Core.Convert.ToSystem_String(building2Ds);
            if (string.IsNullOrWhiteSpace(json))
            {
                return NotFound();
            }

            return Content(json, "application/json");
        }

        /// <summary>
        /// Retrieves building 2D items for a specified county identifier.
        /// </summary>
        /// <param name="countyId">The unique identifier of the county.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the building 2D items as a JSON response, or a 404 status if no items are found.</returns>
        [HttpGet("itemsbycountyid", Name = $"{nameof(Building2DController)}_{nameof(GetItemsByCountyIdAsync)}")]
        [ProducesResponseType(typeof(List<PostgreSQL.Classes.Building2D>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetItemsByCountyIdAsync([FromQuery(Name = "countyid")] int countyId)
        {
            Serilog.Modify.Log("{Type}:{Name} started", nameof(Building2DController), nameof(GetItemsByCountyIdAsync));

            List<PostgreSQL.Classes.Building2D>? building2Ds = await building2DPostgreSQLConverter.GetBuilding2DsByCountyIdAsync(countyId);
            if (building2Ds is null)
            {
                return NotFound();
            }

            List<Building2D>? building2D_DiGi = building2Ds.ToDiGi();
            if (building2D_DiGi is null)
            {
                return NotFound();
            }

            string? json = Core.Convert.ToSystem_String(building2D_DiGi);
            if (string.IsNullOrWhiteSpace(json))
            {
                return NotFound();
            }

            return Content(json, "application/json");
        }

        /// <summary> Retrieves building 2D items within a specified circle. </summary>
        /// <param name="x">The X-coordinate of the center of the circle.</param>
        /// <param name="y">The Y-coordinate of the center of the circle.</param>
        /// <param name="radius">The radius of the search circle.</param>
        /// <param name="diameter">The diameter of the search circle.</param>
        /// <param name="tolerance">The tolerance value to be applied to the search area.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        [HttpGet("itemsbycircle", Name = $"{nameof(Building2DController)}_{nameof(GetItemsByCircleAsync)}")]
        [ProducesResponseType(typeof(List<PostgreSQL.Classes.Building2D>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
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
                return NotFound();
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
                return NotFound();
            }

            string? json = Core.Convert.ToSystem_String(building2Ds);
            if (string.IsNullOrWhiteSpace(json))
            {
                return NotFound();
            }

            return Content(json, "application/json");
        }

        /// <summary> Retrieves Point2D coordinates by their references. </summary>
        /// <param name="references">A collection of reference strings used to identify the Point2D objects.</param>
        /// <param name="countyId">The optional identifier for the county associated with the coordinates.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>

        [HttpPost("point2dsbyreferences", Name = $"{nameof(Building2DController)}_{nameof(GetPoint2DsByReferencesAsync)}")]
        [ProducesResponseType(typeof(List<Point2D>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetPoint2DsByReferencesAsync([FromBody] IEnumerable<string> references, [FromQuery(Name = "countyid")] int? countyId)
        {
            Serilog.Modify.Log("{Type}:{Name} started", nameof(Building2DController), nameof(GetPoint2DsByReferencesAsync));

            List<Point2D>? point2Ds = await building2DPostgreSQLConverter.GetPoint2DsByReferences(references, countyId);
            if (point2Ds is null)
            {
                return NotFound();
            }

            string? json = Core.Convert.ToSystem_String(point2Ds);
            if (string.IsNullOrWhiteSpace(json))
            {
                return NotFound();
            }

            return Content(json, "application/json");
        }

        /// <summary> Retrieves references of the building2Ds filtered by county Id. </summary>
        /// <param name="countyId">The unique identifier of the county used to filter the building 2D references.</param>
        /// <param name="subdivisionId">The optional unique identifier of the subdivision used to further filter the building 2D references.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>

        [HttpGet("referencesbycountyid", Name = $"{nameof(Building2DController)}_{nameof(GetReferencesByCountyIdAsync)}")]
        [ApiExplorerSettings(IgnoreApi = false)]
        [ProducesResponseType(typeof(List<string>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetReferencesByCountyIdAsync([FromQuery(Name = "countyid")] int countyId, [FromQuery(Name = "subdivisionid")] int? subdivisionId = null)
        {
            Serilog.Modify.Log("{Type}:{Name} started", nameof(Building2DController), nameof(GetReferencesByCountyIdAsync));

            List<PostgreSQL.Classes.Building2DReference>? building2DReferences = await building2DPostgreSQLConverter.GetBuilding2DReferencesByCountyIdAsync(countyId, subdivisionId, null, default, 30);
            if (building2DReferences is null || building2DReferences.Count == 0)
            {
                return NotFound();
            }

            List<string> references = [];
            foreach (PostgreSQL.Classes.Building2DReference building2DReference in building2DReferences)
            {
                if (string.IsNullOrWhiteSpace(building2DReference.Reference))
                {
                    continue;
                }
                references.Add(building2DReference.Reference);
            }

            JsonArray jsonArray = [.. references];

            string? json = jsonArray.ToJsonString();
            if (string.IsNullOrWhiteSpace(json))
            {
                return NotFound();
            }

            return Content(json, "application/json");
        }

        /// <summary> Updates a single building 2D item. </summary>
        /// <param name="jsonObject">The <see cref="T:System.Text.Json.Nodes.JsonObject" /> containing the data to update the building 2D item. This value can be null.</param>
        /// <param name="code">The code identifying the specific building 2D item to be updated. This value can be null.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>

        [HttpPost("updateitem", Name = $"{nameof(Building2DController)}_{nameof(UpdateItemAsync)}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateItemAsync([FromBody] JsonObject? jsonObject, [FromQuery(Name = "code")] string? code)
        {
            if (!GISWebAPIConfigurationFileWatcher.AllowUpdateBuilding2D)
            {
                return Unauthorized();
            }

            if (jsonObject is null)
            {
                return BadRequest();
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

        /// <summary> Updates multiple building 2D items. </summary>
        /// <param name="jsonArray">The JSON array containing the building 2D items to be updated.</param>
        /// <param name="code">An optional code used for the update operation.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>

        [HttpPost("updateitems", Name = $"{nameof(Building2DController)}_{nameof(UpdateItemsAsync)}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateItemsAsync([FromBody] JsonArray? jsonArray, [FromQuery(Name = "code")] string? code)
        {
            Serilog.Modify.Log("{Type}:{Name} started", nameof(Building2DController), nameof(UpdateItemsAsync));
            Serilog.Modify.Log("Code provided: {Code}", code ?? string.Empty);

            if (!GISWebAPIConfigurationFileWatcher.AllowUpdateBuilding2D)
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