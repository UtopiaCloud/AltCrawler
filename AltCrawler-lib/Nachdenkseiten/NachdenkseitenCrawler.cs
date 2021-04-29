using System;

namespace AltCrawler_lib.Nachdenkseiten
{
    public class NachdenkseitenCrawler
    {
        private int _timeout;
        private RestClient _client;
        
        public NachdenkseitenCrawler(int timeout)
        {
            _timeout = timeout;
            _client = new RestClient();
        }
        
        public void CrawlByIdRange(int idStart, int idEnd, Action<(int, string)> foundPage)
        {
            for (int i = idStart; i < idEnd; i++)
            {
                var html = _client.GetHtml(_timeout, $"https://www.nachdenkseiten.de/?p={i}");
                if (html == null)
                    continue;
                foundPage((i, html.DocumentNode.OuterHtml));
            }
        }
    }
}