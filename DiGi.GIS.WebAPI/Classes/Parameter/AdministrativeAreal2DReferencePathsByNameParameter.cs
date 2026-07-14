using System.ComponentModel.DataAnnotations;
using System.Text.Json.Nodes;

namespace DiGi.GIS.WebAPI.Classes
{
    /// <summary>
    /// Represents a parameter containing text for querying administrative area reference paths.
    /// </summary>
    public class AdministrativeAreal2DReferencePathsByNameParameter : DiGi.WebAPI.Classes.Parameter
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AdministrativeAreal2DReferencePathsByNameParameter"/> class.
        /// </summary>
        public AdministrativeAreal2DReferencePathsByNameParameter()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AdministrativeAreal2DReferencePathsByNameParameter"/> class with the specified text (search phrase).
        /// </summary>
        /// <param name="text">The text to search for.</param>
        public AdministrativeAreal2DReferencePathsByNameParameter(string text)
        {
            Text = text;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AdministrativeAreal2DReferencePathsByNameParameter"/> class using an <see cref="JsonObject"/> object.
        /// </summary>
        /// <param name="jsonObject">The JSON object containing the parameter values.</param>
        public AdministrativeAreal2DReferencePathsByNameParameter(JsonObject jsonObject)
        : base(jsonObject)
        {
        }

        /// <summary>
        /// Text to search for in the names of the administrative areal 2D reference paths. The search is case-insensitive and matches any path whose name contains the specified text.
        /// </summary>
        [Required]
        public string? Text { get; set; } = string.Empty;
    }
}
