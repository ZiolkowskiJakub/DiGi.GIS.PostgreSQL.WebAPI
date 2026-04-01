using DiGi.Core.Classes;
using DiGi.GIS.Interfaces;
using DiGi.GIS.PostgreSQL.WebAPI.Interfaces;
using System;
using System.Collections.Generic;

namespace DiGi.GIS.PostgreSQL.WebAPI.Classes
{
    public abstract class SerializableObjectsPostTask<T> : ReportableBackgroundTask<long>, IGISPostgreSQLWebAPIObject where T : IGISSerializableObject
    {
        protected readonly GISPostgreSQLWebAPIManager GISPostgreSQLWebAPIManager;

        public SerializableObjectsPostTask(GISPostgreSQLWebAPIManager gISPostgreSQLWebAPIManager)
        {
            GISPostgreSQLWebAPIManager = gISPostgreSQLWebAPIManager ?? throw new ArgumentNullException(nameof(gISPostgreSQLWebAPIManager));
        }

        public SerializableObjectsPostOptions SerializableObjectsPostOptions { get; set; } = new();

        public IEnumerable<T>? Values { get; set; }
    }
}