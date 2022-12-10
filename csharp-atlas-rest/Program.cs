using System.Text;
using System.Text.Json.Serialization;
using csharp_atlas_rest;

namespace Atlas
{
    class Program
    {
        private static HttpClient client = new HttpClient();

        static async Task Main(string[] args)
        {
            var start =  DateTime.Now;
            
            const string CORE_URL = "http://localhost:9500"; // Jira
            const string ISSUE_REST_URL = "http://localhost:9500/rest/api/2/issue";
            const string user = "admin";
            const string password = "admin";
            // string token = Environment.GetEnvironmentVariable("TOKEN");
            string token = System.Convert.ToBase64String(Encoding.UTF8.GetBytes($"{user}:{password}"));

            // ACTION
            // GET issue
            var resp = JiraService.GetIssue(ISSUE_REST_URL, token, "TEST-1");
            Console.WriteLine(resp);   
            
            // CREATE Issue
            CreateIssue createIssue = new CreateIssue
            {
                
            };
            string createdIssue = JiraService.CreateIssue(ISSUE_REST_URL, token, createIssue: createIssue);
            Console.WriteLine(createIssue);
                
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