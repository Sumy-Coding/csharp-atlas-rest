using System.Buffers.Text;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using Newtonsoft.Json;

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
        client.DefaultRequestHeaders.Add("Authorization", "Basic " + token);
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Post, url);

        // CreateIssue createIssue = new CreateIssue();
        
        // string issueJson = JsonSerializer.Serialize(createIssue);
        string issueJson = JsonConvert.SerializeObject(createIssue);
        Console.WriteLine(issueJson);
        requestMessage.Content = new StringContent(issueJson, Encoding.UTF8, "application/json");
        Task<HttpResponseMessage> resp = client.SendAsync(requestMessage);
        // return Body (content)
        return resp.Result.Content.ReadAsStringAsync().Result.ToString();
    }
}