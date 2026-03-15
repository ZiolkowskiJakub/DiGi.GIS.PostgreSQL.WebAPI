using DiGi.Core.Classes;
using DiGi.GIS.Classes;
using DiGi.GIS.PostgreSQL.WebAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiGi.GIS.PostgreSQL.WebAPI.Classes
{
    public class GISPostgreSQLWebAPIAdministrativeAreal2DPostTask : BackgroundTask, IGISPostgreSQLWebAPIObject
    {
        private readonly GISPostgreSQLWebAPIManager gISPostgreSQLWebAPIManager;

        public IEnumerable<AdministrativeAreal2D>? AdministrativeAreal2Ds { get; set; }

        public GISPostgreSQLWebAPIAdministrativeAreal2DPostTask(GISPostgreSQLWebAPIManager gISPostgreSQLWebAPIManager)
        {
            this.gISPostgreSQLWebAPIManager = gISPostgreSQLWebAPIManager ?? throw new ArgumentNullException(nameof(gISPostgreSQLWebAPIManager));
        }

        /// <summary>
        /// Concrete implementation of the background work.
        /// </summary>
        protected override async Task<bool> ExecuteAsync()
        {
            if(AdministrativeAreal2Ds is null || !AdministrativeAreal2Ds.Any())
            {
                return false;
            }

            return await gISPostgreSQLWebAPIManager.PostAsync(AdministrativeAreal2Ds);
        }

    }
}
