using Newtonsoft.Json;

using static Newtonsoft.Json.JsonPropertyAttribute;

namespace csharp_atlas_rest;

public class CreateIssue
{
    [JsonProperty("fields")]
    public Fields fields { get; set; }

    public override string ToString()
    {
        return $"CreateIssue: Fields: {fields}";
    }
}

public class Fields
{
    [JsonProperty("summary")]
    public string Summary { get; set; }
    [JsonProperty("description")]
    public string Description { get; set; }
    [JsonProperty("project")]
    public Project Project { get; set; }
    [JsonProperty("issuetype")]
    public IssueType issueType { get; set; }
    
    public override string ToString()
    {
        return $"CreateIssue: Description: {Description}";
    }
}

public class Project
{
    // public string Id { get; set; }
    [JsonProperty("key")]
    public string Key { get; set; }
}

public class IssueType
{
    // public string Id { get; set; }
    [JsonProperty("name")]
    public string Name { get; set; }
}