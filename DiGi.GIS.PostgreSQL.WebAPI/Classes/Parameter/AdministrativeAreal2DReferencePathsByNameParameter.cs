using System.ComponentModel.DataAnnotations;
using System.Text.Json.Nodes;

namespace DiGi.GIS.PostgreSQL.WebAPI.Classes
{
    public class AdministrativeAreal2DReferencePathsByNameParameter : DiGi.WebAPI.Classes.Parameter
    {
        /// <summary>
        /// Text to search for in the names of the administrative areal 2D reference paths. The search is case-insensitive and matches any path whose name contains the specified text.
        /// </summary>
        [Required]
        public string? Text { get; set; } = string.Empty;

        public AdministrativeAreal2DReferencePathsByNameParameter()
        {
        }

        public AdministrativeAreal2DReferencePathsByNameParameter(string text)
        {
            Text = text;
        }

        public AdministrativeAreal2DReferencePathsByNameParameter(JsonObject jsonObject)
        : base(jsonObject)
        {

        }
    }
}