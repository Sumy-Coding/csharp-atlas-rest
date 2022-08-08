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
            string user = "admin";
            string password = "admin";
            string token = Environment.GetEnvironmentVariable("TOKEN");
            
            client.DefaultRequestHeaders.Add("Authorization", "Basic " + token);
            var resp = client.GetAsync("http://localhost:7190/display/DEV2/DEV2+1");
            var body = resp.Result.Content.ReadAsStringAsync();
            Console.WriteLine(body.Result);

            // var resStream = resp.Result.Content.ReadAsStream();
            // var readInt = resStream.ReadByte();

            HtmlService htmlService = new HtmlService();
            htmlService.ParseContentHtml(body.Result);

        }
        
        // async void getAsyncStreamss()
        // {
        //     var streamTask = client.GetStreamAsync("https://api.github.com/orgs/dotnet/repos");
        //     var repositories = await JsonSerializer.DeserializeAsync<List<Repository>>(await streamTask);
        // }
    }
   
    
}