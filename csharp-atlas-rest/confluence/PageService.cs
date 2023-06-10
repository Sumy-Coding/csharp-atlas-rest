using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace csharp_atlas_rest.confluence;

public class PageService
{
    public string CreatePage(string host, string token, string title, string body, string key, string parentId)
    {
        HttpClient client = new HttpClient();
        client.DefaultRequestHeaders.Add("Authorization", $"Basic {token}");
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, $"{host}/rest/api/content");

        CreatePage createPage = new CreatePage();
        createPage.title = title;
        createPage.type = "page";
        Body pageBody = new Body();
        Storage storage = new Storage();
        storage.representation = "storage";
        storage.value = body;
        pageBody.storage = storage;
        createPage.body = pageBody;
        CreateSpacePage spacePage = new CreateSpacePage();
        spacePage.key = key;
        createPage.space = spacePage;
        List<Ancestor> ancestors = new List<Ancestor>();
        Ancestor ancestor = new Ancestor();
        ancestor.id = parentId;
        ancestors.Add(ancestor);
        createPage.ancestors = ancestors;

        string pageJson = JsonSerializer.Serialize(createPage);
        Console.WriteLine(pageJson);
        request.Content = new StringContent(pageJson, Encoding.UTF8, "application/json");
        
        var resp = client.SendAsync(request);
        
        return resp.Result.ToString();
    }
}