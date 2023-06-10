using System.Text;
using csharp_atlas_rest;
using csharp_atlas_rest.jira;

namespace csharp_atlas_rest
{
    class Program
    {
        private static HttpClient client = new HttpClient();

        static async Task Main(string[] args)
        {
            var start =  DateTime.Now;
            
            const string JIRA_HOST = "http://localhost:9500";
            const string user = "admin";
            const string password = "admin";
            // string token = Environment.GetEnvironmentVariable("TOKEN");
            string token = System.Convert.ToBase64String(
                Encoding.UTF8.GetBytes($"{user}:{password}"));

            // Actions
            
            // GET issue
            var resp = JiraService.GetIssue(JIRA_HOST, token, "AAA-1");
            Console.WriteLine(resp);   
            
            // CREATE Issue
            // CreateIssue createIssue = new CreateIssue
            // {
            //     fields = new Fields
            //     {
            //         Description = "test",
            //         issueType = new IssueType
            //         {
            //             Name = "Bug"
            //         },
            //         Project = new Project()
            //         {
            //             Key = "TEST"
            //         },
            //         Summary = "TEST"
            //     }
            // };
            // Console.WriteLine(createIssue);
            // string createdIssue = JiraService.CreateIssue(ISSUE_REST_URL, token, createIssue);
            // Console.WriteLine(createdIssue);
                
            // ===== create space
            // SpaceService spaceService = new SpaceService();
            // var resp = spaceService.CreateSpace(URL, token, "CSHR1", "CSHR1");
           
            // Console.WriteLine(resp);
            Console.WriteLine("*** The action took " + DateTime.Now.Subtract(start).Milliseconds);
        }
        
        // async void getAsyncStreamss()
        // {
        //     var streamTask = client.GetStreamAsync("https://api.github.com/orgs/dotnet/repos");
        //     var repositories = await JsonSerializer.DeserializeAsync<List<Repository>>(await streamTask);
        // }
    }
   
    
}