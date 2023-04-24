
using WebCrawler.Application.AppServices;

namespace WebCrawler.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MainAsync().Wait();
        }

        static async Task MainAsync()
        {
            var webCrawler = new WebCrawlerTJBAAppService();

            await webCrawler.GetProcessFromTJBA("0809979-67.2015.8.05.0080");
        }
    }
}