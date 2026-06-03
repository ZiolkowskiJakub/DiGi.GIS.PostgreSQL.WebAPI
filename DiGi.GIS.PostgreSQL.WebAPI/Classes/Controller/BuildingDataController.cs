using DiGi.Core.IO.Table.Classes;
using DiGi.GIS.PostgreSQL.Classes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace DiGi.GIS.PostgreSQL.WebAPI.Classes
{
    [ApiController]
    [Route("gis/[controller]")]
    public class BuildingDataController : DiGi.WebAPI.Classes.WebAPIController
    {
        private readonly BuildingDataPostgreSQLConverter buildingDataPostgreSQLConverter;

        public BuildingDataController(BuildingDataPostgreSQLConverter buildingDataPostgreSQLConverter)
        {
            this.buildingDataPostgreSQLConverter = buildingDataPostgreSQLConverter;
        }

        /// <summary>
        /// Retrieves all available column categories.
        /// </summary>
        [HttpGet("categories", Name = $"{nameof(BuildingDataController)}_{nameof(GetCategoriesAsync)}")]
        [ApiExplorerSettings(IgnoreApi = false)]
        [ProducesResponseType(typeof(List<string>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetCategoriesAsync()
        {
            HashSet<string>? categories = await buildingDataPostgreSQLConverter.GetCategoriesAsync();
            if (categories is null || categories.Count == 0)
            {
                return NotFound();
            }

            JsonArray jsonArray = [.. categories];

            string? json = jsonArray.ToJsonString();
            if (string.IsNullOrWhiteSpace(json))
            {
                return NotFound();
            }

            return Content(json, "application/json");
        }

        /// <summary>
        /// Retrieves all columns with given categories (if provided).
        /// </summary>
        [HttpPost("columns", Name = $"{nameof(BuildingDataController)}_{nameof(GetColumnsAsync)}")]
        [ApiExplorerSettings(IgnoreApi = false)]
        [ProducesResponseType(typeof(List<DiGi.PostgreSQL.Table.Classes.Column>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetColumnsAsync([FromBody] List<string>? categories = null)
        {
            List<Column>? columns = await buildingDataPostgreSQLConverter.GetColumnsByCategoriesAsync(categories);
            if (columns is null || columns.Count == 0)
            {
                return NotFound();
            }

            List<DiGi.PostgreSQL.Table.Classes.Column> columns_PostgreSQL = [];
            foreach (Column column in columns)
            {
                DiGi.PostgreSQL.Table.Classes.Column? column_PostgreSQL = DiGi.PostgreSQL.Table.Convert.ToDiGi(column);
                if (column_PostgreSQL is not null)
                {
                    columns_PostgreSQL.Add(column_PostgreSQL);
                }
            }

            string? json = Core.Convert.ToSystem_String(columns_PostgreSQL);
            if (string.IsNullOrWhiteSpace(json))
            {
                return NotFound();
            }

            return Content(json, "application/json");
        }

        /// <summary>
        /// Retrieves unique values for a given column unique id and optionally county id.
        /// </summary>
        [HttpPost("uniquevalues", Name = $"{nameof(BuildingDataController)}_{nameof(GetUniqueValuesAsync)}")]
        [ApiExplorerSettings(IgnoreApi = false)]
        [ProducesResponseType(typeof(List<object>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetUniqueValuesAsync([FromBody] string columnUniqueId, [FromQuery(Name = "countyid")] int? countyId = null)
        {
            IEnumerable<object?>? values;
            if(countyId is null)
            {
                values = await buildingDataPostgreSQLConverter.GetUniqueValuesAsync<object?>(columnUniqueId);
            }
            else
            {
                values = await buildingDataPostgreSQLConverter.GetUniqueValuesAsync<object?>(columnUniqueId, countyId.Value);
            }

            if (values is null || !values.Any())
            {
                return NotFound();
            }

            JsonArray jsonArray = [];
            foreach(object? value in values)
            {
                jsonArray.Add(value);
            }

            string? json = jsonArray.ToJsonString();
            if (string.IsNullOrWhiteSpace(json))
            {
                return NotFound();
            }

            return Content(json, "application/json");
        }

        /// <summary>
        /// Retrieves all available column categories.
        /// </summary>
        [HttpPost("columnuniqueids", Name = $"{nameof(BuildingDataController)}_{nameof(GetColumnUniqueIdsAsync)}")]
        [ApiExplorerSettings(IgnoreApi = false)]
        [ProducesResponseType(typeof(List<string>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetColumnUniqueIdsAsync([FromBody] List<string>? categories = null)
        {
            List<DiGi.PostgreSQL.Table.Classes.ColumnReference>? columnReferences = await buildingDataPostgreSQLConverter.GetColumnReferencesByCategoriesAsync(categories);
            if (columnReferences is null || columnReferences.Count == 0)
            {
                return NotFound();
            }

            List<string> columnUniqueIds = [];
            foreach (DiGi.PostgreSQL.Table.Classes.ColumnReference columnReference in columnReferences)
            {
                if (columnReference.UniqueId is string columnUniqueId && !string.IsNullOrWhiteSpace(columnUniqueId))
                {
                    columnUniqueIds.Add(columnUniqueId);
                }
            }

            JsonArray jsonArray = [.. columnUniqueIds];

            string? json = jsonArray.ToJsonString();
            if (string.IsNullOrWhiteSpace(json))
            {
                return NotFound();
            }

            return Content(json, "application/json");
        }

        /// <summary>
        /// Retrieves a building data table by building data query (column unique ids, county id and references).
        /// </summary>
        [HttpPost("tablebybuildingdataquery", Name = $"{nameof(BuildingDataController)}_{nameof(GetTableByBuildingDataQueryAsync)}")]
        [ApiExplorerSettings(IgnoreApi = false)]
        [ProducesResponseType(typeof(DiGi.PostgreSQL.Table.Classes.Table), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetTableByBuildingDataQueryAsync([FromBody] BuildingDataQuery buildingDataQuery)
        {
            Serilog.Modify.Log("{Type}:{Name} started", nameof(BuildingDataController), nameof(GetTableByBuildingDataQueryAsync));

            IEnumerable<string>? columnUniqueIds = buildingDataQuery.ColumnUniqueIds;
            if (columnUniqueIds is not null && !columnUniqueIds.Any())
            {
                columnUniqueIds = null;
            }

            Table? table = await buildingDataPostgreSQLConverter.PullAsync(buildingDataQuery.References, buildingDataQuery.CountyId, columnUniqueIds);
            if (table is null)
            {
                return NotFound();
            }

            string? json = Core.IO.Table.Convert.ToSystem_String<Table, Column, Row>(table);
            if (string.IsNullOrWhiteSpace(json))
            {
                return NotFound();
            }

            return Content(json, "application/json");
        }
    }
}