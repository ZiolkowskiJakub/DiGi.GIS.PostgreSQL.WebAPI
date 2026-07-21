using DiGi.Geometry.Spatial.Classes;
using DiGi.GIS.PostgreSQL;
using DiGi.GIS.PostgreSQL.Classes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text.Json.Nodes;
using System.Threading;
using System.Threading.Tasks;

namespace DiGi.GIS.WebAPI.Classes
{
    /// <summary>
    /// Provides API endpoints for managing and updating Building data stored in a PostgreSQL database.
    /// </summary>
    [ApiController]
    [Route("gis/[controller]")]
    public class BuildingController : DiGi.WebAPI.Classes.WebAPIController
    {
        private readonly AdministrativeAreal2DPostgreSQLConverter administrativeAreal2DPostgreSQLConverter;
        private readonly BuildingPostgreSQLConverter buildingPostgreSQLConverter;
        private readonly GISWebAPIConfigurationFileWatcher GISWebAPIConfigurationFileWatcher;

        /// <summary>
        /// Initializes a new instance of the BuildingController class.
        /// </summary>
        /// <param name="GISWebAPIConfigurationFileWatcher">The configuration file watcher used to monitor changes to the PostgreSQL Web API configuration.</param>
        /// <param name="buildingPostgreSQLConverter">The converter for Building objects when interacting with a PostgreSQL database.</param>
        /// <param name="administrativeAreal2DPostgreSQLConverter">The converter for administrative areal 2D data when interacting with a PostgreSQL database.</param>
        public BuildingController(GISWebAPIConfigurationFileWatcher GISWebAPIConfigurationFileWatcher, BuildingPostgreSQLConverter buildingPostgreSQLConverter, AdministrativeAreal2DPostgreSQLConverter administrativeAreal2DPostgreSQLConverter)
        {
            this.GISWebAPIConfigurationFileWatcher = GISWebAPIConfigurationFileWatcher;
            this.buildingPostgreSQLConverter = buildingPostgreSQLConverter;
            this.administrativeAreal2DPostgreSQLConverter = administrativeAreal2DPostgreSQLConverter;
        }

        /// <summary>
        /// Updates multiple building items based on the provided JSON array and identification code.
        /// </summary>
        /// <param name="jsonArray">The JSON array containing the building items to be updated.</param>
        /// <param name="code">The identification code required for the update operation.</param>
        /// <returns>An <see cref="IActionResult"/> representing the result of the update operation.</returns>
        [HttpPost("updateitems", Name = $"{nameof(BuildingController)}_{nameof(UpdateItemsAsync)}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateItemsAsync([FromBody] JsonArray? jsonArray, [FromQuery(Name = "code")] string? code)
        {
            Serilog.Modify.Log("{Type}:{Name} started", nameof(BuildingController), nameof(UpdateItemsAsync));
            Serilog.Modify.Log("Code provided: {Code}", code ?? string.Empty);

            if (string.IsNullOrWhiteSpace(code))
            {
                Serilog.Modify.Log(Serilog.Enums.LogEventLevel.Error, "Code cannot be null or empty");
                return BadRequest();
            }

            if (!GISWebAPIConfigurationFileWatcher.AllowUpdateBuilding)
            {
                Serilog.Modify.Log(Serilog.Enums.LogEventLevel.Warning, "Building update not allowed");
                return BadRequest();
            }

            if (administrativeAreal2DPostgreSQLConverter is null)
            {
                Serilog.Modify.Log(Serilog.Enums.LogEventLevel.Error, "AdministrativeAreal2DPostgreSQLConverter is null");
                return BadRequest();
            }

            if (jsonArray is null || jsonArray.Count == 0)
            {
                Serilog.Modify.Log("No Building data to update");
                return NoContent();
            }

            try
            {
                int? countyId = await administrativeAreal2DPostgreSQLConverter.GetIdByCodeAsync(code, PostgreSQL.Enums.AdministrativeArealType.County);
                if (countyId is null)
                {
                    Serilog.Modify.Log(Serilog.Enums.LogEventLevel.Warning, "County code '{Code}' was not found in database", code);
                    return BadRequest();
                }

                List<CityGML.Classes.Building>? cityGMLBuildings = Core.Create.SerializableObjects<CityGML.Classes.Building>(jsonArray);
                if (cityGMLBuildings is null)
                {
                    Serilog.Modify.Log(Serilog.Enums.LogEventLevel.Error, "Buildings could not be converted from json");
                    return BadRequest();
                }

                Serilog.Modify.Log("Buildings conversion to PostgreSQL started. Buildings count: {Count}", cityGMLBuildings.Count);

                List<Building> buildings = [];
                foreach (CityGML.Classes.Building cityGMLBuilding in cityGMLBuildings)
                {
                    Building? building = cityGMLBuilding.ToPostgreSQL(countyId);
                    if (building is not null)
                    {
                        buildings.Add(building);
                    }
                }

                if (buildings.Count == 0)
                {
                    Serilog.Modify.Log("No Buildings PostgreSQL to update");
                    return NoContent();
                }

                Serilog.Modify.Log("Updating to database starting");

                HashSet<long>? ids = await buildingPostgreSQLConverter.UpdateAsync(buildings);
                if (ids is null || ids.Count == 0)
                {
                    Serilog.Modify.Log(Serilog.Enums.LogEventLevel.Warning, "Updating to database ended but no Buildings have been updated");
                    return StatusCode(500, "Database update returned no modified building IDs.");
                }

                Serilog.Modify.Log("Updating to database ended. Updated Buildings: {After}/{Before}", ids.Count, buildings.Count);
                return Ok();
            }
            catch (Exception exception)
            {
                Serilog.Modify.Log(exception, "Unhandled error during BuildingController.UpdateItemsAsync");
                return StatusCode(500, exception.Message);
            }
        }

        /// <summary>
        /// Asynchronously retrieves buildings based on a provided reference and an optional county identifier.
        /// </summary>
        /// <param name="reference">The unique reference string used to identify the buildings.</param>
        /// <param name="countyId">An optional integer representing the county ID to filter the results.</param>
        /// <param name="cancellationToken">The <see cref="T:System.Threading.CancellationToken" /> to observe for cancellation requests.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        [HttpGet("itemsbyreference", Name = $"{nameof(BuildingController)}_{nameof(GetItemsByReferenceAsync)}")]
        [ProducesResponseType(typeof(List<CityGML.Classes.Building>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GetItemsByReferenceAsync([FromQuery(Name = "reference")] string reference, [FromQuery(Name = "countyid")] int? countyId, CancellationToken cancellationToken = default)
        {
            Serilog.Modify.Log("{Type}:{Name} started", nameof(BuildingController), nameof(GetItemsByReferenceAsync));

            Serilog.Modify.Log("Reference provided: {Reference}", reference ?? string.Empty);
            Serilog.Modify.Log("CountyId provided: {CountyId}", countyId?.ToString() ?? string.Empty);

            if (string.IsNullOrWhiteSpace(reference))
            {
                Serilog.Modify.Log(Serilog.Enums.LogEventLevel.Error, "Reference cannot be null or empty");
                return BadRequest();
            }

            if (buildingPostgreSQLConverter is null)
            {
                Serilog.Modify.Log(Serilog.Enums.LogEventLevel.Error, "BuildingPostgreSQLConverter is null");
                return BadRequest();
            }

            List<Building>? buildings_PostgreSQL = await buildingPostgreSQLConverter.GetBuildingsByReferenceAsync(reference, countyId, cancellationToken);

            if (buildings_PostgreSQL is null || buildings_PostgreSQL.Count == 0)
            {
                Serilog.Modify.Log("No Buildings found for provided reference");
                return NoContent();
            }

            List<CityGML.Classes.Building> buildings = [];
            foreach (Building building_PostgreSQL in buildings_PostgreSQL)
            {
                CityGML.Classes.Building? building = building_PostgreSQL.ToDiGi();
                if (building is null)
                {
                    continue;
                }

                buildings.Add(building);
            }

            if (buildings.Count == 0)
            {
                return NoContent();
            }

            return Content(Core.Convert.ToSystem_String(buildings) ?? string.Empty, "application/json");
        }

        /// <summary>
        /// Asynchronously retrieves the single most relevant building for the provided reference and an optional county identifier.
        /// <para>When the X, Y or Z coordinates are provided they are used to break ties between candidates resolved from the reference.</para>
        /// <para>When the reference cannot be resolved and a point is provided, a spatial fallback search limited in X and Y by the maximum distance is performed.</para>
        /// </summary>
        /// <param name="reference">The unique reference string used to identify the building.</param>
        /// <param name="countyId">An optional integer representing the county ID to filter the results.</param>
        /// <param name="x">The optional X coordinate of the point used to break ties and to locate the building when the reference cannot be resolved.</param>
        /// <param name="y">The optional Y coordinate of the point used to break ties and to locate the building when the reference cannot be resolved.</param>
        /// <param name="z">The optional Z coordinate of the point used to break ties and to locate the building when the reference cannot be resolved.</param>
        /// <param name="maxDistance">The optional distance used to inflate the point in X and Y into the bounding box of the spatial fallback search. Defaults to 1.0 when not provided or invalid.</param>
        /// <param name="cancellationToken">The <see cref="T:System.Threading.CancellationToken" /> to observe for cancellation requests.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        [HttpGet("itembyreference", Name = $"{nameof(BuildingController)}_{nameof(GetItemByReferenceAsync)}")]
        [ProducesResponseType(typeof(CityGML.Classes.Building), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GetItemByReferenceAsync([FromQuery(Name = "reference")] string reference, [FromQuery(Name = "countyid")] int? countyId, [FromQuery(Name = "x")] double? x = null, [FromQuery(Name = "y")] double? y = null, [FromQuery(Name = "z")] double? z = null, [FromQuery(Name = "maxdistance")] double? maxDistance = null, CancellationToken cancellationToken = default)
        {
            Serilog.Modify.Log("{Type}:{Name} started", nameof(BuildingController), nameof(GetItemByReferenceAsync));

            Serilog.Modify.Log("Reference provided: {Reference}", reference ?? string.Empty);
            Serilog.Modify.Log("CountyId provided: {CountyId}", countyId?.ToString() ?? string.Empty);
            Serilog.Modify.Log("Point provided: X {X}, Y {Y}, Z {Z}", x?.ToString() ?? string.Empty, y?.ToString() ?? string.Empty, z?.ToString() ?? string.Empty);
            Serilog.Modify.Log("MaxDistance provided: {MaxDistance}", maxDistance?.ToString() ?? string.Empty);

            if (string.IsNullOrWhiteSpace(reference))
            {
                Serilog.Modify.Log(Serilog.Enums.LogEventLevel.Error, "Reference cannot be null or empty");
                return BadRequest();
            }

            if (buildingPostgreSQLConverter is null)
            {
                Serilog.Modify.Log(Serilog.Enums.LogEventLevel.Error, "BuildingPostgreSQLConverter is null");
                return BadRequest();
            }

            if ((x is not null && double.IsNaN(x.Value)) || (y is not null && double.IsNaN(y.Value)) || (z is not null && double.IsNaN(z.Value)))
            {
                Serilog.Modify.Log(Serilog.Enums.LogEventLevel.Error, "Point coordinates cannot be NaN");
                return BadRequest();
            }

            double maxDistance_Temp = maxDistance ?? 1.0;
            if (double.IsNaN(maxDistance_Temp) || maxDistance_Temp <= 0)
            {
                Serilog.Modify.Log(Serilog.Enums.LogEventLevel.Warning, "MaxDistance is invalid. Default value will be used");
                maxDistance_Temp = 1.0;
            }

            Point3D? point3D = null;
            if (x is not null || y is not null || z is not null)
            {
                point3D = new(x ?? 0, y ?? 0, z ?? 0);
            }

            Building? building_PostgreSQL = await buildingPostgreSQLConverter.GetBuildingByReferenceAsync(reference, countyId, point3D, maxDistance_Temp, cancellationToken: cancellationToken);
            if (building_PostgreSQL is null)
            {
                Serilog.Modify.Log("No Building found for provided reference");
                return NoContent();
            }

            CityGML.Classes.Building? building = building_PostgreSQL.ToDiGi();
            if (building is null)
            {
                Serilog.Modify.Log(Serilog.Enums.LogEventLevel.Error, "Building could not be converted from PostgreSQL");
                return NoContent();
            }

            return Content(Core.Convert.ToSystem_String(building) ?? string.Empty, "application/json");
        }

    }
}
