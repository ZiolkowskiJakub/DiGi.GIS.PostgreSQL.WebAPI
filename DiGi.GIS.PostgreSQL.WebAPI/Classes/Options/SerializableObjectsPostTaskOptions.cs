using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace DiGi.GIS.PostgreSQL.WebAPI.Classes
{
    public class SerializableObjectsPostOptions : PostOptions
    {
        public SerializableObjectsPostOptions()
        {
        }

        public SerializableObjectsPostOptions(JsonObject jsonObject)
            : base(jsonObject)
        {
        }

        public SerializableObjectsPostOptions(SerializableObjectsPostOptions? serializableObjectsPostOptions)
            : base(serializableObjectsPostOptions)
        {
            if (serializableObjectsPostOptions is not null)
            {
                BatchMemorySize = serializableObjectsPostOptions.BatchMemorySize;
            }
        }

        [JsonInclude, JsonPropertyName("BatchMemorySize")]
        public int BatchMemorySize { get; set; } = 5 * 1024 * 1024;
    }
}