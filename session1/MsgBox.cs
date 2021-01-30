using System;
using System.Runtime.InteropServices;

namespace session1
{
    class MsgBox
    {
        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern int MessageBox(int hWnd, string text, string caption, uint type);

        public void OpenBox()
        {
            int res = MessageBox(0, "lol you hacked", "hackerr alert", 0x00000002);
            Console.WriteLine(res);
            Console.ReadKey();
        }
    }
}