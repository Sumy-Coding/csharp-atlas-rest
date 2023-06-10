using System.Net;
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

    public static string DeleteComment(string host, string token, string key, int id)
    {
        // DELETE /rest/api/2/issue/{issueIdOrKey}/comment/{id}
        client.DefaultRequestHeaders.Add("Authorization", $"Basic {token}");
        HttpRequestMessage request = new (
            HttpMethod.Delete,
            $"{host}/rest/api/2/issue/{key}/comment/{id}");
        Console.WriteLine($"Deleting comment for issue '{key}' :: {id}");
        var resp = client.SendAsync(request);
        if (resp.Result.StatusCode == HttpStatusCode.OK)
        {
            var respString = resp.Result.Content.ReadAsStringAsync().Result;
            IssueCommentsResult comments = JsonSerializer.Deserialize<IssueCommentsResult>(respString);
            return $"deleted comment {id}";
        }

        return $"ERROR deleting comment {id}";
    }
}