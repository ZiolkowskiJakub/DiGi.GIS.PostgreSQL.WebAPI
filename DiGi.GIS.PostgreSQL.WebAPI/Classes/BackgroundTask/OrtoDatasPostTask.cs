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

        protected async Task<bool> ExecuteAsync(IEnumerable<OrtoDatas>? values, string? code)
        {
            if (values is null || !values.Any())
            {
                return false;
            }

            List<OrtoDatas>? ortoDatasBatch;
            bool result = true;

            MemorySizeSplitter<OrtoDatas> memorySizeSplitter = new(values);
            while ((ortoDatasBatch = memorySizeSplitter.Next(SerializableObjectsPostOptions.BatchMemorySize)) is not null)
            {
                result = await GISPostgreSQLWebAPIManager.UpdateItemsAsync(ortoDatasBatch, code, SerializableObjectsPostOptions);
                if (!result)
                {
                    break;
                }
            }

            return result;
        }

        protected override async Task<bool> ExecuteAsync()
        {
            return await ExecuteAsync(Values, Code);
        }
    }
}