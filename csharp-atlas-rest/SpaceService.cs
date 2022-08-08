using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

namespace csharp_atlas_rest;

public class SpaceService
{
    public string CreateSpace(string url, string token, string key, string name)
    {
        HttpClient client = new HttpClient();
        // client.BaseAddress = new Uri("http://example.com/");
        client.DefaultRequestHeaders.Add("Authorization", "Basic " + token);
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Post, "http://localhost:7190/rest/api/space");

        CreateSpace space = new CreateSpace();
        space.key = key;
        space.name = name;
        
        string jsonSpace = JsonSerializer.Serialize(space);
        requestMessage.Content = new StringContent(jsonSpace, Encoding.UTF8, "application/json");
        
        var resp = client.SendAsync(requestMessage);
        /*client.SendAsync(request)
            .ContinueWith(responseTask =>
            {
                Console.WriteLine("Response: {0}", responseTask.Result);
            });*/
        // HttpContent content = new StringContent(jsonSpace);
        // var resp = client.PostAsync(url, content);
        return resp.Result.ToString();
    }
}