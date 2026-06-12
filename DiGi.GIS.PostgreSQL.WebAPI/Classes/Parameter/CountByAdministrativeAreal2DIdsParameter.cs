using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Nodes;

namespace DiGi.GIS.PostgreSQL.WebAPI.Classes
{
    public class CountByAdministrativeAreal2DIdsParameter : DiGi.WebAPI.Classes.Parameter
    {
        public CountByAdministrativeAreal2DIdsParameter()
        {
        }

        public CountByAdministrativeAreal2DIdsParameter(JsonObject jsonObject)
            : base(jsonObject)
        {
        }

        public CountByAdministrativeAreal2DIdsParameter(CountByAdministrativeAreal2DIdsParameter countByAdministrativeAreal2DIdsParameter)
        {
            if(countByAdministrativeAreal2DIdsParameter is not null)
            {
                AdministrativeAreal2DIds = countByAdministrativeAreal2DIdsParameter.AdministrativeAreal2DIds;
            }
        }

        [Required]
        public IEnumerable<int> AdministrativeAreal2DIds { get; set; } = [];

   }
}