using System;
using System.Net;
using System.Threading;
using HtmlAgilityPack;

namespace AltCrawler_lib
{
    public class RestClient
    {
        public HtmlDocument GetHtml(int timeout, string url)
        {
            Thread.Sleep(timeout);
            using WebClient client = new WebClient();
            client.Headers["User-Agent"] = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/87.0.4280.88 Safari/537.36";
            HtmlDocument doc = new HtmlDocument();
            try
            {
                doc.LoadHtml(client.DownloadString(url));
                Console.WriteLine("DONE " + url);
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR " + url + " : " + ex.Message);
                return null;
            }
            return doc;
        }
    }
}