using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Nodes;

namespace DiGi.GIS.PostgreSQL.WebAPI.Classes
{
    /// <summary>
    /// Represents a parameter containing categories for querying columns.
    /// </summary>
    public class ColumnsByCategoriesParameter : DiGi.WebAPI.Classes.Parameter
    {
        /// <summary>
        /// Gets or sets the categories for querying columns. All columns will be returned if the collection is null or empty.
        /// </summary>
        public IEnumerable<string> Categories { get; set; } = [];

        /// <summary>
        /// 
        /// </summary>
        public ColumnsByCategoriesParameter()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="categories">The collection of categories for querying columns.</param>
        public ColumnsByCategoriesParameter(IEnumerable<string> categories)
        {
            Categories = categories is null ? [] : [.. categories];
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="jsonObject">The <see cref="T:System.Text.Json.Nodes.JsonObject" /> containing the data used to initialize the parameter.</param>
        public ColumnsByCategoriesParameter(JsonObject jsonObject)
        : base(jsonObject)
        {

        }
    }
}