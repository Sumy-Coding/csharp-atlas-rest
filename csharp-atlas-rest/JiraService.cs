using System.Buffers.Text;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace csharp_atlas_rest;

public class JiraService
{
    public static string GetIssue(string url, string token, string key)
    {
        HttpClient client = new HttpClient();
        client.DefaultRequestHeaders.Add("Authorization", $"Basic {token}");
        HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Get, $"{url}/{key}");
        Console.WriteLine($"Getting issue with URL = {url}/{key}");
        var resp = client.SendAsync(requestMessage);
        var issue = resp.Result.Content.ReadAsStringAsync().Result;
        return issue;
    }
    
    public static string CreateIssue(string url, string token, CreateIssue createIssue)
    {
        /*
         {
            "fields": {
               "project":
               {
                  "id": "10110"
               },
               "summary": "No REST for the Wicked.",
               "description": "Creating of an issue using IDs for projects and issue types using the REST API",
               "issuetype": {
                  "id": "1"
               }
           }
        }
         */
        HttpClient client = new HttpClient();
        client.DefaultRequestHeaders.Add("Authorization", "Basic " + token);
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Post, url);

        // CreateIssue createIssue = new CreateIssue();
        
        string pageJson = JsonSerializer.Serialize(createIssue);
        Console.WriteLine(pageJson);
        requestMessage.Content = new StringContent(pageJson, Encoding.UTF8, "application/json");
        
        var resp = client.SendAsync(requestMessage);
        
        return resp.Result.ToString();
    }
}