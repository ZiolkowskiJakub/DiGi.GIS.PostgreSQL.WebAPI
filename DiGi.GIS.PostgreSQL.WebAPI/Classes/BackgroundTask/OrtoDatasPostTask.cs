using DiGi.Core.Classes;
using DiGi.GIS.Classes;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiGi.GIS.PostgreSQL.WebAPI.Classes
{
    public class OrtoDatasPostTask : SerializableObjectsPostTask<OrtoDatas>
    {
        public OrtoDatasPostTask(GISPostgreSQLWebAPIManager gISPostgreSQLWebAPIManager)
            : base(gISPostgreSQLWebAPIManager)
        {
        }

        public string? Code { get; set; }

        protected override async Task<bool> ExecuteAsync()
        {
            if (Values is null || !Values.Any())
            {
                return false;
            }

            List<OrtoDatas>? ortoDatas;

            bool result = true;

            MemorySizeSplitter<OrtoDatas> memorySizeSplitter = new(Values);
            while ((ortoDatas = memorySizeSplitter.Next(SerializableObjectsPostOptions.BatchMemorySize)) is not null)
            {
                result = await GISPostgreSQLWebAPIManager.UpdateItemsAsync(ortoDatas, Code, SerializableObjectsPostOptions);
                if (!result)
                {
                    break;
                }
            }

            return result;
        }
    }
}