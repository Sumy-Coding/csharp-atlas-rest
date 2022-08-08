using HtmlAgilityPack;

namespace csharp_atlas_rest;

public class HtmlService
{
    public void ParseContentHtml(string html)
    {
        HtmlDocument document = new HtmlDocument();
        document.LoadHtml(html);

        List<string> elems = new List<string>();
        foreach (var elem in document.DocumentNode.SelectNodes("//div"))
        {
            elems.Add(elem.InnerText);
            Console.WriteLine(elems[0]);    
        }
    }
}