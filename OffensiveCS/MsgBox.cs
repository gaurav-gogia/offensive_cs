using System;
using System.Runtime.InteropServices;

namespace OffensiveCS
{    
    class MsgBox
    {
        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern int MessageBox(int hWnd, string text, string caption, uint type);

        public static void Show(string title, string text)
        {
            int res = MessageBox(0, text, title, 0x00000000);
            Console.WriteLine(res);
        }
    }
}
