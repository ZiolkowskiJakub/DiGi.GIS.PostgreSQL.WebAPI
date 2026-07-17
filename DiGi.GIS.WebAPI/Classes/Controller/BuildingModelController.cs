using DiGi.Analytical.Building.Classes;
using DiGi.Geometry.Planar.Classes;
using DiGi.PostgreSQL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Nodes;
using System.Threading;
using System.Threading.Tasks;

namespace DiGi.GIS.WebAPI.Classes
{
    /// <summary>
    /// Web API controller for building model operations, providing endpoints to retrieve building model data.
    /// </summary>
    [ApiController]
    [Route("gis/[controller]")]
    public class BuildingModelController : DiGi.WebAPI.Classes.WebAPIController
    {
        private readonly PostgreSQL.Classes.Building2DPostgreSQLConverter building2DPostgreSQLConverter;
        private readonly PostgreSQL.Classes.BuildingModelPostgreSQLConverter buildingModelPostgreSQLConverter;
        private readonly GISWebAPIConfigurationFileWatcher GISWebAPIConfigurationFileWatcher;

        /// <summary>Initializes a new instance of the <see cref="BuildingModelController"/> class.</summary>
        /// <param name="GISWebAPIConfigurationFileWatcher">The configuration file watcher for the GIS PostgreSQL Web API.</param>
        /// <param name="buildingModelPostgreSQLConverter">The converter used for building model data operations in PostgreSQL.</param>
        /// <param name="building2DPostgreSQLConverter">The converter used for Building 2D data operations in PostgreSQL.</param>
        public BuildingModelController(GISWebAPIConfigurationFileWatcher GISWebAPIConfigurationFileWatcher, PostgreSQL.Classes.BuildingModelPostgreSQLConverter buildingModelPostgreSQLConverter, PostgreSQL.Classes.Building2DPostgreSQLConverter building2DPostgreSQLConverter)
        {
            this.GISWebAPIConfigurationFileWatcher = GISWebAPIConfigurationFileWatcher;
            this.building2DPostgreSQLConverter = building2DPostgreSQLConverter;
            this.buildingModelPostgreSQLConverter = buildingModelPostgreSQLConverter;
        }

        /// <summary> Retrieves building models within a specified circle. </summary>
        /// <param name="x">The X-coordinate of the center point of the search circle.</param>
        /// <param name="y">The Y-coordinate of the center point of the search circle.</param>
        /// <param name="radius">The radius of the search circle. This value can be null.</param>
        /// <param name="diameter">The diameter of the search circle. This value can be null.</param>
        /// <param name="storeyHeight">An optional storey height used for generating building models. If not provided, a default value of 3.0 is used.</param>
        /// <param name="tolerance">An optional tolerance value for the spatial query. If not provided, the default distance tolerance is used.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        [HttpGet("itemsbycircle", Name = $"{nameof(BuildingModelController)}_{nameof(GetItemsByCircleAsync)}")]
        [ProducesResponseType(typeof(List<BuildingModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetItemsByCircleAsync([FromQuery(Name = "x")] double x, [FromQuery(Name = "y")] double y, [FromQuery(Name = "radius")] double? radius, [FromQuery(Name = "diameter")] double? diameter, [FromQuery(Name = "storeyheight")] double? storeyHeight = 3.0, [FromQuery(Name = "tolerance")] double? tolerance = Core.Constants.Tolerance.Distance)
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

            List<BuildingModel> buildingModels = [];
            foreach (PostgreSQL.Classes.Building2D building2D_PostgreSQL in building2Ds_PostgreSQL)
            {
                BuildingModel? building2D = Analytical.Create.BuildingModel(building2D_PostgreSQL?.ToDiGi());
                if (building2D is null)
                {
                    continue;
                }

                buildingModels.Add(building2D);
            }

            if (buildingModels is null || buildingModels.Count == 0)
            {
                return NotFound();
            }

            string? json = Core.Convert.ToSystem_String(buildingModels);
            if (string.IsNullOrWhiteSpace(json))
            {
                return NotFound();
            }

            return Content(json, "application/json");
        }

        /// <summary> Retrieves building models stored in the database for the specified references. </summary>
        /// <param name="references">The building references identifying the building models to retrieve. This value can be null.</param>
        /// <param name="countyId">The optional county identifier used to narrow the search. This value can be null.</param>
        /// <param name="limit">The optional maximum number of building models to retrieve. This value can be null.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by the caller to cancel the asynchronous operation.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        [HttpGet("itemsbyreferences", Name = $"{nameof(BuildingModelController)}_{nameof(GetItemsByReferencesAsync)}")]
        [ProducesResponseType(typeof(List<BuildingModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetItemsByReferencesAsync([FromQuery(Name = "references")] IEnumerable<string>? references, [FromQuery(Name = "countyid")] int? countyId, [FromQuery(Name = "limit")] long? limit = null, CancellationToken cancellationToken = default)
        {
            if (references is null)
            {
                return BadRequest();
            }

            if (!references.Any())
            {
                return NoContent();
            }

            List<PostgreSQL.Classes.BuildingModel>? buildingModels_PostgreSQL = await buildingModelPostgreSQLConverter.GetItemsByReferencesAsync(references, countyId, limit, cancellationToken);
            if (buildingModels_PostgreSQL is null || buildingModels_PostgreSQL.Count == 0)
            {
                return NotFound();
            }

            List<BuildingModel> buildingModels = [];
            foreach (PostgreSQL.Classes.BuildingModel buildingModel_PostgreSQL in buildingModels_PostgreSQL)
            {
                BuildingModel? buildingModel = buildingModel_PostgreSQL?.ToDiGi();
                if (buildingModel is null)
                {
                    continue;
                }

                buildingModels.Add(buildingModel);
            }

            if (buildingModels is null || buildingModels.Count == 0)
            {
                return NotFound();
            }

            string? json = Core.Convert.ToSystem_String(buildingModels);
            if (string.IsNullOrWhiteSpace(json))
            {
                return NotFound();
            }

            return Content(json, "application/json");
        }

        /// <summary> Updates multiple building model items in the database. </summary>
        /// <param name="jsonArray">The JSON array containing the building models to be updated. This value can be null.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        [HttpPost("updateitems", Name = $"{nameof(BuildingModelController)}_{nameof(UpdateItemsAsync)}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateItemsAsync([FromBody] JsonArray? jsonArray)
        {
            Serilog.Modify.Log("{Type}:{Name} started", nameof(BuildingModelController), nameof(UpdateItemsAsync));

            if (!GISWebAPIConfigurationFileWatcher.AllowUpdateBuildingModel)
            {
                Serilog.Modify.Log(Serilog.Enums.LogEventLevel.Warning, "BuildingModel update not allowed");
                return Unauthorized();
            }

            if (jsonArray is null || jsonArray.Count == 0)
            {
                Serilog.Modify.Log("No BuildingModels to update");
                return NoContent();
            }

            List<BuildingModel>? buildingModels = Core.Create.SerializableObjects<BuildingModel>(jsonArray);
            if (buildingModels is null)
            {
                Serilog.Modify.Log(Serilog.Enums.LogEventLevel.Error, "BuildingModels could not be converted from json");
                return BadRequest();
            }

            Serilog.Modify.Log("BuildingModels conversion to PostgreSQL started. BuildingModels count: {Count}", buildingModels.Count);

            List<PostgreSQL.Classes.BuildingModel> buildingModels_PostgreSQL = [];
            foreach (BuildingModel buildingModel in buildingModels)
            {
                PostgreSQL.Classes.BuildingModel? buildingModel_PostgreSQL = PostgreSQL.Convert.ToPostgreSQL(buildingModel);
                if (buildingModel_PostgreSQL is null)
                {
                    continue;
                }

                buildingModels_PostgreSQL.Add(buildingModel_PostgreSQL);
            }

            if (buildingModels_PostgreSQL is null || buildingModels_PostgreSQL.Count == 0)
            {
                Serilog.Modify.Log("No BuildingModels PostgreSQL to update");
                return NoContent();
            }

            Serilog.Modify.Log("BuildingModels conversion to PostgreSQL ended. BuildingModels converted: {After}/{Before}", buildingModels_PostgreSQL.Count, buildingModels.Count);

            Serilog.Modify.Log("Updating to database starting");

            HashSet<long>? ids = null;
            try
            {
                ids = await buildingModelPostgreSQLConverter.UpdateAsync(buildingModels_PostgreSQL);
            }
            catch (Exception exception)
            {
                Serilog.Modify.Log(exception, "Database could not be updated");
            }

            if (ids is null || ids.Count == 0)
            {
                Serilog.Modify.Log(Serilog.Enums.LogEventLevel.Warning, "Updating to database ended but no BuildingModels have been updated");
            }
            else
            {
                Serilog.Modify.Log("Updating to database ended. Updated BuildingModels: {After}/{Before}", ids?.Count ?? 0, buildingModels_PostgreSQL.Count);
            }

            return Ok();
        }
    }
}