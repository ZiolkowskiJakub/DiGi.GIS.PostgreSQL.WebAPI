using DiGi.PostgreSQL.Table.Classes;
using DiGi.PostgreSQL.Table.Enums;
using System.ComponentModel.DataAnnotations;

namespace DiGi.GIS.PostgreSQL.WebAPI.Classes
{
    /// <summary>
    /// Parameter class containing options for multi-value database aggregation queries.
    /// </summary>
    public class MultivalueAggregateRequestParameter : DiGi.WebAPI.Classes.Parameter
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MultivalueAggregateRequestParameter"/> class.
        /// </summary>
        public MultivalueAggregateRequestParameter()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MultivalueAggregateRequestParameter"/> class using a <see cref="System.Text.Json.Nodes.JsonObject"/> object.
        /// </summary>
        /// <param name="jsonObject">The JSON object containing data used to initialize the parameter.</param>
        public MultivalueAggregateRequestParameter(System.Text.Json.Nodes.JsonObject jsonObject)
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
        /// Gets or sets the column unique identifier to calculate statistics for.
        /// </summary>
        /// <example>"col_unique_id_123"</example>
        [Required]
        public string ColumnUniqueId { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the multi-value aggregation function to perform.
        /// </summary>
        /// <example>SplitDistinctCount</example>
        [Required]
        public MultivalueAggregateFunction MultivalueAggregateFunction { get; set; }

        /// <summary>
        /// Gets or sets the optional string separator; defaults to null triggering dynamic auto-detection.
        /// </summary>
        /// <example>","</example>
        public string? Separator { get; set; }

        /// <summary>
        /// Gets or sets the optional dynamic hierarchical filters to apply prior to aggregation.
        /// </summary>
        public FilterGroup? FilterGroup { get; set; }
    }
}