using DiGi.PostgreSQL.Table.Enums;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Nodes;

namespace DiGi.GIS.PostgreSQL.WebAPI.Classes
{
    /// <summary>
    /// Parameter class containing options for database aggregation queries.
    /// </summary>
    public class AggregateRequestParameter : DiGi.WebAPI.Classes.Parameter
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AggregateRequestParameter"/> class.
        /// </summary>
        public AggregateRequestParameter()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AggregateRequestParameter"/> class using an <see cref="JsonObject"/> object.
        /// </summary>
        /// <param name="jsonObject">The JSON object containing data used to initialize the parameter.</param>
        public AggregateRequestParameter(JsonObject jsonObject)
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
        /// Gets or sets the aggregation function to perform.
        /// </summary>
        /// <example>Sum</example>
        [Required]
        public AggregateFunction AggregateFunction { get; set; }

        /// <summary>
        /// Gets or sets the optional string separator; defaults to null triggering dynamic auto-detection.
        /// </summary>
        /// <example>","</example>
        public string? Separator { get; set; }
    }
}