using DiGi.Core.Classes;
using DiGi.GIS.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DiGi.GIS.PostgreSQL.WebAPI.Classes
{
    public class AdministrativeAreal2DsPostTask : SerializableObjectsPostTask<AdministrativeAreal2D>
    {
        public AdministrativeAreal2DsPostTask(GISPostgreSQLWebAPIManager gISPostgreSQLWebAPIManager)
            : base(gISPostgreSQLWebAPIManager)
        {
        }

        protected async Task<bool> ExecuteAsync(IEnumerable<AdministrativeAreal2D>? values, LongProgressWrapper? longProgressWrapper, CancellationToken cancellationToken)
        {
            if (values is null || !values.Any())
            {
                return false;
            }

            List<AdministrativeAreal2D>? administrativeAreal2Ds;

            bool result = true;

            MemorySizeSplitter<AdministrativeAreal2D> memorySizeSplitter = new(values);
            while ((administrativeAreal2Ds = memorySizeSplitter.Next(SerializableObjectsPostOptions.BatchMemorySize)) is not null)
            {
                cancellationToken.ThrowIfCancellationRequested();

                result = await GISPostgreSQLWebAPIManager.UpdateItemsAsync(administrativeAreal2Ds, SerializableObjectsPostOptions);

                longProgressWrapper?.Increment(administrativeAreal2Ds.Count);

                if (!result)
                {
                    break;
                }
            }

            return result;
        }

        protected override async Task<bool> ExecuteAsync(IProgress<long> progress, CancellationToken cancellationToken)
        {
            return await ExecuteAsync(Values, Core.Create.LongProgressWrapper(progress), cancellationToken);
        }
    }
}