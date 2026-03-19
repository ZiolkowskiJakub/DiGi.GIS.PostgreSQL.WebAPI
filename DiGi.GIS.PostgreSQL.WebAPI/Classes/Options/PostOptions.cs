using DiGi.Core.Classes;
using System;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace DiGi.GIS.PostgreSQL.WebAPI.Classes
{
    public class PostOptions : SerializableOptions
    {
        public PostOptions()
        {
        }

        public PostOptions(JsonObject jsonObject)
            : base(jsonObject)
        {
        }

        public PostOptions(PostOptions? postOptions)
            : base(postOptions)
        {
            if (postOptions is not null)
            {
                Delay = postOptions.Delay;
            }
        }

        [JsonInclude, JsonPropertyName("Delay")]
        public TimeSpan Delay { get; set; } = TimeSpan.FromSeconds(20);
    }
}