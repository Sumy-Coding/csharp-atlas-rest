using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using csharp_atlas_rest.jira.Projects;

namespace csharp_atlas_rest.jira;

public class ProjectService
{
    private static string APP_JSON = "application/json";
    static HttpClient client = new();
    
    public static Project[] GetProjects(string host, string token)
    {
        Console.WriteLine($" \u001b[32m Getting \u001b[0m projects for {host}");
        
        client.DefaultRequestHeaders.Add("Authorization", $"Basic {token}");

        HttpRequestMessage request = new (HttpMethod.Get, $"{host}/rest/api/2/project");
        
        var resp = client.SendAsync(request);
        var respString = resp.Result.Content.ReadAsStringAsync().Result;
        
        Project[] projects = JsonSerializer.Deserialize<Project[]>(respString);
        return projects;
    }
    
    public static CreatedProject CreateProject(string host, string token, CreateProject data)
    {
        Console.WriteLine($" \u001b[32m Creating \u001b[0m project for {host}");
        
        client.DefaultRequestHeaders.Add("Authorization", $"Basic {token}");
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(APP_JSON));

        HttpRequestMessage request = new (
            HttpMethod.Post,
            $"{host}/rest/api/2/project");

        var jsonData = JsonSerializer.Serialize(data);
        request.Content = new StringContent(jsonData, Encoding.UTF8, APP_JSON);
        Console.WriteLine(jsonData);

        /*
         * {
                "key": "EX",
                "name": "Example",
                "projectTypeKey": "business",
                "projectTemplateKey": "com.atlassian.jira-core-project-templates:jira-core-project-management",
                "description": "Example Project description",
                "lead": "Charlie",
                "url": "http://atlassian.com",
                "assigneeType": "PROJECT_LEAD",
                "avatarId": 10200,
                "issueSecurityScheme": 10001,
                "permissionScheme": 10011,
                "notificationScheme": 10021,
                "workflowSchemeId": 10031,
                "categoryId": 10120
            }
         */
        
        Task<HttpResponseMessage> resp = client.SendAsync(request);
        Console.WriteLine(resp.Result.StatusCode.ToString());
        
        var respString = resp.Result.Content.ReadAsStringAsync().Result;
        var project = JsonSerializer.Deserialize<CreatedProject>(respString);
        
        return project;
    }
}