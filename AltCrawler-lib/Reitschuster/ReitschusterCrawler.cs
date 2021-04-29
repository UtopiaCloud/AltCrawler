using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AltCrawler_lib.Reitschuster
{
    public class ReitschusterCrawler
    {
        private int _timeout;
        private RestClient _client;
        private List<string> crawledPages = new List<string>();
        
        public ReitschusterCrawler(int timeout)
        {
            _timeout = timeout;
            _client = new RestClient();
        }
        
        public void CrawlByIdRange(Action<(string, string)> foundPage)
        {
            int counter = 0;

            while (true)
            {
                counter++;
                var html = _client.GetHtml(_timeout, $"https://reitschuster.de/page/{counter}/?s");
                if (html == null)
                    break;

                var regexMatches = new Regex(@"https:\/\/reitschuster.de\/post\/.+?\/")
                    .Matches(html.Text).Select(x => x.Value).Distinct().Where(x => x.Contains("-")).ToArray();
                
                foreach (var pageUrl in regexMatches)
                {
                    string[] pageUrlSplit = pageUrl.Split('/');
                    string pageName = pageUrlSplit[^2];
                    if (crawledPages.Contains(pageName))
                        continue;
                    crawledPages.Add(pageName);
                    foundPage((pageName, _client.GetHtml(_timeout, pageUrl).Text));
                }
            }
        }
    }
}