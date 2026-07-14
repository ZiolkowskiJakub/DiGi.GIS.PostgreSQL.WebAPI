using DiGi.Core.Classes;
using DiGi.Core.Interfaces;
using DiGi.GIS.WebAPI.Interfaces;
using System;
using System.Collections.Generic;

namespace DiGi.GIS.WebAPI.Classes
{
    /// <summary>
    /// Represents a base class for background tasks that handle the posting of serializable GIS objects to the PostgreSQL database.
    /// </summary>
    /// <typeparam name="T">The type of serializable object being posted, which must implement <see cref="ISerializableObject"/>.</typeparam>
    public abstract class SerializableObjectsPostTask<T> : ReportableBackgroundTask<long>, IGISWebAPIObject where T : ISerializableObject
    {
        protected readonly GISWebAPIManager GISWebAPIManager;

        /// <summary>
        /// Initializes a new instance of the SerializableObjectsPostTask class.
        /// </summary>
        /// <param name="gISWebAPIManager">The GIS PostgreSQL Web API manager used to perform database operations.</param>
        public SerializableObjectsPostTask(GISWebAPIManager gISWebAPIManager)
        {
            GISWebAPIManager = gISWebAPIManager ?? throw new ArgumentNullException(nameof(gISWebAPIManager));
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
