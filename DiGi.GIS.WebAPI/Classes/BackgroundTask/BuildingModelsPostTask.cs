using DiGi.Core.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DiGi.GIS.WebAPI.Classes
{
    /// <summary>
    /// Provides functionality to handle the asynchronous posting of <see cref="DiGi.Analytical.Building.Classes.BuildingModel"/> collections to the PostgreSQL database.
    /// </summary>
    public class BuildingModelsPostTask : SerializableObjectsPostTask<DiGi.Analytical.Building.Classes.BuildingModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BuildingModelsPostTask"/> class.
        /// </summary>
        /// <param name="GISWebAPIManager">The <see cref="GISWebAPIManager"/> instance used to communicate with the server.</param>
        public BuildingModelsPostTask(GISWebAPIManager GISWebAPIManager)
            : base(GISWebAPIManager)
        {
        }

        /// <summary>
        /// Asynchronously executes the task of posting building models to the database in memory-size-split batches.
        /// </summary>
        /// <param name="buildingModels">The collection of <see cref="DiGi.Analytical.Building.Classes.BuildingModel"/> instances to post.</param>
        /// <param name="longProgressWrapper">A <see cref="LongProgressWrapper"/> tracking the progress of the operation.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> to observe for cancellation requests.</param>
        /// <returns>A task that represents the asynchronous operation. The task result is true if all batches were posted successfully; otherwise, false.</returns>
        protected async Task<bool> ExecuteAsync(IEnumerable<DiGi.Analytical.Building.Classes.BuildingModel>? buildingModels, LongProgressWrapper? longProgressWrapper, CancellationToken cancellationToken = default)
        {
            if (buildingModels is null || !buildingModels.Any())
            {
                return false;
            }

            List<DiGi.Analytical.Building.Classes.BuildingModel>? buildingModels_Batch;

            bool result = true;

            MemorySizeSplitter<DiGi.Analytical.Building.Classes.BuildingModel> memorySizeSplitter = new(buildingModels);
            while ((buildingModels_Batch = memorySizeSplitter.Next(SerializableObjectsPostOptions.BatchMemorySize)) is not null)
            {
                cancellationToken.ThrowIfCancellationRequested();

                longProgressWrapper?.Increment(buildingModels_Batch.Count);

                result = await GISWebAPIManager.UpdateItemsAsync(buildingModels_Batch, SerializableObjectsPostOptions);
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
            return await ExecuteAsync(Values, Core.Create.LongProgressWrapper(progress), cancellationToken);
        }
    }
}