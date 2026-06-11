using DiGi.Core.IO.Table.Classes;
using DiGi.GIS.PostgreSQL.Classes;
using DiGi.PostgreSQL.Table;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace DiGi.GIS.PostgreSQL.WebAPI.Classes
{
    /// <summary>
    /// Controller responsible for handling API requests related to building data retrieved from a PostgreSQL database.
    /// </summary>
    [ApiController]
    [Route("gis/[controller]")]
    public class BuildingDataController : DiGi.WebAPI.Classes.WebAPIController
    {
        private readonly BuildingDataPostgreSQLConverter buildingDataPostgreSQLConverter;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="buildingDataPostgreSQLConverter">The <see cref="BuildingDataPostgreSQLConverter" /> used to handle building data operations and database conversions.</param>
        public BuildingDataController(BuildingDataPostgreSQLConverter buildingDataPostgreSQLConverter)
        {
            this.buildingDataPostgreSQLConverter = buildingDataPostgreSQLConverter;
        }

        /// <summary> 
        /// Asynchronously retrieves all available building data column categories. 
        /// </summary>
        /// <returns>A task that represents the asynchronous operation.</returns>
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
        /// Asynchronously retrieves all available column definitions for building data. 
        /// </summary>
        /// <returns>A task that represents the asynchronous operation.</returns>
        [HttpGet("columns", Name = $"{nameof(BuildingDataController)}_{nameof(GetColumnsAsync)}")]
        [ApiExplorerSettings(IgnoreApi = false)]
        [ProducesResponseType(typeof(List<DiGi.PostgreSQL.Table.Classes.Column>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetColumnsAsync()
        {
            List<Column>? columns = await buildingDataPostgreSQLConverter.GetColumnsByCategoriesAsync();
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
        /// Asynchronously retrieves all columns filtered by the specified categories.
        /// </summary>
        /// <param name="categories">An optional list of category names to filter the columns by. If null, the filtering behavior is determined by the underlying data source.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        [HttpPost("columnsbycategories", Name = $"{nameof(BuildingDataController)}_{nameof(GetColumnsByCategoriesAsync)}")]
        [ApiExplorerSettings(IgnoreApi = false)]
        [ProducesResponseType(typeof(List<DiGi.PostgreSQL.Table.Classes.Column>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetColumnsByCategoriesAsync([FromBody] List<string>? categories = null)
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
        /// Retrieves all columns with given categories by columns by categories parameter (which contains categories).
        /// </summary>
        /// <param name="columnsByCategoriesParameter"> The parameter containing the categories for querying columns. </param>
        /// <returns>Column <see cref="DiGi.PostgreSQL.Table.Classes.Column"/></returns>
        [HttpPost("columnsbycategoriesparameter", Name = $"{nameof(BuildingDataController)}_{nameof(GetColumnsByCategoriesParameterAsync)}")]
        [ApiExplorerSettings(IgnoreApi = false)]
        [ProducesResponseType(typeof(List<DiGi.PostgreSQL.Table.Classes.Column>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetColumnsByCategoriesParameterAsync([FromBody] ColumnsByCategoriesParameter columnsByCategoriesParameter)
        {
            List<Column>? columns = await buildingDataPostgreSQLConverter.GetColumnsByCategoriesAsync(columnsByCategoriesParameter.Categories);
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
        /// Retrieves the unique identifiers for columns, optionally filtered by the specified categories.
        /// </summary>
        /// <param name="categories">An optional list of category names used to filter the column references.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
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

        /// <summary> Retrieves a building data table by building data by references parameter (column unique ids, county id and references).</summary>
        /// <param name="buildingDataByReferencesParameter">The parameter containing references for querying building data, including column unique identifiers, county identifier, and specific references.</param>
        /// <returns>An <see cref="IActionResult" /> representing the result of the operation, typically containing a <see cref="DiGi.PostgreSQL.Table.Classes.Table" /> if found.</returns>
        [HttpPost("tablebybuildingdatabyreferencesparameter", Name = $"{nameof(BuildingDataController)}_{nameof(GetTableByBuildingDataByReferencesParameterAsync)}")]
        [ApiExplorerSettings(IgnoreApi = false)]
        [ProducesResponseType(typeof(DiGi.PostgreSQL.Table.Classes.Table), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetTableByBuildingDataByReferencesParameterAsync([FromBody] BuildingDataByReferencesParameter buildingDataByReferencesParameter)
        {
            Serilog.Modify.Log("{Type}:{Name} started", nameof(BuildingDataController), nameof(GetTableByBuildingDataByReferencesParameterAsync));

            IEnumerable<string>? columnUniqueIds = buildingDataByReferencesParameter.ColumnUniqueIds;
            if (columnUniqueIds is not null && !columnUniqueIds.Any())
            {
                columnUniqueIds = null;
            }

            Table? table = await buildingDataPostgreSQLConverter.PullAsync(buildingDataByReferencesParameter.References, buildingDataByReferencesParameter.CountyId, columnUniqueIds);
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

        /// <summary> Retrieves a building data table by building data by subdivision ids parameter (column unique ids, subdivision ids). </summary>
        /// <param name="buildingDataBySubdivisionIdsParameter">The parameter containing the subdivision IDs and optional column unique identifiers for querying building data.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        [HttpPost("tablebybuildingdatabysubdivisionidsparameter", Name = $"{nameof(BuildingDataController)}_{nameof(GetTableByBuildingDataBySubdivisionIdsParameterAsync)}")]
        [ApiExplorerSettings(IgnoreApi = false)]
        [ProducesResponseType(typeof(DiGi.PostgreSQL.Table.Classes.Table), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetTableByBuildingDataBySubdivisionIdsParameterAsync([FromBody] BuildingDataBySubdivisionIdsParameter buildingDataBySubdivisionIdsParameter)
        {
            Serilog.Modify.Log("{Type}:{Name} started", nameof(BuildingDataController), nameof(GetTableByBuildingDataBySubdivisionIdsParameterAsync));

            IEnumerable<string>? columnUniqueIds = buildingDataBySubdivisionIdsParameter.ColumnUniqueIds;
            if (columnUniqueIds is not null && !columnUniqueIds.Any())
            {
                columnUniqueIds = null;
            }

            Table? table = await buildingDataPostgreSQLConverter.PullAsync(IO.Constants.Column.SubdivisionId.UniqueId()!, buildingDataBySubdivisionIdsParameter.SubdivisionIds, columnUniqueIds);
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

        /// <summary> Retrieves unique values for a specified column unique identifier and an optional county identifier. </summary>
        /// <param name="columnUniqueId">The unique identifier of the column from which to retrieve unique values.</param>
        /// <param name="countyId">The optional integer identifier of the county used to filter the results.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        [HttpGet("uniquevalues", Name = $"{nameof(BuildingDataController)}_{nameof(GetUniqueValuesAsync)}")]
        [ApiExplorerSettings(IgnoreApi = false)]
        [ProducesResponseType(typeof(List<object>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetUniqueValuesAsync([FromQuery(Name = "columnuniqueid")] string columnUniqueId, [FromQuery(Name = "countyid")] int? countyId = null)
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

        /// <summary> Retrieves unique values for a given <see cref="UniqueValuesByColumnUniqueIdParameter" /> (column unique id and optionally county id). </summary>
        /// <param name="uniqueValuesByColumnUniqueIdParameter">The parameter containing the column unique identifier and optional county identifier.</param>
        /// <returns>An <see cref="IActionResult" /> representing the result of the operation, typically a list of unique values or a not found status.</returns>
        [HttpPost("uniquevaluesbycolumnuniqueidparameter", Name = $"{nameof(BuildingDataController)}_{nameof(GetUniqueValuesByColumnUniqueIdParameterAsync)}")]
        [ApiExplorerSettings(IgnoreApi = false)]
        [ProducesResponseType(typeof(List<object>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetUniqueValuesByColumnUniqueIdParameterAsync([FromBody] UniqueValuesByColumnUniqueIdParameter uniqueValuesByColumnUniqueIdParameter)
        {
            IEnumerable<object?>? values;
            if (uniqueValuesByColumnUniqueIdParameter.CountyId is null)
            {
                values = await buildingDataPostgreSQLConverter.GetUniqueValuesAsync<object?>(uniqueValuesByColumnUniqueIdParameter.ColumnUniqueId);
            }
            else
            {
                values = await buildingDataPostgreSQLConverter.GetUniqueValuesAsync<object?>(uniqueValuesByColumnUniqueIdParameter.ColumnUniqueId, uniqueValuesByColumnUniqueIdParameter.CountyId.Value);
            }

            if (values is null || !values.Any())
            {
                return NotFound();
            }

            JsonArray jsonArray = [];
            foreach (object? value in values)
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
    }
}
