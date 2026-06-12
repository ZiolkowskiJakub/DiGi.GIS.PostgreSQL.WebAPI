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
    public class OccupancyDatasPostTask : SerializableObjectsPostTask<OccupancyData>
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="gISPostgreSQLWebAPIManager">The manager used to handle GIS PostgreSQL Web API operations.</param>
        public OccupancyDatasPostTask(GISPostgreSQLWebAPIManager gISPostgreSQLWebAPIManager)
            : base(gISPostgreSQLWebAPIManager)
        {
        }

        /// <summary>
        ///
        /// </summary>
        public string? Code { get; set; }

        /// <summary>
        /// Gets or sets the collection of <see cref="DiGi.GIS.Classes.OccupancyData"/> values for administrative areal 2D.
        /// </summary>
        public IEnumerable<OccupancyData>? Values_AdministrativeAreal2D { get; set; }

        protected async Task<bool> ExecuteAsync(IEnumerable<OccupancyData>? occupancyData_Building2D, string? code, LongProgressWrapper? longProgressWrapper, CancellationToken cancellationToken)
        {
            if (occupancyData_Building2D is null || !occupancyData_Building2D.Any())
            {
                return false;
            }

            List<OccupancyData>? occupancyDatas;

            bool result = false;

            MemorySizeSplitter<OccupancyData> memorySizeSplitter = new(occupancyData_Building2D);
            while ((occupancyDatas = memorySizeSplitter.Next(SerializableObjectsPostOptions.BatchMemorySize)) is not null)
            {
                cancellationToken.ThrowIfCancellationRequested();

                longProgressWrapper?.Increment(occupancyDatas.Count);

                result = await GISPostgreSQLWebAPIManager.UpdateItemsAsync(occupancyDatas, code, SerializableObjectsPostOptions);
                if (!result)
                {
                    break;
                }
            }

            return result;
        }

        protected async Task<bool> ExecuteAsync(IEnumerable<OccupancyData>? occupancyData_AdministrativeAreal2D, LongProgressWrapper? longProgressWrapper, CancellationToken cancellationToken)
        {
            if (occupancyData_AdministrativeAreal2D is null || !occupancyData_AdministrativeAreal2D.Any())
            {
                return false;
            }

            List<OccupancyData>? occupancyDatas;

            bool result = false;

            MemorySizeSplitter<OccupancyData> memorySizeSplitter = new(occupancyData_AdministrativeAreal2D);
            while ((occupancyDatas = memorySizeSplitter.Next(SerializableObjectsPostOptions.BatchMemorySize)) is not null)
            {
                cancellationToken.ThrowIfCancellationRequested();

                longProgressWrapper?.Increment(occupancyDatas.Count);

                result = await GISPostgreSQLWebAPIManager.UpdateItemsAsync(occupancyDatas, SerializableObjectsPostOptions);
                if (!result)
                {
                    break;
                }
            }

            return result;
        }

        protected override async Task<bool> ExecuteAsync(IProgress<long> progress, CancellationToken cancellationToken)
        {
            bool result_1 = await ExecuteAsync(Values, Code, Core.Create.LongProgressWrapper(progress), cancellationToken);
            bool result_2 = await ExecuteAsync(Values_AdministrativeAreal2D, Core.Create.LongProgressWrapper(progress), cancellationToken);

            return result_1 || result_2;
        }
    }
}