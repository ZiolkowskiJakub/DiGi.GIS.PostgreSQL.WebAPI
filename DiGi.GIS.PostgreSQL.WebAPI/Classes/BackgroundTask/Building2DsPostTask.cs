using DiGi.Core.Classes;
using DiGi.GIS.Classes;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiGi.GIS.PostgreSQL.WebAPI.Classes
{
    public class Building2DsPostTask : SerializableObjectsPostTask<Building2D>
    {
        public Building2DsPostTask(GISPostgreSQLWebAPIManager gISPostgreSQLWebAPIManager)
            : base(gISPostgreSQLWebAPIManager)
        {
        }

        public string? Code { get; set; }

        protected async Task<bool> ExecuteAsync(IEnumerable<Building2D>? values, string? code)
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
                result = await GISPostgreSQLWebAPIManager.UpdateItemsAsync(building2Ds, code, SerializableObjectsPostOptions);
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