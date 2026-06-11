using System.ComponentModel.DataAnnotations;
using System.Text.Json.Nodes;

namespace DiGi.GIS.PostgreSQL.WebAPI.Classes
{
    /// <summary>
    /// Represents a parameter containing column unique id for querying unique values.
    /// </summary>
    public class UniqueValuesByColumnUniqueIdParameter : DiGi.WebAPI.Classes.Parameter
    {
        /// <summary>
        /// Gets or sets the unique identifier of the column (Column.UniqueId).
        /// </summary>
        [Required]
        public string ColumnUniqueId { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the county identifier.
        /// </summary>
        public int? CountyId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public UniqueValuesByColumnUniqueIdParameter()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="columnUniqueId">The unique identifier of the column.</param>
        /// <param name="countyId">The optional unique identifier of the county.</param>
        public UniqueValuesByColumnUniqueIdParameter(string columnUniqueId, int? countyId)
        {
            ColumnUniqueId = columnUniqueId;
            CountyId = countyId;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="jsonObject">The <see cref="T:System.Text.Json.Nodes.JsonObject" /> containing the data used to initialize the parameter.</param>
        public UniqueValuesByColumnUniqueIdParameter(JsonObject jsonObject)
        : base(jsonObject)
        {

        }
    }
}