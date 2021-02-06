using System.Runtime.InteropServices;

namespace session1
{
    class Copier
    {
        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern bool CopyFile(string src, string dst, bool failOnExist);

        public string Copy(string src, string dst, bool failOnExist)
        {
            bool res = CopyFile(src, dst, failOnExist);
            return res ? "Done!" : "Could not overwrite file or some other error";
        }
    }
}