using System.Net;

namespace OffensiveCS
{
    class Downloader
    {
        public static string Download(string url)
        {
            WebClient client = new WebClient();
            return client.DownloadString(url);
        }
    }
}
