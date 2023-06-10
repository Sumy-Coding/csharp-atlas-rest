using System.Text.Json;
using csharp_atlas_rest.jira.Comments;

namespace csharp_atlas_rest.jira;

public class CommentService
{
    private static string APP_JSON = "application/json";
    static HttpClient client = new();
    
    public static IssueCommentsResult GetIssueComments(string host, string token, string key)
    {
        client.DefaultRequestHeaders.Add("Authorization", $"Basic {token}");
        HttpRequestMessage request = new (
            HttpMethod.Get,
            $"{host}/rest/api/2/issue/{key}/comment");
        Console.WriteLine($"Getting issue comments for {host} :: {key}");
        var resp = client.SendAsync(request);
        var respString = resp.Result.Content.ReadAsStringAsync().Result;
        IssueCommentsResult comments = JsonSerializer.Deserialize<IssueCommentsResult>(respString);
        return comments;
    }
}