using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Nodes;

namespace DiGi.GIS.PostgreSQL.WebAPI.Classes
{
    /// <summary>
    /// Parameter class containing options for keyset-paginated building queries.
    /// </summary>
    public class BuildingDataByPagingParameter : DiGi.WebAPI.Classes.Parameter
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BuildingDataByPagingParameter"/> class.
        /// </summary>
        public BuildingDataByPagingParameter()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BuildingDataByPagingParameter"/> class using an <see cref="JsonObject"/> object.
        /// </summary>
        /// <param name="jsonObject">The JSON object containing data used to initialize the parameter.</param>
        public BuildingDataByPagingParameter(JsonObject jsonObject)
            : base(jsonObject)
        {
        }

        /// <summary>
        /// Gets or sets the target partition identifier (County ID).
        /// </summary>
        /// <example>10365</example>
        [Required]
        public int CountyId { get; set; }

        /// <summary>
        /// Gets or sets the list of column unique identifiers to project in the result.
        /// </summary>
        /// <example>["building_id", "address"]</example>
        public List<string>? ColumnUniqueIds { get; set; }

        /// <summary>
        /// Gets or sets the maximum count of rows per page. Defaults to 250.
        /// </summary>
        /// <example>100</example>
        public int PageSize { get; set; } = 250;

        /// <summary>
        /// Gets or sets the pagination cursor tracking the last processed building reference.
        /// </summary>
        /// <example>eyJpZCI6MTIzfQ==</example>
        public string? Cursor { get; set; }
    }
}