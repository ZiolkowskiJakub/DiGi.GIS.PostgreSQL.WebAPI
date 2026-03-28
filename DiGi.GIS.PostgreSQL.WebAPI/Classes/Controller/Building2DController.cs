using DiGi.Geometry.Planar.Classes;
using DiGi.GIS.Classes;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace DiGi.GIS.PostgreSQL.WebAPI.Classes
{
    [ApiController]
    [Route("gis/[controller]")]
    public class Building2DController : DiGi.WebAPI.Classes.WebAPIController
    {
        private readonly PostgreSQL.Classes.Building2DPostgreSQLConverter building2DPostgreSQLConverter;
        private readonly GISPostgreSQLWebAPIConfigurationFileWatcher gISPostgreSQLWebAPIConfigurationFileWatcher;

        public Building2DController(GISPostgreSQLWebAPIConfigurationFileWatcher gISPostgreSQLWebAPIConfigurationFileWatcher, PostgreSQL.Classes.Building2DPostgreSQLConverter building2DPostgreSQLConverter)
        {
            this.gISPostgreSQLWebAPIConfigurationFileWatcher = gISPostgreSQLWebAPIConfigurationFileWatcher;
            this.building2DPostgreSQLConverter = building2DPostgreSQLConverter;
        }

        [HttpPost("itembypoint")]
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

            PostgreSQL.Classes.Building2D? building2D_PostgreSQL = await building2DPostgreSQLConverter.GetBuilding2DbyPoint2DAsync(new Point2D(x, y), tolerance.Value);
            if (building2D_PostgreSQL is null)
            {
                return NoContent();
            }

            if (building2D_PostgreSQL.ToDiGi<Building2D>() is not Building2D building2D)
            {
                return NoContent();
            }

            return Content(Core.Convert.ToSystem_String(building2D) ?? string.Empty, "application/json");
        }

        [HttpPost("itemsbyboundingbox")]
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
                Building2D? building2D = building2D_PostgreSQL.ToDiGi<Building2D>();
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

            return Content(Core.Convert.ToSystem_String(building2Ds) ?? string.Empty, "application/json");
        }

        [HttpPost("itemsbycircle")]
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
                Building2D? building2D = building2D_PostgreSQL.ToDiGi<Building2D>();
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

            return Content(Core.Convert.ToSystem_String(building2Ds) ?? string.Empty, "application/json");
        }

        [HttpPost("updateitem")]
        public async Task<IActionResult> UpdateItemAsync([FromBody] JsonObject? jsonObject, [FromQuery(Name = "code")] string? code)
        {
            if (!gISPostgreSQLWebAPIConfigurationFileWatcher.AllowUpdateBuilding2D)
            {
                return BadRequest();
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

        [HttpPost("updateitems")]
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