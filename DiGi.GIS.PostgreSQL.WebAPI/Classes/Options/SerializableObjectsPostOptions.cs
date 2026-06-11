using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace DiGi.GIS.PostgreSQL.WebAPI.Classes
{
    /// <summary>
    /// Represents the configuration options for posting serializable objects, extending the base post options functionality.
    /// </summary>
    public class SerializableObjectsPostOptions : DiGi.WebAPI.Classes.PostOptions
    {
        /// <summary>
        /// 
        /// </summary>
        public SerializableObjectsPostOptions()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="jsonObject">The <see cref="T:System.Text.Json.Nodes.JsonObject" /> containing the data used to initialize the options.</param>
        public SerializableObjectsPostOptions(JsonObject jsonObject)
            : base(jsonObject)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="serializableObjectsPostOptions">The source options instance to copy values from, or <see langword="null"/> to use default settings.</param>
        public SerializableObjectsPostOptions(SerializableObjectsPostOptions? serializableObjectsPostOptions)
            : base(serializableObjectsPostOptions)
        {
            if (serializableObjectsPostOptions is not null)
            {
                BatchMemorySize = serializableObjectsPostOptions.BatchMemorySize;
            }
        }

        /// <summary>
        /// Gets or sets the memory size threshold in bytes used for processing batches of serializable objects.
        /// </summary>
        [JsonInclude, JsonPropertyName(nameof(BatchMemorySize))]
        public int BatchMemorySize { get; set; } = 10 * 1024 * 1024;
    }
}