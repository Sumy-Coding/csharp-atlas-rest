using System.Net.Http.Json;
using System.Text.Json;

namespace csharp_atlas_rest;

public class SpaceService
{
    public string CreateSpace(string url, string token, string key, string name)
    {
        HttpClient client = new HttpClient();
        client.DefaultRequestHeaders.Add("Authorization", "Basic " + token);
        client.DefaultRequestHeaders.Add("Content-Type", "application/json");
        Space space = new Space();
        space.key = key;
        space.name = name;
        string jsonSpace = JsonSerializer.Serialize(space);
        HttpContent content = new StringContent(jsonSpace);
        var resp = client.PostAsync(url, content);
        return resp.Result.ToString();
    }
}