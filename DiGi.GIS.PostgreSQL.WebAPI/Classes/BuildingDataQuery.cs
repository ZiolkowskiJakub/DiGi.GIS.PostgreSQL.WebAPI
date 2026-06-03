using DiGi.Core.Classes;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Nodes;

namespace DiGi.GIS.PostgreSQL.WebAPI.Classes
{
    /// <summary>
    /// Represents a query for building data.
    /// </summary>
    public class BuildingDataQuery : SerializableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BuildingDataQuery"/> class.
        /// </summary>
        public BuildingDataQuery()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BuildingDataQuery"/> class using an existing <see cref="BuildingDataQuery"/> object.
        /// </summary>
        /// <param name="buildingDataQuery">The building data query to copy from.</param>
        public BuildingDataQuery(BuildingDataQuery buildingDataQuery)
        {
            if (buildingDataQuery is not null)
            {
                References = buildingDataQuery.References;
                CountyId = buildingDataQuery.CountyId;
                ColumnUniqueIds = buildingDataQuery.ColumnUniqueIds;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BuildingDataQuery"/> class using a JSON object.
        /// </summary>
        /// <param name="jsonObject">The JSON object containing query data.</param>
        public BuildingDataQuery(JsonObject jsonObject)
            : base()
        {
        }

        /// <summary>
        /// Gets or sets the unique identifiers of the columns (Column.UniqueId). All columns will be returned if the collection is null or empty. Required if performance is a concern and the column unique identifiers are available, otherwise the column unique identifiers will be determined by the building data PostgreSQL converter.
        /// </summary>
        public IEnumerable<string> ColumnUniqueIds { get; set; } = [];

        /// <summary>
        /// Gets or sets the county identifier. Required if performance is a concern and the county identifier is available, otherwise the county identifier will be determined by the building data PostgreSQL converter.
        /// </summary>
        public int? CountyId { get; set; } = null;

        /// <summary>
        /// Gets or sets the references for the building data query.
        /// </summary>
        [Required]
        public IEnumerable<string> References { get; set; } = [];
    }
}