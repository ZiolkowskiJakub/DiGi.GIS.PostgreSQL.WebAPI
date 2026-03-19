using DiGi.Core.Classes;
using DiGi.GIS.Classes;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiGi.GIS.PostgreSQL.WebAPI.Classes
{
    public class AdministrativeAreal2DsPostTask : SerializableObjectsPostTask<AdministrativeAreal2D>
    {
        public AdministrativeAreal2DsPostTask(GISPostgreSQLWebAPIManager gISPostgreSQLWebAPIManager)
            : base(gISPostgreSQLWebAPIManager)
        {
        }

        protected override async Task<bool> ExecuteAsync()
        {
            if (Values is null || !Values.Any())
            {
                return false;
            }

            List<AdministrativeAreal2D>? administrativeAreal2Ds;

            bool result = true;

            MemorySizeSplitter<AdministrativeAreal2D> memorySizeSplitter = new(Values);
            while ((administrativeAreal2Ds = memorySizeSplitter.Next(SerializableObjectsPostOptions.BatchMemorySize)) is not null)
            {
                result = await GISPostgreSQLWebAPIManager.PostAsync(administrativeAreal2Ds, SerializableObjectsPostOptions);
                if (!result)
                {
                    break;
                }
            }

            return result;
        }
    }
}