using System.Text;
using csharp_atlas_rest.confluence;
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

            string HOST = Environment.GetEnvironmentVariable("ATLAS_URL")!;
            string USER = Environment.GetEnvironmentVariable("ATLAS_USER")!;
            string PASS = Environment.GetEnvironmentVariable("ATLAS_PASS")!;
            string token = System.Convert.ToBase64String(Encoding.UTF8.GetBytes($"{USER}:{PASS}"));

            var ps = new PageService();
            // var resp = ps.GetPage(HOST, token, "519407997");
            //
            // Console.WriteLine(resp);

            var parentId = "519471120";

            for (int i = 1; i < 20; i++)
            {
                ps.CreatePage(HOST, token, $"Csharp TEST PAGE {i}", "Lorem ipsum some test...", "TEST", parentId);
            }
            
            
            // ====== END
            Console.WriteLine($"*** The action took {DateTime.Now.Subtract(start).Milliseconds}");
        }


        void jiraRun()
        {
             // Actions

            // GET issue
            // var resp = JiraService.GetIssue(JIRA_HOST, token, "AAA-1");
            // Console.WriteLine(resp);   

            // CREATE Issue
            // for (int i = 0; i < 5; i++)
            // {
            //     CreateIssue createIssue = new CreateIssue
            //     {
            //         fields = new Fields()
            //         {
            //             description = $"Some issue desciption {i}",
            //             issuetype = new Issuetype()
            //             {
            //                 id = 10006
            //             },
            //             project = new Project()
            //             {
            //                 key = "CCC"
            //             },
            //             summary = "CCC Issue "
            //         }
            //     };
            //     Console.WriteLine(createIssue);
            //     string createdIssue = IssueService.CreateIssue(JIRA_HOST, token, createIssue);
            //     Console.WriteLine(createdIssue);
            // }

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

            var data = new CreateProject
            {
                key = "BBB2",
                name = "Project BBB 2",
                projectTypeKey = "software",
                description = "test"
                
            };
            // var project = ProjectService.CreateProject(JIRA_HOST, token, data);
            // Console.WriteLine(project);
        }

        // async void getAsyncStreamss()
        // {
        //     var streamTask = client.GetStreamAsync("https://api.github.com/orgs/dotnet/repos");
        //     var repositories = await JsonSerializer.DeserializeAsync<List<Repository>>(await streamTask);
        // }
    }
}