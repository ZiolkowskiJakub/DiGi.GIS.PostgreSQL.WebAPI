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
    /// 
    /// </summary>
    public class OrtoDatasPostTask : SerializableObjectsPostTask<OrtoDatas>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="gISPostgreSQLWebAPIManager">The manager instance used to handle PostgreSQL web API operations.</param>
        public OrtoDatasPostTask(GISPostgreSQLWebAPIManager gISPostgreSQLWebAPIManager)
            : base(gISPostgreSQLWebAPIManager)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        public string? Code { get; set; }

        protected async Task<bool> ExecuteAsync(IEnumerable<OrtoDatas>? values, string? code, LongProgressWrapper? longProgressWrapper, CancellationToken cancellationToken)
        {
            if (values is null || !values.Any())
            {
                return false;
            }

            List<OrtoDatas>? ortoDatasList;
            bool result = true;

            MemorySizeSplitter<OrtoDatas> memorySizeSplitter = new(values);
            while ((ortoDatasList = memorySizeSplitter.Next(SerializableObjectsPostOptions.BatchMemorySize)) is not null)
            {
                cancellationToken.ThrowIfCancellationRequested();

                longProgressWrapper?.Increment(ortoDatasList.Count);

                result = await GISPostgreSQLWebAPIManager.UpdateItemsAsync(ortoDatasList, code, SerializableObjectsPostOptions);
                if (!result)
                {
                    break;
                }
            }

            return result;
        }

        protected async Task<bool> ExecuteAsync(IEnumerable<OrtoDatas>? values, int countyId, LongProgressWrapper? longProgressWrapper, CancellationToken cancellationToken)
        {
            if (values is null || !values.Any())
            {
                return false;
            }

            List<OrtoDatas>? ortoDatasList;
            bool result = true;

            MemorySizeSplitter<OrtoDatas> memorySizeSplitter = new(values);
            while ((ortoDatasList = memorySizeSplitter.Next(SerializableObjectsPostOptions.BatchMemorySize)) is not null)
            {
                cancellationToken.ThrowIfCancellationRequested();

                longProgressWrapper?.Increment(ortoDatasList.Count);

                result = await GISPostgreSQLWebAPIManager.UpdateItemsAsync(ortoDatasList, countyId, SerializableObjectsPostOptions);
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