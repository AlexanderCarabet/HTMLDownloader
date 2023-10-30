using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.IO;

class Program
{
    private const string url = "http://söderfix.com";
    private static readonly string folderPath = Path.Combine("WebSitesData");
   

    private static readonly string filePath = Path.Combine(folderPath, "söderfix.html");

    static async Task Main(string[] args)
    {
        Directory.CreateDirectory(folderPath);  // Skapar mappen
        await DownloadAndSaveHtmlAsync(url, filePath);
    }

    static async Task DownloadAndSaveHtmlAsync(string url, string filePath)
    {
        using HttpClient client = new();
        try
        {
            string html = await client.GetStringAsync(url);
            await File.WriteAllTextAsync(filePath, html);
            Console.WriteLine($"HTML-koden har sparats till {filePath}");
        }
        catch (HttpRequestException e)
        {
            Console.WriteLine($"Ett fel uppstod: {e.Message}");
        }
    }
}
