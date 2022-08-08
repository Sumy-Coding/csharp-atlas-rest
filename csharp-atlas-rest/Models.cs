using System.Text.Json.Serialization;

namespace csharp_atlas_rest
{
    class Content
    {
        [JsonPropertyName("Id")]
        public string id { get; set; }
    
    }

    class Homepage
    {
        public string id { get; set; }
        public string type { get; set; }
        public string status { get; set; }
        public string title { get; set; }
    }

    struct Expandable
    {
        public string Settings { get; set; }
    }
    class Space
    {
        public int id { get; set; }
        public string key { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public string status { get; set; }
        public Homepage Homepage { get; set; }
        public Homepage Expandable { get; set; }
    }
}