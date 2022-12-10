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

    class CreateSpace
    {
        public string key { get; set; }
        public string name { get; set; }
    }

    class CreatePage
    {
        public string title { get; set; }
        public string type { get; set; }
        public Body body { get; set; }
        public CreateSpacePage space { get; set; }
        public List<Ancestor> ancestors  { get; set; }
    }

    internal class CreateSpacePage
    {
        public string key { get; set; }
    }

    internal class Ancestor
    {
        public string id { get; set; }
    }

    internal class Body
    {
        public Storage storage { get; set; }
    }

    internal class Storage
    {
        public string representation { get; set; }
        public string value { get; set; }
    }
}