using DiGi.Core.IO.Table.Classes;
using DiGi.GIS.Classes;
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
        /// Initializes a new instance of the BuildingDataController class.
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
        /// Asynchronously retrieves all column references, optionally filtered by the specified categories.
        /// </summary>
        /// <param name="categories">An optional list of category names to filter the column references by.</param>
        /// <returns>A task representing the asynchronous operation, returning a list of column references.</returns>
        [HttpGet("columnreferences", Name = $"{nameof(BuildingDataController)}_{nameof(GetColumnReferencesAsync)}")]
        [ApiExplorerSettings(IgnoreApi = false)]
        [ProducesResponseType(typeof(List<DiGi.PostgreSQL.Table.Classes.ColumnReference>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetColumnReferencesAsync([FromQuery(Name = "categories")] List<string>? categories = null)
        {
            List<DiGi.PostgreSQL.Table.Classes.ColumnReference>? columnReferences = await buildingDataPostgreSQLConverter.GetColumnReferencesByCategoriesAsync(categories);
            if (columnReferences is null || columnReferences.Count == 0)
            {
                return NotFound();
            }

            string? json = Core.Convert.ToSystem_String(columnReferences);
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
        [ApiExplorerSettings(IgnoreApi = true)]
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
        [ApiExplorerSettings(IgnoreApi = true)]
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
        /// Generates a value range distribution histogram for a specific building data column inside a county partition, applying optional dynamic filters.
        /// </summary>
        /// <param name="histogramRequestParameter">The parameter containing the target column, county identifier, desired bucket count, and optional dynamic filters.</param>
        /// <returns>A task representing the asynchronous operation, returning the histogram bucket list as a JSON array.</returns>
        [HttpPost("histogramsummary", Name = $"{nameof(BuildingDataController)}_{nameof(GetHistogramSummaryAsync)}")]
        [ApiExplorerSettings(IgnoreApi = false)]
        [ProducesResponseType(typeof(JsonArray), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetHistogramSummaryAsync([FromBody] HistogramRequestParameter histogramRequestParameter)
        {
            Serilog.Modify.Log("{Type}:{Name} started", nameof(BuildingDataController), nameof(GetHistogramSummaryAsync));

            JsonArray? histogramArray = await buildingDataPostgreSQLConverter.GetHistogramSummaryAsync(
                histogramRequestParameter.ColumnUniqueId,
                histogramRequestParameter.BucketCount,
                histogramRequestParameter.CountyId,
                histogramRequestParameter.FilterGroup);

            if (histogramArray is null)
            {
                return NotFound();
            }

            string json = histogramArray.ToJsonString();
            return Content(json, "application/json");
        }

        /// <summary>
        /// Computes multi-value statistical summaries (SplitDistinctCount, SplitValueDistribution) on a partition column.
        /// </summary>
        /// <param name="multivalueAggregateRequestParameter">The parameter containing target column, multi-value aggregate function, county identifier, and optional separator.</param>
        /// <returns>A task representing the asynchronous operation, returning the aggregate result as a JSON node.</returns>
        [HttpPost("aggregatesummary/multivalue", Name = $"{nameof(BuildingDataController)}_{nameof(GetMultivalueAggregateSummaryAsync)}")]
        [ApiExplorerSettings(IgnoreApi = false)]
        [ProducesResponseType(typeof(JsonNode), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetMultivalueAggregateSummaryAsync([FromBody] MultivalueAggregateRequestParameter multivalueAggregateRequestParameter)
        {
            Serilog.Modify.Log("{Type}:{Name} started", nameof(BuildingDataController), nameof(GetMultivalueAggregateSummaryAsync));

            JsonNode? resultNode = await buildingDataPostgreSQLConverter.GetAggregateSummaryAsync(
                multivalueAggregateRequestParameter.ColumnUniqueId,
                multivalueAggregateRequestParameter.MultivalueAggregateFunction,
                multivalueAggregateRequestParameter.CountyId,
                multivalueAggregateRequestParameter.Separator,
                multivalueAggregateRequestParameter.FilterGroup);

            if (resultNode is null)
            {
                return NotFound();
            }

            string json = resultNode.ToJsonString();
            return Content(json, "application/json");
        }

        /// <summary>
        /// Computes single-value statistical summaries (Avg, Sum, Min, Max, Count, DistinctCount) on a partition column.
        /// </summary>
        /// <param name="singlevalueAggregateRequestParameter">The parameter containing target column, single-value aggregate function, and county identifier.</param>
        /// <returns>A task representing the asynchronous operation, returning the aggregate result as a JSON node.</returns>
        [HttpPost("aggregatesummary/singlevalue", Name = $"{nameof(BuildingDataController)}_{nameof(GetSinglevalueAggregateSummaryAsync)}")]
        [ApiExplorerSettings(IgnoreApi = false)]
        [ProducesResponseType(typeof(JsonNode), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetSinglevalueAggregateSummaryAsync([FromBody] SinglevalueAggregateRequestParameter singlevalueAggregateRequestParameter)
        {
            Serilog.Modify.Log("{Type}:{Name} started", nameof(BuildingDataController), nameof(GetSinglevalueAggregateSummaryAsync));

            JsonNode? resultNode = await buildingDataPostgreSQLConverter.GetAggregateSummaryAsync(
                singlevalueAggregateRequestParameter.ColumnUniqueId,
                singlevalueAggregateRequestParameter.SinglevalueAggregateFunction,
                singlevalueAggregateRequestParameter.CountyId,
                singlevalueAggregateRequestParameter.FilterGroup);

            if (resultNode is null)
            {
                return NotFound();
            }

            string json = resultNode.ToJsonString();
            return Content(json, "application/json");
        }

        /// <summary>
        /// Retrieves a building data table using keyset-based paginated cursor streaming.
        /// </summary>
        /// <param name="buildingDataByPagingParameter">The parameter containing paging options, including column projections, county identifier, cursor, and page size.</param>
        /// <returns>A task representing the asynchronous operation, returning the populated table.</returns>
        [HttpPost("tablebybuildingdatabypagingparameter", Name = $"{nameof(BuildingDataController)}_{nameof(GetTableByBuildingDataByPagingParameterAsync)}")]
        [ApiExplorerSettings(IgnoreApi = false)]
        [ProducesResponseType(typeof(DiGi.PostgreSQL.Table.Classes.Table), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetTableByBuildingDataByPagingParameterAsync([FromBody] BuildingDataByPagingParameter buildingDataByPagingParameter)
        {
            Serilog.Modify.Log("{Type}:{Name} started", nameof(BuildingDataController), nameof(GetTableByBuildingDataByPagingParameterAsync));

            IEnumerable<string>? columnUniqueIds = buildingDataByPagingParameter.ColumnUniqueIds;
            if (columnUniqueIds is not null && !columnUniqueIds.Any())
            {
                columnUniqueIds = null;
            }

            Table? table = await buildingDataPostgreSQLConverter.PullAsync(
                buildingDataByPagingParameter.CountyId,
                columnUniqueIds,
                buildingDataByPagingParameter.Cursor,
                buildingDataByPagingParameter.PageSize);

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

        /// <summary>
        /// Retrieves a building data table filtered by the specified dynamic hierarchical filters.
        /// </summary>
        /// <param name="buildingDataByFilterGroupParameter">The parameter containing the dynamic filter group and optional column unique identifiers.</param>
        /// <returns>A task representing the asynchronous operation, returning the populated filtered table.</returns>
        [HttpPost("tablebyfiltergroup", Name = $"{nameof(BuildingDataController)}_{nameof(GetTableByFilterGroupAsync)}")]
        [ApiExplorerSettings(IgnoreApi = false)]
        [ProducesResponseType(typeof(DiGi.PostgreSQL.Table.Classes.Table), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetTableByFilterGroupAsync([FromBody] BuildingDataByFilterGroupParameter buildingDataByFilterGroupParameter)
        {
            Serilog.Modify.Log("{Type}:{Name} started", nameof(BuildingDataController), nameof(GetTableByFilterGroupAsync));

            List<string>? strings_ColumnUniqueIds = buildingDataByFilterGroupParameter.ColumnUniqueIds;
            if (strings_ColumnUniqueIds is not null && !strings_ColumnUniqueIds.Any())
            {
                strings_ColumnUniqueIds = null;
            }

            List<Column>? columns = await buildingDataPostgreSQLConverter.GetColumnsByUniqueIdsAsync(strings_ColumnUniqueIds);
            if (columns is null || columns.Count == 0)
            {
                return NotFound();
            }

            Table table_Result = new Table(columns);

            bool isSuccess = await buildingDataPostgreSQLConverter.PullAsync(table_Result, buildingDataByFilterGroupParameter.FilterGroup);
            if (!isSuccess)
            {
                return NotFound();
            }

            string? string_Json = Core.IO.Table.Convert.ToSystem_String<Table, Column, Row>(table_Result);
            if (string.IsNullOrWhiteSpace(string_Json))
            {
                return NotFound();
            }

            return Content(string_Json, "application/json");
        }

        /// <summary>
        /// Retrieves a building data table for one specific building.
        /// </summary>
        /// <param name="reference">Building reference</param>
        /// <param name="countyId">The unique identifier of the county for which building belongs to.</param>
        /// <returns>A task representing the asynchronous operation, returning the populated filtered table with data for sigle building.</returns>
        [HttpGet("tablebyreference", Name = $"{nameof(BuildingDataController)}_{nameof(GetTableByReferenceAsync)}")]
        [ApiExplorerSettings(IgnoreApi = false)]
        [ProducesResponseType(typeof(DiGi.PostgreSQL.Table.Classes.Table), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetTableByReferenceAsync([FromQuery(Name = "reference")] string reference, [FromQuery(Name = "countyid")] int? countyId = null)
        {
            Serilog.Modify.Log("{Type}:{Name} started", nameof(BuildingDataController), nameof(GetTableByReferenceAsync));
            Serilog.Modify.Log("Reference provided: {Id}", reference.ToString() ?? string.Empty);
            Serilog.Modify.Log("CountyId provided: {Id}", countyId?.ToString() ?? string.Empty);

            if(string.IsNullOrWhiteSpace(reference))
            {
                Serilog.Modify.Log(Serilog.Enums.LogEventLevel.Error, "Reference cannot be null");
                return BadRequest();
            }

            BuildingDataByReferencesParameter buildingDataByReferencesParameter = new ()
            {
                References = [reference],
                CountyId = countyId
            };

            return await GetTableByBuildingDataByReferencesParameterAsync(buildingDataByReferencesParameter);
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
            if (countyId is null)
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

        /// <summary> Retrieves unique values for a given <see cref="UniqueValuesByColumnUniqueIdParameter" /> (column unique id and optionally county id), applying optional dynamic filters. </summary>
        /// <param name="uniqueValuesByColumnUniqueIdParameter">The parameter containing the column unique identifier, optional county identifier, and optional dynamic filters.</param>
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
                values = await buildingDataPostgreSQLConverter.GetUniqueValuesAsync<object?>(
                    uniqueValuesByColumnUniqueIdParameter.ColumnUniqueId,
                    uniqueValuesByColumnUniqueIdParameter.FilterGroup);
            }
            else
            {
                values = await buildingDataPostgreSQLConverter.GetUniqueValuesAsync<object?>(
                    uniqueValuesByColumnUniqueIdParameter.ColumnUniqueId,
                    uniqueValuesByColumnUniqueIdParameter.CountyId.Value,
                    uniqueValuesByColumnUniqueIdParameter.FilterGroup);
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