using System.Text.Json.Serialization;

namespace csharp_atlas_rest
{
    class Content
    {
        [JsonPropertyName("Id")]
        public string id { get; set; }
    
    }
}