using DiGi.Core.Classes;
using DiGi.GIS.Classes;
using DiGi.GIS.PostgreSQL.WebAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiGi.GIS.PostgreSQL.WebAPI.Classes
{
    public class GISPostgreSQLWebAPIBuilding2DPostTask : BackgroundTask, IGISPostgreSQLWebAPIObject
    {
        private readonly GISPostgreSQLWebAPIManager gISPostgreSQLWebAPIManager;

        public GISPostgreSQLWebAPIBuilding2DPostTask(GISPostgreSQLWebAPIManager gISPostgreSQLWebAPIManager)
        {
            this.gISPostgreSQLWebAPIManager = gISPostgreSQLWebAPIManager ?? throw new ArgumentNullException(nameof(gISPostgreSQLWebAPIManager));
        }

        public IEnumerable<Building2D>? Building2Ds { get; set; }

        public string? Code { get; set; }
        
        protected override async Task<bool> ExecuteAsync()
        {
            if(Building2Ds is null || !Building2Ds.Any())
            {
                return false;
            }

            List<Building2D> building2Ds = [.. Building2Ds];

            bool result = true;

            while (building2Ds.Count > 0)
            {
                int count = Math.Min(building2Ds.Count, 1000);

                result = await gISPostgreSQLWebAPIManager.PostAsync(building2Ds.GetRange(0, count), Code);
                if(!result)
                {
                    break;
                }

                building2Ds.RemoveRange(0, count);
            }

            return result;
        }

    }
}
