using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Nodes;

namespace DiGi.GIS.WebAPI.Classes
{
    /// <summary>
    /// Represents a parameter object used to perform counting operations based on a collection of administrative areal 2D identifiers.
    /// </summary>
    public class CountByAdministrativeAreal2DIdsParameter : DiGi.WebAPI.Classes.Parameter
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CountByAdministrativeAreal2DIdsParameter"/> class.
        /// </summary>
        public CountByAdministrativeAreal2DIdsParameter()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CountByAdministrativeAreal2DIdsParameter"/> class using the provided JSON object.
        /// </summary>
        /// <param name="jsonObject">The <see cref="JsonObject"/> containing the data used to initialize the parameter.</param>
        public CountByAdministrativeAreal2DIdsParameter(JsonObject jsonObject)
            : base(jsonObject)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CountByAdministrativeAreal2DIdsParameter"/> class by copying the values from an existing instance.
        /// </summary>
        /// <param name="countByAdministrativeAreal2DIdsParameter">The source instance from which to copy the administrative areal 2D identifiers.</param>
        public CountByAdministrativeAreal2DIdsParameter(CountByAdministrativeAreal2DIdsParameter countByAdministrativeAreal2DIdsParameter)
        {
            if (countByAdministrativeAreal2DIdsParameter is not null)
            {
                AdministrativeAreal2DIds = countByAdministrativeAreal2DIdsParameter.AdministrativeAreal2DIds;
            }
        }

        /// <summary>
        /// Gets or sets the collection of administrative areal 2D identifiers used for counting operations.
        /// </summary>
        [Required]
        public IEnumerable<int> AdministrativeAreal2DIds { get; set; } = [];
    }
}
