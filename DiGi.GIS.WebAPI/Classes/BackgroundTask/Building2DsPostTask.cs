using DiGi.Core.Classes;
using DiGi.GIS.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DiGi.GIS.WebAPI.Classes
{
    /// <summary>
    /// Provides functionality to handle the asynchronous posting of multiple <see cref="Building2D"/> objects to the GIS PostgreSQL database.
    /// </summary>
    public class Building2DsPostTask : SerializableObjectsPostTask<Building2D>
    {
        /// <summary>
        /// Initializes a new instance of the Building2DsPostTask class.
        /// </summary>
        /// <param name="GISWebAPIManager">The <see cref="GISWebAPIManager"/> used to manage PostgreSQL GIS operations.</param>
        public Building2DsPostTask(GISWebAPIManager GISWebAPIManager)
            : base(GISWebAPIManager)
        {
        }

        /// <summary>
        /// Gets or sets the code associated with the building 2D post task.
        /// </summary>
        public string? Code { get; set; }

        protected async Task<bool> ExecuteAsync(IEnumerable<Building2D>? values, string? code, LongProgressWrapper? longProgressWrapper, CancellationToken? cancellationToken = default)
        {
            if (values is null || !values.Any())
            {
                return false;
            }

            List<Building2D>? building2Ds;

            bool result = true;

            MemorySizeSplitter<Building2D> memorySizeSplitter = new(values);
            while ((building2Ds = memorySizeSplitter.Next(SerializableObjectsPostOptions.BatchMemorySize)) is not null)
            {
                cancellationToken?.ThrowIfCancellationRequested();

                longProgressWrapper?.Increment(building2Ds.Count);

                result = await GISWebAPIManager.UpdateItemsAsync(building2Ds, code, SerializableObjectsPostOptions);
                if (!result)
                {
                    break;
                }
            }

            return result;
        }

        protected override async Task<bool> ExecuteAsync(IProgress<long> progress, CancellationToken cancellationToken)
        {
            return await ExecuteAsync(Values, Code, Core.Create.LongProgressWrapper(progress), cancellationToken);
        }
    }
}
