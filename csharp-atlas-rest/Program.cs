using System.Text;
using csharp_atlas_rest.jira;
using csharp_atlas_rest.jira.Create;
using csharp_atlas_rest.jira.Projects;
using Fields = csharp_atlas_rest.jira.Create.Fields;
using Issuetype = csharp_atlas_rest.jira.Create.Issuetype;
using Project = csharp_atlas_rest.jira.Create.Project;

namespace csharp_atlas_rest
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var start = DateTime.Now;

            const string JIRA_HOST = "http://localhost:9500";
            const string user = "admin";
            const string password = "admin";
            // string token = Environment.GetEnvironmentVariable("TOKEN");
            string token = System.Convert.ToBase64String(Encoding.UTF8.GetBytes($"{user}:{password}"));

            // Actions

            // GET issue
            // var resp = JiraService.GetIssue(JIRA_HOST, token, "AAA-1");
            // Console.WriteLine(resp);   

            // CREATE Issue
            for (int i = 0; i < 1; i++)
            {
                CreateIssue createIssue = new CreateIssue
                {
                    fields = new Fields()
                    {
                        description = $"Some issue desciption {i}",
                        issuetype = new Issuetype()
                        {
                            id = 10006
                        },
                        project = new Project()
                        {
                            key = "AAA"
                        },
                        summary = "CCC Issue "
                    }
                };
                Console.WriteLine(createIssue);
                string createdIssue = IssueService.CreateIssue(JIRA_HOST, token, createIssue);
                Console.WriteLine(createdIssue);
            }

            // comments
            // var comments = CommentService.GetIssueComments(JIRA_HOST, token, "AAA-5");
            // comments.comments.ForEach(c => Console.WriteLine(c));

            var createProjJson = @"
    {   ""key"": ""EX"",
        ""name"": ""Example"",
        ""projectTypeKey"": ""business"",
        ""projectTemplateKey"": ""com.atlassian.jira-core-project-templates:jira-core-project-management"",
        ""description"": ""Example Project description"",
        ""lead"": ""Charlie"",
        ""url"": ""http://atlassian.co"",
        ""assigneeType"": ""PROJECT_LEAD"",
        ""avatarId"": 10200,
        ""issueSecurityScheme"": 10001,
        ""permissionScheme"": 10011,
        ""notificationScheme"": 10021,
        ""workflowSchemeId"": 10031,
        ""categoryId"": 10120
    }
";

            // var data = new CreateProject
            // {
            //     key = "BBB2",
            //     name = "Project BBB 2",
            //     projectTypeKey = "software",
            //     description = "test"
            //     
            // };
            // var project = ProjectService.CreateProject(JIRA_HOST, token, data);
            // Console.WriteLine(project);

            // ====== END
            Console.WriteLine($"*** The action took {DateTime.Now.Subtract(start).Milliseconds}");
        }

        // async void getAsyncStreamss()
        // {
        //     var streamTask = client.GetStreamAsync("https://api.github.com/orgs/dotnet/repos");
        //     var repositories = await JsonSerializer.DeserializeAsync<List<Repository>>(await streamTask);
        // }
    }
}