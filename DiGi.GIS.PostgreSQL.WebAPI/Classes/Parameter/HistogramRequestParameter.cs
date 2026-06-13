using DiGi.PostgreSQL.Table.Classes;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Nodes;

namespace DiGi.GIS.PostgreSQL.WebAPI.Classes
{
    /// <summary>
    /// Parameter class containing options for generating histograms.
    /// </summary>
    public class HistogramRequestParameter : DiGi.WebAPI.Classes.Parameter
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HistogramRequestParameter"/> class.
        /// </summary>
        public HistogramRequestParameter()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HistogramRequestParameter"/> class using an <see cref="JsonObject"/> object.
        /// </summary>
        /// <param name="jsonObject">The JSON object containing data used to initialize the parameter.</param>
        public HistogramRequestParameter(JsonObject jsonObject)
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
        /// Gets or sets the column unique identifier to calculate value distributions for.
        /// </summary>
        /// <example>"column_unique_id_123"</example>
        [Required]
        public string ColumnUniqueId { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the total number of histogram buckets. Defaults to 10.
        /// </summary>
        /// <example>20</example>
        public int BucketCount { get; set; } = 10;

        /// <summary>
        /// Gets or sets the optional dynamic hierarchical filters to apply prior to generating the histogram.
        /// </summary>
        public FilterGroup? FilterGroup { get; set; }
    }
}