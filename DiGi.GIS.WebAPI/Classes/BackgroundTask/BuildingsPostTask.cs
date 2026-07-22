using DiGi.CityGML.Classes;
using DiGi.Core.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DiGi.GIS.WebAPI.Classes
{
    /// <summary>
    /// Provides functionality to handle the asynchronous posting of <see cref="Building"/> collections to the PostgreSQL database.
    /// </summary>
    public class BuildingsPostTask : SerializableObjectsPostTask<Building>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BuildingsPostTask"/> class.
        /// </summary>
        /// <param name="GISWebAPIManager">The GIS PostgreSQL Web API manager used to handle data persistence.</param>
        public BuildingsPostTask(GISWebAPIManager GISWebAPIManager)
            : base(GISWebAPIManager)
        {
        }

        /// <summary>
        /// Gets or sets the code associated with the buildings post task.
        /// </summary>
        public string? Code { get; set; }

        /// <summary>
        /// Asynchronously executes the task of posting building objects to the database.
        /// </summary>
        protected async Task<bool> ExecuteAsync(IEnumerable<Building>? values, string? code, LongProgressWrapper? longProgressWrapper, CancellationToken cancellationToken)
        {
            if (values is null || !values.Any())
            {
                return false;
            }

            List<Building>? buildings_Batch;

            bool result = true;

            MemorySizeSplitter<Building> memorySizeSplitter = new(values);
            while ((buildings_Batch = memorySizeSplitter.Next(SerializableObjectsPostOptions.BatchMemorySize)) is not null)
            {
                cancellationToken.ThrowIfCancellationRequested();

                longProgressWrapper?.Increment(buildings_Batch.Count);

                result = await GISWebAPIManager.UpdateItemsAsync(buildings_Batch, code, SerializableObjectsPostOptions);
                if (!result)
                {
                    break;
                }
            }

            return result;
        }

        /// <inheritdoc />
        protected override async Task<bool> ExecuteAsync(IProgress<long> progress, CancellationToken cancellationToken)
        {
            return await ExecuteAsync(Values, Code, Core.Create.LongProgressWrapper(progress), cancellationToken);
        }
    }
}