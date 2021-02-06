using System;
using System.Net;

namespace session2
{
    class Downloader
    {
        public string Download(string url)
        {
            WebClient client = new WebClient();
            Console.WriteLine("Download Complete.");
            return client.DownloadString(url);
        }
    }
}