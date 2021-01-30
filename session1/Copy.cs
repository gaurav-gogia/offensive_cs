using System;
using System.Runtime.InteropServices;

namespace session1
{
    class Copy
    {
        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern bool CopyFile(string src, string dst, bool failOnExist);

        public void DoCopy()
        {
            bool res = CopyFile(@"C:\Users\mew\Desktop\test\a.txt", @"C:\Users\mew\Desktop\test\c.txt", true);
            if (res)
                Console.WriteLine("Done!");
            else
                Console.WriteLine("Destination file already exists");
            Console.ReadKey();
        }
    }
}
