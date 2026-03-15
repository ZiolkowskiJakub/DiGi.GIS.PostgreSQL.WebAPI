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
    public class AdministrativeAreal2DController : DiGi.WebAPI.Classes.WebAPIController
    {
        private readonly GISPostgreSQLWebAPIConfigurationFileWatcher gISPostgreSQLWebAPIConfigurationFileWatcher;
        private readonly PostgreSQL.Classes.AdministrativeAreal2DPostgreSQLConverter administrativeAreal2DPostgreSQLConverter;

        public AdministrativeAreal2DController(GISPostgreSQLWebAPIConfigurationFileWatcher gISPostgreSQLWebAPIConfigurationFileWatcher, PostgreSQL.Classes.AdministrativeAreal2DPostgreSQLConverter administrativeAreal2DPostgreSQLConverter)
        {
            this.gISPostgreSQLWebAPIConfigurationFileWatcher = gISPostgreSQLWebAPIConfigurationFileWatcher;
            this.administrativeAreal2DPostgreSQLConverter = administrativeAreal2DPostgreSQLConverter;
        }

        [HttpGet("codes")]
        public async Task<IActionResult> GetCodesAsync()
        {
            HashSet<string>? codes = await administrativeAreal2DPostgreSQLConverter.GetCodesAsync();
            if (codes is null || codes.Count == 0)
            {
                return NoContent();
            }

            JsonArray jsonArray = [.. codes];

            return Content(jsonArray.ToJsonString() ?? string.Empty, "application/json");
        }

        [HttpGet("itembycode")]
        public async Task<IActionResult> GetItemByCodeAsync([FromQuery(Name = "code")] string? code)
        {
            if (string.IsNullOrWhiteSpace(code))
            {
                return BadRequest();
            }

            PostgreSQL.Classes.AdministrativeAreal2D? administrativeAreal2D_PostgreSQL = await administrativeAreal2DPostgreSQLConverter.GetAdministrativeAreal2DByCodeAsync(code);
            if (administrativeAreal2D_PostgreSQL is null)
            {
                return NoContent();
            }

            AdministrativeAreal2D? administrativeAreal2D = administrativeAreal2D_PostgreSQL.ToDiGi<AdministrativeAreal2D>();
            if (administrativeAreal2D is null)
            {
                return NoContent();
            }

            return Content(Core.Convert.ToSystem_String(administrativeAreal2D) ?? string.Empty, "application/json");
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

            List<Enums.AdministrativeArealType>? administrativeArealTypes = null;
            if (!string.IsNullOrWhiteSpace(type) && Core.Query.TryGetEnum(type, out Enums.AdministrativeArealType administrativeArealType) && administrativeArealType != PostgreSQL.Enums.AdministrativeArealType.Undefined)
            {
                administrativeArealTypes = [administrativeArealType];
            }

            List<PostgreSQL.Classes.AdministrativeAreal2D>? administrativeAreal2Ds_PostgreSQL = await administrativeAreal2DPostgreSQLConverter.GetAdministrativeAreal2DsByBoundingBox2DAsync(new BoundingBox2D(new Core.Classes.Range<double>(x_1, x_2), new Core.Classes.Range<double>(y_1, y_2)), administrativeArealTypes, tolerance.Value);
            if (administrativeAreal2Ds_PostgreSQL is null || administrativeAreal2Ds_PostgreSQL.Count == 0)
            {
                return NoContent();
            }

            List<AdministrativeAreal2D> administrativeAreal2Ds = [];
            foreach (PostgreSQL.Classes.AdministrativeAreal2D administrativeAreal2D_PostgreSQL in administrativeAreal2Ds_PostgreSQL)
            {
                AdministrativeAreal2D? administrativeAreal2D = administrativeAreal2D_PostgreSQL.ToDiGi<AdministrativeAreal2D>();
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

            return Content(Core.Convert.ToSystem_String(administrativeAreal2Ds) ?? string.Empty, "application/json");
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

            List<Enums.AdministrativeArealType>? administrativeArealTypes = null;
            if (!string.IsNullOrWhiteSpace(type) && Core.Query.TryGetEnum(type, out Enums.AdministrativeArealType administrativeArealType) && administrativeArealType != PostgreSQL.Enums.AdministrativeArealType.Undefined)
            {
                administrativeArealTypes = [administrativeArealType];
            }

            List<PostgreSQL.Classes.AdministrativeAreal2D>? administrativeAreal2Ds_PostgreSQL = await administrativeAreal2DPostgreSQLConverter.GetAdministrativeAreal2DsByCircle2DAsync(new Circle2D(new Point2D(x, y), radius_Temp), administrativeArealTypes, tolerance.Value);
            if (administrativeAreal2Ds_PostgreSQL is null || administrativeAreal2Ds_PostgreSQL.Count == 0)
            {
                return NoContent();
            }

            List<AdministrativeAreal2D> administrativeAreal2Ds = [];
            foreach (PostgreSQL.Classes.AdministrativeAreal2D administrativeAreal2D_PostgreSQL in administrativeAreal2Ds_PostgreSQL)
            {
                AdministrativeAreal2D? administrativeAreal2D = administrativeAreal2D_PostgreSQL.ToDiGi<AdministrativeAreal2D>();
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

            return Content(Core.Convert.ToSystem_String(administrativeAreal2Ds) ?? string.Empty, "application/json");
        }

        [HttpPost("itemsbycodes")]
        public async Task<IActionResult> GetItemsByCodesAsync([FromBody] List<string>? codes)
        {
            if (codes == null || codes.Count == 0)
            {
                return BadRequest();
            }

            List<PostgreSQL.Classes.AdministrativeAreal2D>? administrativeAreal2Ds_PostgreSQL = await administrativeAreal2DPostgreSQLConverter.GetAdministrativeAreal2DsByCodesAsync(codes);
            if (administrativeAreal2Ds_PostgreSQL is null || administrativeAreal2Ds_PostgreSQL.Count == 0)
            {
                return NoContent();
            }

            List<AdministrativeAreal2D> administrativeAreal2Ds = [];
            foreach (PostgreSQL.Classes.AdministrativeAreal2D administrativeAreal2D_PostgreSQL in administrativeAreal2Ds_PostgreSQL)
            {
                AdministrativeAreal2D? administrativeAreal2D = administrativeAreal2D_PostgreSQL.ToDiGi<AdministrativeAreal2D>();
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

            return Content(Core.Convert.ToSystem_String(administrativeAreal2Ds) ?? string.Empty, "application/json");
        }

        [HttpPost("itemsbypoint")]
        public async Task<IActionResult> GetItemsByPointAsync([FromQuery(Name = "x")] double x, [FromQuery(Name = "y")] double y, [FromQuery(Name = "tolerance")] double? tolerance, [FromQuery(Name = "type")] string? type)
        {
            if (double.IsNaN(x) || double.IsNaN(y))
            {
                return BadRequest();
            }

            if (tolerance is null || double.IsNaN(tolerance.Value))
            {
                tolerance = Core.Constants.Tolerance.MacroDistance;
            }

            List<Enums.AdministrativeArealType>? administrativeArealTypes = null;
            if (!string.IsNullOrWhiteSpace(type) && Core.Query.TryGetEnum(type, out Enums.AdministrativeArealType administrativeArealType) && administrativeArealType != PostgreSQL.Enums.AdministrativeArealType.Undefined)
            {
                administrativeArealTypes = [administrativeArealType];
            }

            List<PostgreSQL.Classes.AdministrativeAreal2D>? administrativeAreal2Ds_PostgreSQL = await administrativeAreal2DPostgreSQLConverter.GetAdministrativeAreal2DsByPoint2DAsync(new Point2D(x, y), administrativeArealTypes, tolerance.Value);
            if (administrativeAreal2Ds_PostgreSQL is null || administrativeAreal2Ds_PostgreSQL.Count == 0)
            {
                return NoContent();
            }

            List<AdministrativeAreal2D> administrativeAreal2Ds = [];
            foreach (PostgreSQL.Classes.AdministrativeAreal2D administrativeAreal2D_PostgreSQL in administrativeAreal2Ds_PostgreSQL)
            {
                AdministrativeAreal2D? administrativeAreal2D = administrativeAreal2D_PostgreSQL.ToDiGi<AdministrativeAreal2D>();
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

            return Content(Core.Convert.ToSystem_String(administrativeAreal2Ds) ?? string.Empty, "application/json");
        }

        [HttpGet("subcodes")]
        public async Task<IActionResult> GetSubCodesAsync([FromQuery(Name = "code")] string? code)
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

            return Content(jsonArray.ToJsonString() ?? string.Empty, "application/json");
        }

        [HttpPost("updateitem")]
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

            AdministrativeAreal2D? administrativeAreal2D = Core.Create.SerializableObject<AdministrativeAreal2D>(jsonObject);
            if (administrativeAreal2D is null)
            {
                return BadRequest();
            }

            PostgreSQL.Classes.AdministrativeAreal2D? administrativeAreal2D_PostgreSQL = administrativeAreal2D.ToPostgreSQL();
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

        [HttpPost("updateitems")]
        public async Task<IActionResult> UpdateItemsAsync([FromBody] JsonArray? jsonArray)
        {
            if (!gISPostgreSQLWebAPIConfigurationFileWatcher.AllowUpdateAdministrativeAreal2D)
            {
                return BadRequest();
            }

            if (jsonArray is null || jsonArray.Count == 0)
            {
                return NoContent();
            }

            List<AdministrativeAreal2D>? administrativeAreal2Ds = Core.Create.SerializableObjects<AdministrativeAreal2D>(jsonArray);
            if (administrativeAreal2Ds is null)
            {
                return BadRequest();
            }

            List<PostgreSQL.Classes.AdministrativeAreal2D> administrativeAreal2Ds_PostgreSQL = [];
            foreach (AdministrativeAreal2D administrativeAreal2D in administrativeAreal2Ds)
            {
                PostgreSQL.Classes.AdministrativeAreal2D? administrativeAreal2D_PostgreSQL = administrativeAreal2D.ToPostgreSQL();
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