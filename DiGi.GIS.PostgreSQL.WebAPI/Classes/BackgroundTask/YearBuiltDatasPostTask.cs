using DiGi.Core.Classes;
using DiGi.GIS.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DiGi.GIS.PostgreSQL.WebAPI.Classes
{
    /// <summary>
    /// Provides functionality to handle the asynchronous posting of <see cref="YearBuiltData"/> collections to the PostgreSQL database.
    /// </summary>
    public class YearBuiltDatasPostTask : SerializableObjectsPostTask<YearBuiltData>
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="gISPostgreSQLWebAPIManager">The GIS PostgreSQL Web API manager used to handle data persistence.</param>
        public YearBuiltDatasPostTask(GISPostgreSQLWebAPIManager gISPostgreSQLWebAPIManager)
            : base(gISPostgreSQLWebAPIManager)
        {
        }

        /// <summary>
        ///
        /// </summary>
        public string? Code { get; set; }

        protected async Task<bool> ExecuteAsync(IEnumerable<YearBuiltData>? values, string? code, LongProgressWrapper? longProgressWrapper, CancellationToken cancellationToken)
        {
            if (values is null || !values.Any())
            {
                return false;
            }

            List<YearBuiltData>? yearBuiltDatas;

            bool result = true;

            MemorySizeSplitter<YearBuiltData> memorySizeSplitter = new(values);
            while ((yearBuiltDatas = memorySizeSplitter.Next(SerializableObjectsPostOptions.BatchMemorySize)) is not null)
            {
                cancellationToken.ThrowIfCancellationRequested();

                longProgressWrapper?.Increment(yearBuiltDatas.Count);

                result = await GISPostgreSQLWebAPIManager.UpdateItemsAsync(yearBuiltDatas, code, SerializableObjectsPostOptions);
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