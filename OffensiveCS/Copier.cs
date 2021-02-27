using System;
using OffensiveCS.Flags;
using System.Runtime.InteropServices;

namespace OffensiveCS
{
    class Copier
    {
        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern bool CopyFile(string src, string dst, bool failOnExist);

        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern bool CopyFileExW(string src, string dst, IntPtr state, IntPtr data, bool cancel, CopyFlags flags);

        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern uint LpprogressRoutine(long totalSize, long bytesTransferred, long streamSize, long streamBytesTransferred, uint streamNumber, uint callbackReason, UIntPtr sourceFile, UIntPtr dstFile, IntPtr data);

        public static string Copy(string src, string dst, bool failOnExist)
        {
            bool res = CopyFile(src, dst, failOnExist);
            return res ? "Done!" : "Could not overwrite file or some other error";
        }

        public static string CopyEx(string src, string dst)
        {
            bool res = CopyFileExW(src, dst, IntPtr.Zero, IntPtr.Zero, false, CopyFlags.COPY_FILE_NO_BUFFERING);
            return res ? "Done!" : "Could not overwrite file or some other error";
        }

    }
}
