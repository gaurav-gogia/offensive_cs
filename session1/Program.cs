using System;

namespace session1
{
    class Program
    {
        private static readonly string src = @"C:\Users\mew\Desktop\test\a.txt";
        private static readonly string dst = @"C:\Users\mew\Desktop\test\c.txt";

        static void Main(string[] args)
        {
            Copier copier = new Copier();
            string restext = copier.Copy(src, dst, true);

            MsgBox box = new MsgBox();
            box.Show("CopyFile Response", restext);

            restext = copier.CopyEx(src, dst);

            box.Show("CopyFile Response", restext);

            Console.ReadKey();
        }
    }
}
