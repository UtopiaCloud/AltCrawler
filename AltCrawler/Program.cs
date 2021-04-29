using System;
using System.IO;
using AltCrawler_lib;
using AltCrawler_lib.Reitschuster;

namespace AltCrawler
{
    class Program
    {
        private static string _storagePath;
        
        static void Main(string[] args)
        {
            _storagePath = "./reitschuster";
            if (!Directory.Exists(_storagePath))
                Directory.CreateDirectory(_storagePath);
            var reitschusterCrawler = new ReitschusterCrawler(500);
            
            reitschusterCrawler.CrawlByIdRange(FoundPage);
        }

        private static void FoundPage((string, string) obj)
        {
            string path = Path.Combine(_storagePath, obj.Item1);
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            
            File.WriteAllText(Path.Combine(_storagePath, Path.Combine(obj.Item1, DateTime.Now.ConvertDatetimeToUnixTimeStamp() + ".html")), obj.Item2);
        }

        /*
        static void Main(string[] args)
        {
            _storagePath = "./nachdenkseiten";
            if (!Directory.Exists(_storagePath))
                Directory.CreateDirectory(_storagePath);
            var nachdenkseiten = new NachdenkseitenCrawler(500);
            nachdenkseiten.CrawlByIdRange(1000, 10000, FoundPage);
        }

        private static void FoundPage((int, string) obj)
        {
            string path = Path.Combine(_storagePath, obj.Item1.ToString());
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            //var paths = Directory.GetFiles(path).Select(x => Path.GetFileName(x));
            
            File.WriteAllText(Path.Combine(_storagePath, Path.Combine(obj.Item1.ToString(), DateTime.Now.ConvertDatetimeToUnixTimeStamp() + ".html")), obj.Item2);
        }*/
    }
}