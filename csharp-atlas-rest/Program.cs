// See https://aka.ms/new-console-template for more information

using System.Text.Json.Serialization;
using csharp_atlas_rest;
using HtmlAgilityPack;

namespace Atlas
{
    class Program
    {
        private static HttpClient client = new HttpClient();

        static async Task Main(string[] args)
        {
            var start =  System.DateTime.Now;
            
            string URL = "http://localhost:7190";
            string CONTENT_REST_URL = "http://localhost:7190/rest/api/content";
            string user = "admin";
            string password = "admin";
            string token = Environment.GetEnvironmentVariable("TOKEN");
            
            // client.DefaultRequestHeaders.Add("Authorization", "Basic " + token);
            // var resp = client.GetAsync("http://localhost:7190/display/DEV2/DEV2+1");
            // var body = resp.Result.Content.ReadAsStringAsync();
            // Console.WriteLine(body.Result);

            // ===== create page
            PageService pageService = new PageService();
            // var resp = pageService.CreatePage(url:CONTENT_REST_URL, token, "Page 2", "a sdas as s ad", "CSHR1", "1212418");
            // ==== create several pages
            for (int i = 1; i < 15; i++)
            {
                var resp = pageService.CreatePage(url:CONTENT_REST_URL, token, "Page csharp" + i, "CSharp TEST " + i, "CSHR1", "1212418");
                Console.WriteLine(resp);
            }
            
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