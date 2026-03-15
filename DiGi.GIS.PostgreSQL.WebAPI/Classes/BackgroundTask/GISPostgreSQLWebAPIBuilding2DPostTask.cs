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

        public IEnumerable<Building2D>? Building2Ds { get; set; }

        public GISPostgreSQLWebAPIBuilding2DPostTask(GISPostgreSQLWebAPIManager gISPostgreSQLWebAPIManager)
        {
            this.gISPostgreSQLWebAPIManager = gISPostgreSQLWebAPIManager ?? throw new ArgumentNullException(nameof(gISPostgreSQLWebAPIManager));
        }

        /// <summary>
        /// Concrete implementation of the background work.
        /// </summary>
        protected override async Task<bool> ExecuteAsync()
        {
            if(Building2Ds is null || !Building2Ds.Any())
            {
                return false;
            }

            return await gISPostgreSQLWebAPIManager.PostAsync(Building2Ds);
        }

    }
}
