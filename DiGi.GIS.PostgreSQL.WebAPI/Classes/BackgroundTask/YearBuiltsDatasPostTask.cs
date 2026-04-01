using DiGi.Core.Classes;
using DiGi.GIS.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DiGi.GIS.PostgreSQL.WebAPI.Classes
{
    public class YearBuiltDatasPostTask : SerializableObjectsPostTask<YearBuiltData>
    {
        public YearBuiltDatasPostTask(GISPostgreSQLWebAPIManager gISPostgreSQLWebAPIManager)
            : base(gISPostgreSQLWebAPIManager)
        {
        }

        public string? Code { get; set; }

        protected async Task<bool> ExecuteAsync(IEnumerable<YearBuiltData>? values, string? code, LongProgressWrapper? longProgressWrapper, CancellationToken cancellationToken)
        {
            if (values is null || !values.Any())
            {
                return false;
            }

            List<YearBuiltData>? yearBuiltData;

            bool result = true;

            MemorySizeSplitter<YearBuiltData> memorySizeSplitter = new(values);
            while ((yearBuiltData = memorySizeSplitter.Next(SerializableObjectsPostOptions.BatchMemorySize)) is not null)
            {
                cancellationToken.ThrowIfCancellationRequested();

                longProgressWrapper?.Increment(yearBuiltData.Count);

                result = await GISPostgreSQLWebAPIManager.UpdateItemsAsync(yearBuiltData, code, SerializableObjectsPostOptions);
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