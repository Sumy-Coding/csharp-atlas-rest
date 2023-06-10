using System.Buffers.Text;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using csharp_atlas_rest.jira.Create;
using csharp_atlas_rest.jira;

namespace csharp_atlas_rest.jira;

public class JiraService
{
    public static Issue GetIssue(string host, string token, string key)
    {
        HttpClient client = new HttpClient();
        client.DefaultRequestHeaders.Add("Authorization", $"Basic {token}");
        HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, $"{host}/rest/api/2/issue/{key}");
        Console.WriteLine($"Getting issue with URL = {host} :: {key}");
        var resp = client.SendAsync(request);
        var respString = resp.Result.Content.ReadAsStringAsync().Result;
        Issue issue = JsonSerializer.Deserialize<Issue>(respString);
        return issue;
    }
    
    public static string CreateIssue(string url, string token, CreateIssue createIssue)
    {
        /*
         https://developer.atlassian.com/server/jira/platform/jira-rest-api-examples/
         {
            "fields": {
               "project":
               {
                  "name": "TEST"
               },
               "summary": "No REST for the Wicked.",
               "description": "Creating of an issue using IDs for projects and issue types using the REST API",
               "issuetype": {
                  "name": "Bug"
               }
           }
        }
         */
        HttpClient client = new HttpClient();
        client.DefaultRequestHeaders.Add("Authorization", $"Basic {token}");
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        
        HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, url);

        string issueJson = JsonSerializer.Serialize(createIssue);
        Console.WriteLine(issueJson);
        request.Content = new StringContent(issueJson, Encoding.UTF8, "application/json");
        Task<HttpResponseMessage> resp = client.SendAsync(request);
        // return Body (content)
        return resp.Result.Content.ReadAsStringAsync().Result.ToString();
    }
}