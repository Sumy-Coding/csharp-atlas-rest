using System.Buffers.Text;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using csharp_atlas_rest.jira.Create;
using csharp_atlas_rest.jira;
using csharp_atlas_rest.jira.Update;

namespace csharp_atlas_rest.jira;

public class IssueService
{
    private static string APP_JSON = "application/json";
    static HttpClient client = new ();

    public static Issue GetIssue(string host, string token, string key)
    {
        client.DefaultRequestHeaders.Add("Authorization", $"Basic {token}");
        HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, $"{host}/rest/api/2/issue/{key}");
        Console.WriteLine($"Getting issue with URL = {host} :: {key}");
        var resp = client.SendAsync(request);
        var respString = resp.Result.Content.ReadAsStringAsync().Result;
        Issue issue = JsonSerializer.Deserialize<Issue>(respString);
        return issue;
    }
    
    public static string CreateIssue(string host, string token, CreateIssue createIssue)
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
        
        client.DefaultRequestHeaders.Add("Authorization", $"Basic {token}");
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(APP_JSON));
        
        HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, $"{host}/rest/api/2/issue/");

        string issueJson = JsonSerializer.Serialize(createIssue);
        // Console.WriteLine(issueJson);
        request.Content = new StringContent(issueJson, Encoding.UTF8, APP_JSON);
        Task<HttpResponseMessage> resp = client.SendAsync(request);
        // return Body (content)
        return resp.Result.Content.ReadAsStringAsync().Result.ToString();
    }

    public Issue UpdateIssue(string host, string token, UpdateIssue updateIssue)
    {
        HttpClient client = new HttpClient();
        client.DefaultRequestHeaders.Add("Authorization", $"Basic {token}");
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Put, APP_JSON);
        string reqJson = JsonSerializer.Serialize(updateIssue);
        request.Content = new StringContent(reqJson, Encoding.UTF8, APP_JSON);

        var resp = IssueService.client.SendAsync(request);
        var result = JsonSerializer.Deserialize<Issue>(resp.Result.Content.ReadAsStringAsync().Result);
        if (result != null)
        {
            return result;
        }

        return new Issue();
;    }
}