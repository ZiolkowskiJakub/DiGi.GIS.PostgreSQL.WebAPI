using DiGi.Core.IO.Table.Classes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiGi.GIS.PostgreSQL.WebAPI.Classes
{
    [ApiController]
    [Route("gis/[controller]")]
    public class BuildingDataController : DiGi.WebAPI.Classes.WebAPIController
    {
        private readonly PostgreSQL.Classes.BuildingDataPostgreSQLConverter buildingDataPostgreSQLConverter;

        public BuildingDataController(PostgreSQL.Classes.BuildingDataPostgreSQLConverter buildingDataPostgreSQLConverter)
        {
            this.buildingDataPostgreSQLConverter = buildingDataPostgreSQLConverter;
        }

        /// <summary>
        /// Retrieves a building data table by column unique identifiers.
        /// </summary>
        [HttpPost("tablebycolumnuniqueids", Name = $"{nameof(BuildingDataController)}_{nameof(GetTableByColumnUniqueIdsAsync)}")]
        [ApiExplorerSettings(IgnoreApi = false)]
        [ProducesResponseType(typeof(DiGi.PostgreSQL.Table.Classes.Table), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GetTableByColumnUniqueIdsAsync([FromBody] BuildingDataQuery buildingDataQuery)
        {
            Serilog.Modify.Log("{Type}:{Name} started", nameof(BuildingDataController), nameof(GetTableByColumnUniqueIdsAsync));

            IEnumerable<string>? columnUniqueIds = buildingDataQuery.ColumnUniqueIds;
            if (columnUniqueIds is not null && !columnUniqueIds.Any())
            {
                columnUniqueIds = null;
            }

            Table? table = await buildingDataPostgreSQLConverter.PullAsync(buildingDataQuery.References, buildingDataQuery.CountyId, columnUniqueIds);
            if (table is null)
            {
                return NoContent();
            }

            string? json = Core.IO.Table.Convert.ToSystem_String<Table, Column, Row>(table);
            if (string.IsNullOrWhiteSpace(json))
            {
                return NoContent();
            }

            return Content(json, "application/json");
        }
    }
}