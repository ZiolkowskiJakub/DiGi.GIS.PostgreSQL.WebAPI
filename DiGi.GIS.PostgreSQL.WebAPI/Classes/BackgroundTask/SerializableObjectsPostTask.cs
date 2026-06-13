using DiGi.Core.Classes;
using DiGi.GIS.Interfaces;
using DiGi.GIS.PostgreSQL.WebAPI.Interfaces;
using System;
using System.Collections.Generic;

namespace DiGi.GIS.PostgreSQL.WebAPI.Classes
{
    /// <summary>
    /// Represents a base class for background tasks that handle the posting of serializable GIS objects to the PostgreSQL database.
    /// </summary>
    /// <typeparam name="T">The type of serializable object being posted, which must implement <see cref="IGISSerializableObject"/>.</typeparam>
    public abstract class SerializableObjectsPostTask<T> : ReportableBackgroundTask<long>, IGISPostgreSQLWebAPIObject where T : IGISSerializableObject
    {
        protected readonly GISPostgreSQLWebAPIManager GISPostgreSQLWebAPIManager;

        /// <summary>
        /// Initializes a new instance of the SerializableObjectsPostTask class.
        /// </summary>
        /// <param name="gISPostgreSQLWebAPIManager">The GIS PostgreSQL Web API manager used to perform database operations.</param>
        public SerializableObjectsPostTask(GISPostgreSQLWebAPIManager gISPostgreSQLWebAPIManager)
        {
            GISPostgreSQLWebAPIManager = gISPostgreSQLWebAPIManager ?? throw new ArgumentNullException(nameof(gISPostgreSQLWebAPIManager));
        }

        /// <summary>
        /// Gets or sets the options used for posting serializable objects.
        /// </summary>
        public SerializableObjectsPostOptions SerializableObjectsPostOptions { get; set; } = new();

        /// <summary>
        /// Gets or sets the collection of serializable objects to be posted.
        /// </summary>
        public IEnumerable<T>? Values { get; set; }
    }
}