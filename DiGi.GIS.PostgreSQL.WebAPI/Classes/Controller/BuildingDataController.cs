using DiGi.Core.IO.Table.Classes;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DiGi.GIS.PostgreSQL.WebAPI.Classes
{
    [ApiController]
    [Route("gis/[controller]")]
    public class BuildingDataController : DiGi.WebAPI.Classes.WebAPIController
    {
        private readonly PostgreSQL.Classes.BuildingDataPostgreSQLConverter buildingDataPostgreSQLConverter;
        private readonly GISPostgreSQLWebAPIConfigurationFileWatcher gISPostgreSQLWebAPIConfigurationFileWatcher;

        public BuildingDataController(GISPostgreSQLWebAPIConfigurationFileWatcher gISPostgreSQLWebAPIConfigurationFileWatcher, PostgreSQL.Classes.BuildingDataPostgreSQLConverter buildingDataPostgreSQLConverter)
        {
            this.gISPostgreSQLWebAPIConfigurationFileWatcher = gISPostgreSQLWebAPIConfigurationFileWatcher;
            this.buildingDataPostgreSQLConverter = buildingDataPostgreSQLConverter;
        }

        [HttpGet("itembyreference")]
        public async Task<IActionResult> GetTableByReferenceAsync([FromQuery(Name = "reference")] string reference, [FromQuery(Name = "countyid")] int? countyId)
        {
            Serilog.Modify.Log("{Type}:{Name} started", nameof(BuildingDataController), nameof(GetTableByReferenceAsync));

            Table table = await buildingDataPostgreSQLConverter.PullAsync([reference], countyId);
            if (table is null)
            {
                return NoContent();
            }

            return Content(Core.Convert.ToSystem_String(building2DReference) ?? string.Empty, "application/json");
        }
    }
}