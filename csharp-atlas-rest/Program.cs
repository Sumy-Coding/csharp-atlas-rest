// See https://aka.ms/new-console-template for more information

using System.Net.Http.Headers;
using System.Text.Encodings.Web;
using System.Text.Json;
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
            client.DefaultRequestHeaders.Add("country", "Ukraine");
            var resp = client.GetAsync("http://example.com");
            var body = resp.Result.Content.ReadAsStringAsync();

            // var resStream =resp.Result.Content.ReadAsStream();
            // var readInt = resStream.ReadByte();

            HtmlEncoder encoder = HtmlEncoder.Default;
            TextWriter writer = new StringWriter();
            encoder.Encode(writer, body.Result);

            HtmlDocument document = new HtmlDocument();
            document.LoadHtml(body.Result);

            List<string> elems = new List<string>();
            foreach (var elem in document.DocumentNode.SelectNodes("//div"))
            {
                elems.Add(elem.InnerText);
                Console.WriteLine(elems[0]);    
            }
            
        }
        
        // async void getAsyncStreamss()
        // {
        //     var streamTask = client.GetStreamAsync("https://api.github.com/orgs/dotnet/repos");
        //     var repositories = await JsonSerializer.DeserializeAsync<List<Repository>>(await streamTask);
        // }
    }
   
    
}