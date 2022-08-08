using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace csharp_atlas_rest;

public class PageService
{
    public string CreatePage(string url, string token, string title, string body, string key, string parentId)
    {
        HttpClient client = new HttpClient();
        client.DefaultRequestHeaders.Add("Authorization", "Basic " + token);
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Post, url);

        CreatePage createPage = new CreatePage();
        createPage.title = title;
        createPage.type = "page";
        Body pageBody = new Body();
        Storage storage = new Storage();
        storage.representation = "storage";
        storage.value = body;
        pageBody.storage = storage;
        createPage.body = pageBody;
        createPage.spaceKey = key;
        List<Ancestor> ancestors = new List<Ancestor>();
        Ancestor ancestor = new Ancestor();
        ancestor.id = parentId;
        ancestors[0] = ancestor;
        createPage.ancestors = ancestors;

        string pageJson = JsonSerializer.Serialize(createPage);
        requestMessage.Content = new StringContent(pageJson, Encoding.UTF8, "application/json");
        
        var resp = client.SendAsync(requestMessage);
        
        return resp.Result.ToString();
    }
}