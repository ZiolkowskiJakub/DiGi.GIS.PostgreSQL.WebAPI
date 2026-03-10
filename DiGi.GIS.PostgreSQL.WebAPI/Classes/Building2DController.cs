using DiGi.Geometry.Planar.Classes;
using DiGi.GIS.Classes;
using Microsoft.AspNetCore.Mvc;
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

        public Building2DController(PostgreSQL.Classes.Building2DPostgreSQLConverter building2DPostgreSQLConverter)
        {
            this.building2DPostgreSQLConverter = building2DPostgreSQLConverter;
        }

        [HttpPost("itembypoint")]
        public async Task<IActionResult> GetItemByPointAsync([FromQuery(Name = "x")] double x, [FromQuery(Name = "y")] double y, [FromQuery(Name = "tolerance")] double? tolerance, [FromQuery(Name = "type")] string? type)
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
        public async Task<IActionResult> GetItemsByBoundingBoxAsync([FromQuery(Name = "x_1")] double x_1, [FromQuery(Name = "y_1")] double y_1, [FromQuery(Name = "x_2")] double x_2, [FromQuery(Name = "y_2")] double y_2, [FromQuery(Name = "tolerance")] double? tolerance, [FromQuery(Name = "type")] string? type)
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
        public async Task<IActionResult> GetItemsByCircleAsync([FromQuery(Name = "x")] double x, [FromQuery(Name = "y")] double y, [FromQuery(Name = "radius")] double? radius, [FromQuery(Name = "diameter")] double? diameter, [FromQuery(Name = "tolerance")] double? tolerance, [FromQuery(Name = "type")] string? type)
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

        [HttpPost("update")]
        public async Task<IActionResult> UpdateAsync([FromBody] JsonObject? jsonObject)
        {
            if (jsonObject is null)
            {
                return NoContent();
            }

            Building2D? building2D = Core.Create.SerializableObject<Building2D>(jsonObject);
            if (building2D is null)
            {
                return BadRequest();
            }

            PostgreSQL.Classes.Building2D? building2D_PostgreSQL = building2D.ToPostgreSQL();
            if (building2D_PostgreSQL is null)
            {
                return BadRequest();
            }

            await building2DPostgreSQLConverter.UpdateAsync([building2D_PostgreSQL]);

            return Ok();
        }
    }
}